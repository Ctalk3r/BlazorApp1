using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Areas.Identity.Pages.Account.Models
{
	public class EmailModel
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }

	}
}
