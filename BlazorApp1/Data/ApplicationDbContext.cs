using System;
using System.Collections.Generic;
using System.Text;
using BlazorApp1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Data
{
	public class ApplicationDbContext : IdentityDbContext<User>
	{
		public DbSet<Job> Jobs { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<SecretChat> SecretChats { get; set; }


		public ApplicationDbContext() { }
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
			Database.EnsureCreated();
		}
	}
}
