using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Models
{
	public class JobModel
	{
		[Required]
		public string Title { get; set; }
		[Required]
		[MinLength(100)]
		public string Description { get; set; }
		[Required]
		[CustomValidation(typeof(JobModel), nameof(RequiredDateTime))]
		public DateTime? Term { get; set; }
		[Required]
		[CustomValidation(typeof(JobModel), nameof(RequiredPrice))]
		public string Price { get; set; }
		public static ValidationResult RequiredPrice(string price, ValidationContext vc)
		{
			decimal _;
			return Decimal.TryParse(price, out _) && _ > decimal.Zero
				? ValidationResult.Success
				: new ValidationResult("Incorrect Price", new[] { vc.MemberName });
		}

		public static ValidationResult RequiredDateTime(DateTime? value, ValidationContext vc)
		{
			return value > DateTime.Now
				? ValidationResult.Success
				: new ValidationResult($"The {vc.MemberName} field is required.", new[] { vc.MemberName });
		}
	}
}
