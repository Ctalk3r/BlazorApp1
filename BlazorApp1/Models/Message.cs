using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Models
{
    public class Message
    {
        public Message(string username, string body, bool isMine)
        {
            Username = username;
            Body = body;
            IsMine = isMine;
        }

        public string Username { get; set; }
        public string Body { get; set; }
        public bool IsMine { get; set; }
        public string Side
        {
            get
            {
                return IsMine ? "sent" : "received";
            }
        }
    }
}
