using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC_Project.Models
{
	public class Transaction
	{
		public int TransactionNumber { get; set; }
		public DateTime TransactionDate { get; set; }
		public decimal TransactionAmount { get; set; }
		public string TransactionType { get; set; }
		public string TransactionNote { get; set; }

		public int AccountNumber { get; set; } //fk
		public Account Account { get; set; } //nav

	}
}
