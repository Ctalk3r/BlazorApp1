using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models
{
	public class User : IdentityUser
	{
		public string FirstName { get; set; }
		public string SecondName { get; set; }
		public string ImageSource { get; set; }
		public string Country { get; set; }
		public string City { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public DateTime RegistrationDate { get; set; } = DateTime.Now;
	}
}
