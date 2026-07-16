using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFC_Project.Enum;

namespace EFC_Project.Models
{
	public class CustomerAccount
	{
		public OwnerShipType OwnerShipType { get; set; }
		public AccountStatus AccountStatus { get; set; }
		public DateTime OwnerShipStartDate { get; set; }


		public int CustomerID { get; set; } //fk
		public Customer Customer { get; set; } //nav

		public int AccountNumber { get; set; } //fk
		public Account Account { get; set; } //nav

	}
}
