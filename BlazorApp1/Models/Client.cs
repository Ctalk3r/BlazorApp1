using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Models
{
	public class Client : IdentityUser
	{
		public virtual ICollection<Job> WorkHistory { get; set; }
		public virtual ICollection<Job> CurrentWorks { get; set; }
	}
}
