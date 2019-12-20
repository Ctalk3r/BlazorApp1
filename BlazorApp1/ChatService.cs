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
		private Dictionary<string, TimeSpan> SecretChatsDict =
			new Dictionary<string, TimeSpan>();
		public void AddCallback(EventCallback<Tuple<string, string>> callback, string userId)
		{
			if (notifyDict.ContainsKey(userId))
				notifyDict[userId] = callback;
			else
				notifyDict.Add(userId, callback);
		}
		public void AddTimer(string key, TimeSpan value)
		{
			if (SecretChatsDict.ContainsKey(key))
				SecretChatsDict[key] = value;
			else
				SecretChatsDict.Add(key, value);
		}
		public void NotifyUser(string userId, string message, string who)
		{
			var D = Dispatcher.CreateDefault();
			if (notifyDict.ContainsKey(userId))
				D.InvokeAsync(async () => await notifyDict[userId].InvokeAsync(new Tuple<string, string>(who, message)));

		}
		public void CheckSecretChats(ApplicationDbContext _applicationDbContext)
		{
			var Messages = _applicationDbContext.Messages?.Where(message => message.IsSecret).ToList();
			var groups = Messages?.GroupBy(message => message.FirstUserId.GetHashCode() < message.SecondUserId.GetHashCode() ? 
														message.FirstUserId + "_" + message.SecondUserId :
														message.SecondUserId + "_" + message.FirstUserId);
			foreach (var group in groups)
			{
				if (SecretChatsDict.ContainsKey(group.Key) == false) continue;
				var deleted = group.ToList().FindAll(message => (DateTime.Now - message.CreationTime) >= SecretChatsDict[group.Key]);
				if (deleted != null && deleted.Count != 0)
				{
					var D = Dispatcher.CreateDefault();
					D.InvokeAsync(async () => await notifyDict[group.Key.Split('_')[0]].InvokeAsync(new Tuple<string, string>(null, String.Join(' ', deleted.Select(message => message.MesssageId)))));
					D.InvokeAsync(async () => await notifyDict[group.Key.Split('_')[1]].InvokeAsync(new Tuple<string, string>(null, String.Join(' ', deleted.Select(message => message.MesssageId)))));
				}
			}
		}
	}
}
