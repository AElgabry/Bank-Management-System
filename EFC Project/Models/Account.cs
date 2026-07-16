using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC_Project.Models
{
	public class Account
	{
		public int AccountNumber { get; set; }
		public decimal CurrentBalance { get; set; }
		public string AccountType { get; set; }
		public DateTime OpeningDate{ get; set; }


		public Branch Branch { get; set; } //nav
		public int BranchCode { get; set; } //fk

		public ICollection<CustomerAccount> CustomerAccounts { get; set; } = new List<CustomerAccount>(); //nav

		public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>(); //nav
	}
}
