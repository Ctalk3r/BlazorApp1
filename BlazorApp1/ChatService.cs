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
		public void AddCallback(EventCallback<Tuple<string, string>> callback, string userId)
		{
			if (notifyDict.ContainsKey(userId))
				notifyDict[userId] = callback;
			else
				notifyDict.Add(userId, callback);
		}
		public void NotifyUser(string userId, string message, string who)
		{
			var D = Dispatcher.CreateDefault();
			if (notifyDict.ContainsKey(userId))
				D.InvokeAsync(async () => await notifyDict[userId].InvokeAsync(new Tuple<string, string>(who, message)));

		}
	}
}
