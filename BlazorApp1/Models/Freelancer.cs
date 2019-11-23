using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Models
{
	public class Freelancer : User
	{
		public string Title { get; set; }
		public string CV { get; set; }
		public Decimal HourlyRate { get; set; }
		public string Education { get; set; }
		public virtual ICollection<Job> WorkHistory { get; set; }
		public virtual ICollection<Job> CurrentWorks { get; set; }
		// public virtual ICollection<String> Skills { get; set; }
		// public virtual ICollection<String> EmploymentHistory { get; set; }
	}
}
