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
		public string Description { get; set; }
		public bool IsCompleted { get; set; }
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid JobId { get; set; } = Guid.NewGuid();
		public Guid ClientId { get; set; }
		public Guid FreelancerId { get; set; }
	}
}
