using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using EFC_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFC_Project.Configurations
{
	public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
	{
		public void Configure(EntityTypeBuilder<Manager> entity)
		{
			entity.ToTable("Managers");
			entity.HasIndex(i => i.EmailAddress).IsUnique();
			entity.HasIndex(i => i.BranchCode).IsUnique();
			entity.HasKey(p=>p.ManagerID);
			entity.HasOne(n => n.ManagerBranch).WithOne(n => n.Manager).HasForeignKey<Manager>(f => f.BranchCode);
			entity.HasData(
			new Manager { ManagerID = 1, ManagerFullName = "Ahmed Salah", EmailAddress = "ahmed.salah@natbank.com", ManagerPhoneNumber = "01012345678", HireDate = new DateTime(2019, 3, 14), BranchCode = 1 },
			new Manager { ManagerID = 2, ManagerFullName = "Mona Farouk", EmailAddress = "mona.farouk@natbank.com", ManagerPhoneNumber = "01098765432", HireDate = new DateTime(2020, 7, 1), BranchCode = 2 },
			new Manager { ManagerID = 3, ManagerFullName = "Karim Adel", EmailAddress = "karim.adel@natbank.com", ManagerPhoneNumber = "01123456789", HireDate = new DateTime(2021, 1, 20), BranchCode = 3 });
		}
	}
}
