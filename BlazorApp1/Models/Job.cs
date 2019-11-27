using System;
using System.Collections.Generic;
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
		public TimeSpan EstimatedTime { get; set; }
		public int HourlyRate { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid JobId { get; set; } = Guid.NewGuid();
		public Guid ClientId { get; set; }
		public Guid FreelancerId { get; set; }
	}
}
