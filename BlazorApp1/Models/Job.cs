using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Models
{
	public class Job
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public int Status { get; set; }
		public string Skills { get; set; }

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Property '" + nameof(EstimatedTime) + "' should be used instead.")]
		public long DurationTicks { get; set; }

		[NotMapped]
		public TimeSpan EstimatedTime
		{
#pragma warning disable 618
			get { return new TimeSpan(DurationTicks); }
			set { DurationTicks = value.Ticks; }
#pragma warning restore 618
		}

		[Column(TypeName = "decimal(10,2)")]
		public Decimal Price { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public DateTime CreationDate { get; set; } = DateTime.Now;

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public string JobId { get; set; } = Guid.NewGuid().ToString();
		public string ClientId { get; set; }
		public string FreelancerId { get; set; }

		public void AppendSkill(string skill)
		{
			if (Skills == "" || Skills == null)
				Skills = skill;
			else
				Skills += "," + skill;
		}
	}
}
