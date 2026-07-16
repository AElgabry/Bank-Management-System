using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFC_Project.Enum;

namespace EFC_Project.Models
{
	public class Customer
	{
		public int CustomerID { get; set; }
		public string CustomerAddress { get; set; }
		public DateTime CustomerDateOfBirth { get; set; }
		public string CustomerFullName { get; set; }
		public string CustomerEmailAddress { get; set; }
		public string CustomerPhoneNumber { get; set; }

		public CustomerType CustomerType { get; set; }
		
		public string CustomerNationalID { get; set; }

		public ICollection<CustomerAccount> CustomerAccounts { get; set; } = new List<CustomerAccount>(); //nav

	}
}
