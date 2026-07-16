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
	public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
	{
		public void Configure(EntityTypeBuilder<Models.Transaction> entity)
		{
			entity.HasKey(pk => pk.TransactionNumber);
			entity.HasOne(n => n.Account).WithMany(n => n.Transactions).HasForeignKey(fk => fk.AccountNumber);
			entity.Property(p=>p.TransactionAmount).HasColumnType("decimal(18,2)");
			entity.HasData(
			new Transaction { TransactionNumber = 1, TransactionDate = new DateTime(2024, 2, 1), TransactionAmount = 2000.00m, TransactionType = "Deposit", TransactionNote = "Salary deposit", AccountNumber = 1001 },
			new Transaction { TransactionNumber = 2, TransactionDate = new DateTime(2024, 2, 3), TransactionAmount = 500.00m, TransactionType = "Withdrawal", TransactionNote = "ATM withdrawal", AccountNumber = 1001 },
			new Transaction { TransactionNumber = 3, TransactionDate = new DateTime(2024, 2, 5), TransactionAmount = 1200.50m, TransactionType = "Payment", TransactionNote = "Utility bill", AccountNumber = 1002 },
			new Transaction { TransactionNumber = 4, TransactionDate = new DateTime(2024, 2, 10), TransactionAmount = 50000.00m, TransactionType = "Deposit", TransactionNote = "Client payment received", AccountNumber = 1003 },
			new Transaction { TransactionNumber = 5, TransactionDate = new DateTime(2024, 2, 12), TransactionAmount = 10000.00m, TransactionType = "Transfer", TransactionNote = "Transfer to supplier", AccountNumber = 1003 },
			new Transaction { TransactionNumber = 6, TransactionDate = new DateTime(2024, 3, 1), TransactionAmount = 1000.00m, TransactionType = "Deposit", TransactionNote = "Cash deposit", AccountNumber = 1004 },
			new Transaction { TransactionNumber = 7, TransactionDate = new DateTime(2024, 3, 4), TransactionAmount = 250.75m, TransactionType = "Withdrawal", TransactionNote = "Grocery shopping", AccountNumber = 1005 }		);


		}
	}

}
