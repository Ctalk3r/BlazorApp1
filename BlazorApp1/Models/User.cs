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
		[Required]
		[Key]
		public override string Email {get; set;}
		public string FirstName { get; set; }
		public string SecondName { get; set; }
		public string ImageSource { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
		public string Role { get; set; }
		public int SuccessfulJobsNumber { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public DateTime RegistrationDate { get; set; } = DateTime.Now;
		public override string Id { get; set; } = Guid.NewGuid().ToString();

		// freelancer feature
		public string Title { get; set; }
		public string CV { get; set; }

		[Column(TypeName = "decimal(10,2)")]
		public Decimal HourlyRate { get; set; }
		public string Education { get; set; }
		public string Skills { get; set; }
		public double Rating { get; set; }
	}
}
