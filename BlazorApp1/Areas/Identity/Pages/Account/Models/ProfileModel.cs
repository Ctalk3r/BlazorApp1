using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Areas.Identity.Pages.Account.Models
{
	public class ProfileModel
	{
		public string FirstName { get; set; }
		public string SecondName { get; set; }

		[Phone]
		[Display(Name = "Phone number")]
		public string PhoneNumber { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
	}
}
