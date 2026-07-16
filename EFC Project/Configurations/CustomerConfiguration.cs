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
	public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
	{
		public void Configure(EntityTypeBuilder<Customer> entity)
		{
			entity.HasKey(pk => pk.CustomerID);
			entity.HasIndex(i => i.CustomerEmailAddress).IsUnique();
			entity.HasIndex(i => i.CustomerNationalID).IsUnique();
			entity.HasData(
			new Customer { CustomerID = 1, CustomerFullName = "Youssef Hany", CustomerAddress = "3 Smouha St, Alexandria", CustomerDateOfBirth = new DateTime(1995, 5, 12), CustomerEmailAddress = "youssef.hany@mail.com", CustomerPhoneNumber = "01055512345", CustomerType = CustomerType.Individual, CustomerNationalID = "29505121234567" },
			new Customer { CustomerID = 2, CustomerFullName = "Nour ElDin Tarek", CustomerAddress = "7 Sidi Gaber, Alexandria", CustomerDateOfBirth = new DateTime(1990, 11, 3), CustomerEmailAddress = "nour.tarek@mail.com", CustomerPhoneNumber = "01166654321", CustomerType = CustomerType.Individual, CustomerNationalID = "29011031234567" },
			new Customer { CustomerID = 3, CustomerFullName = "Delta Trading Co.", CustomerAddress = "22 Nasr City, Cairo", CustomerDateOfBirth = new DateTime(2005, 1, 1), CustomerEmailAddress = "contact@deltatrading.com", CustomerPhoneNumber = "0224455667", CustomerType = CustomerType.Business, CustomerNationalID = "10000000000001" },
			new Customer { CustomerID = 4, CustomerFullName = "Salma Reda", CustomerAddress = "5 Dokki, Giza", CustomerDateOfBirth = new DateTime(1998, 8, 22), CustomerEmailAddress = "salma.reda@mail.com", CustomerPhoneNumber = "01234567890", CustomerType = CustomerType.Individual, CustomerNationalID = "29808221234567" },
			new Customer { CustomerID = 5, CustomerFullName = "Omar Fathy", CustomerAddress = "9 Agouza, Giza", CustomerDateOfBirth = new DateTime(1988, 4, 9), CustomerEmailAddress = "omar.fathy@mail.com", CustomerPhoneNumber = "01187654321", CustomerType = CustomerType.Individual, CustomerNationalID = "28804091234567" });
		}
	}
}
