using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFC_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFC_Project.Configurations
{
	public class AccountConfiguration : IEntityTypeConfiguration<Account>
	{
		public void Configure(EntityTypeBuilder<Account> entity)
		{
			entity.HasKey(k => k.AccountNumber);
			entity.Property(a => a.AccountNumber).ValueGeneratedNever(); 
			entity.Property(a => a.CurrentBalance).HasColumnType("decimal(18,2)");
			entity.HasOne(n => n.Branch).WithMany(n => n.Accounts).HasForeignKey(f=>f.BranchCode);
			entity.HasData(
			new Account { AccountNumber = 1001, CurrentBalance = 15500.00m, AccountType = "Savings", OpeningDate = new DateTime(2022, 1, 10), BranchCode = 1 },
			new Account { AccountNumber = 1002, CurrentBalance = 8200.50m, AccountType = "Current", OpeningDate = new DateTime(2022, 3, 5), BranchCode = 1 },
			new Account { AccountNumber = 1003, CurrentBalance = 250000.00m, AccountType = "Business", OpeningDate = new DateTime(2023, 2, 15), BranchCode = 2 },
			new Account { AccountNumber = 1004, CurrentBalance = 5000.00m, AccountType = "Savings", OpeningDate = new DateTime(2023, 6, 1), BranchCode = 3 },
			new Account { AccountNumber = 1005, CurrentBalance = 30250.75m, AccountType = "Current", OpeningDate = new DateTime(2024, 1, 18), BranchCode = 2 });
		}
	}
}
