using BlazorApp1.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1
{
	public class ChatService
	{
		private Dictionary<string, EventCallback<Tuple<string, string>>> notifyDict  =
			new Dictionary<string, EventCallback<Tuple<string, string>>>();
		private Dictionary<string, Tuple<string, string>> waitDict = 
			new Dictionary<string, Tuple<string, string>>();
		public void AddCallback(EventCallback<Tuple<string, string>> callback, string userId)
		{
			if (notifyDict.ContainsKey(userId))
				notifyDict[userId] = callback;
			else
			{
				notifyDict.Add(userId, callback);
				if (waitDict.ContainsKey(userId))
				{
					NotifyUser(userId, waitDict[userId].Item2, waitDict[userId].Item1);
					waitDict.Remove(userId);
				}
			}
		}
		public void NotifyUser(string userId, string message, string who)
		{
			var D = Dispatcher.CreateDefault();
			if (notifyDict.ContainsKey(userId))
				D.InvokeAsync(async () => await notifyDict[userId].InvokeAsync(new Tuple<string, string>(who, message)));
			else if (who.Split('_').Count() == 2 && who.Split('_')[0] == "sent")
				waitDict.Add(userId, new Tuple<string, string>(who, message));
		}

		public void CheckSecretChats(ApplicationDbContext _applicationDbContext)
		{
			var SecretChatsDict = _applicationDbContext.SecretChats.ToDictionary(chat => chat.ChatId, chat => chat.Timer);
			var Messages = _applicationDbContext.Messages?.Where(message => message.IsSecret && message.IsTimered).ToList();
			var groups = Messages?.GroupBy(message => CompareStrings(message.FirstUserId, message.SecondUserId) ? 
														message.FirstUserId + "_" + message.SecondUserId :
														message.SecondUserId + "_" + message.FirstUserId);
			foreach (var group in groups)
			{
				if (SecretChatsDict.ContainsKey(group.Key) == false || SecretChatsDict[group.Key] < TimeSpan.FromSeconds(1)) continue;
				var deleted = group.ToList().FindAll(message => (DateTime.Now - message.CreationTime) >= SecretChatsDict[group.Key]);
				if (deleted != null && deleted.Count != 0)
				{
					var D = Dispatcher.CreateDefault();
					D.InvokeAsync(async () => await notifyDict[group.Key.Split('_')[0]].InvokeAsync(new Tuple<string, string>(null, String.Join(' ', deleted.Select(message => message.MesssageId)))));
					D.InvokeAsync(async () => await notifyDict[group.Key.Split('_')[1]].InvokeAsync(new Tuple<string, string>(null, String.Join(' ', deleted.Select(message => message.MesssageId)))));
				}
			}
		}
		private bool CompareStrings(string s1, string s2)
		{
			if (s1.Length < s2.Length)
				return true;
			if (s1.Length > s2.Length)
				return false;
			for (int i = 0; i < s1.Length; ++i)
			{
				if ((int)s1[i] < (int)s2[i])
					return true;
				if ((int)s1[i] > (int)s2[i])
					return false;
			}
			return true;
		}
	}
}
