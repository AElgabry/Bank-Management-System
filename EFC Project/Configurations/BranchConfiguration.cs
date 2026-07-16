using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFC_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFC_Project.Configurations
{
	public class BranchConfiguration:IEntityTypeConfiguration<Branch>
	{
		public void Configure(EntityTypeBuilder<Branch> entity)
		{
			entity.ToTable("Branches");
			entity.HasKey(k => k.BranchCode);
			entity.HasData(
			new Branch { BranchCode = 1, BranchName = "Alexandria Main", BranchAddress = "12 Corniche St, Alexandria", BranchPhoneNumber = "0345678901" },
			new Branch { BranchCode = 2, BranchName = "Cairo Downtown", BranchAddress = "45 Tahrir Sq, Cairo", BranchPhoneNumber = "0223456789" },
			new Branch { BranchCode = 3, BranchName = "Giza Branch", BranchAddress = "8 Pyramids Rd, Giza", BranchPhoneNumber = "0233445566" });
		}
	}
}
