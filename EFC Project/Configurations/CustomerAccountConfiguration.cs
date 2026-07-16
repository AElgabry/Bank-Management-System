using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFC_Project.Enum;
using EFC_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFC_Project.Configurations
{
	public class CustomerAccountConfiguration : IEntityTypeConfiguration<CustomerAccount>
	{
		public void Configure(EntityTypeBuilder<CustomerAccount> entity)
		{
			entity.HasKey(ck => new{ck.AccountNumber, ck.CustomerID});
			entity.HasOne(n => n.Customer).WithMany(n => n.CustomerAccounts).HasForeignKey(fk => fk.CustomerID);
			entity.HasOne(n => n.Account).WithMany(n => n.CustomerAccounts).HasForeignKey(fk => fk.AccountNumber);
			entity.HasData(
			new CustomerAccount { CustomerID = 1, AccountNumber = 1001, OwnerShipType = OwnerShipType.Primary_Holder, AccountStatus = AccountStatus.Active, OwnerShipStartDate = new DateTime(2022, 1, 10) },
			new CustomerAccount { CustomerID = 1, AccountNumber = 1002, OwnerShipType = OwnerShipType.Primary_Holder, AccountStatus = AccountStatus.Active, OwnerShipStartDate = new DateTime(2022, 3, 5) },
			new CustomerAccount { CustomerID = 3, AccountNumber = 1003, OwnerShipType = OwnerShipType.Primary_Holder, AccountStatus = AccountStatus.Active, OwnerShipStartDate = new DateTime(2023, 2, 15) },
			new CustomerAccount { CustomerID = 4, AccountNumber = 1003, OwnerShipType = OwnerShipType.Co_Holder, AccountStatus = AccountStatus.Active, OwnerShipStartDate = new DateTime(2023, 2, 15) },
			new CustomerAccount { CustomerID = 4, AccountNumber = 1004, OwnerShipType = OwnerShipType.Primary_Holder, AccountStatus = AccountStatus.Active, OwnerShipStartDate = new DateTime(2023, 6, 1) },
			new CustomerAccount { CustomerID = 5, AccountNumber = 1005, OwnerShipType = OwnerShipType.Primary_Holder, AccountStatus = AccountStatus.Closed, OwnerShipStartDate = new DateTime(2024, 1, 18) }	);
		}
	}
}
