using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EFC_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace EFC_Project.App_Context
{
	public class AppDbContext:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=.;Database=BankSystem;Trusted_Connection=True;TrustServerCertificate=True");
		}
		

		public DbSet<Branch> Branches { get; set; }
		public DbSet<Manager> Managers { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Account> Accounts { get; set; }
		public DbSet<CustomerAccount> CustomerAccounts { get; set; }
		public DbSet<Transaction> Transactions { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(
				Assembly.GetExecutingAssembly());
		}
	}
}
