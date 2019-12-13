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

		[Column(TypeName = "decimal(10,2)")]
		public Decimal HourlyRate { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public DateTime CreationDate { get; set; } = DateTime.Now;

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public string JobId { get; set; } = Guid.NewGuid().ToString();
		public string ClientId { get; set; }
		public string FreelancerId { get; set; }
	}
}
