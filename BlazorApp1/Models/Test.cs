using BlazorApp1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace BlazorApp1.Models
{
	public static class Test
	{
		public static void Add(ApplicationDbContext db)
		{
			db.Jobs.AddRange(new Job {  Description = "New job" },
				new Job { IsCompleted = true, JobId=Guid.NewGuid(), ClientId=Guid.NewGuid(), FreelancerId=Guid.NewGuid(), Description = "New job" });
			db.SaveChanges();
			var t = db.Jobs.Count();
			var x = db.Jobs.First();
			int a = 2;
		}
	}
}
