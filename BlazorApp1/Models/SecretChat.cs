using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Models
{
	public class SecretChat
	{
		public SecretChat() { }
		public bool IsEncrypted { get; set; } = false;
		public SecretChat(string id)
		{
			ChatId = id;
			Timer = TimeSpan.Zero;
		}
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public DateTime CreationTime { get; set; } = DateTime.Now;
		[Key]
		public string ChatId { get; set; }

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Property '" + nameof(Timer) + "' should be used instead.")]
		public long DurationTicks { get; set; }

		[NotMapped]
		public TimeSpan Timer
		{
#pragma warning disable 618
			get { return new TimeSpan(DurationTicks); }
			set { DurationTicks = value.Ticks; }
#pragma warning restore 618
		}
	}
}
