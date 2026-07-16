using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC_Project.Models
{
	public class Manager
	{

		public int ManagerID { get; set; }
		public string ManagerFullName { get; set; }
		public string EmailAddress { get; set; }
		public string ManagerPhoneNumber { get; set; }
		public DateTime HireDate { get; set; }
		public Branch ManagerBranch { get; set; } // NAV
		public int BranchCode { get; set; } //fk
	}
}
