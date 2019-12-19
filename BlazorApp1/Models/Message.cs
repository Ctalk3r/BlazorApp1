using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public bool IsSecret { get; set; }
        public string FirstUserId { get; set; }
        public string SecondUserId { get; set; }
        public string Side
        {
            get
            {
                return IsMine ? "sent" : "received";
            }
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreationTime { get; set; } = DateTime.Now;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string MesssageId { get; set; } = Guid.NewGuid().ToString();
    }
}
