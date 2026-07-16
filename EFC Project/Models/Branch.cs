using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC_Project.Models
{
	public class Branch
	{
		public int BranchCode { get; set; }
		public string BranchName { get; set; }
		public string BranchAddress { get; set; }
		public string BranchPhoneNumber { get; set; }

		public Manager Manager { get; set; } //nav
		public ICollection<Account> Accounts { get; set; } = new List<Account>(); //nav

	}
}
