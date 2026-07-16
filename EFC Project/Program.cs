using System.Data;
using EFC_Project.App_Context;
using EFC_Project.Enum;
using EFC_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace EFC_Project
{
	public class Program
	{
		static void Main(string[] args)
		{
			using var db = new AppDbContext();
			bool running = true;

			while (running)
			{
				Console.Clear();
				showMainMenu();
				Console.Write("Enter your choice: ");
				bool isValid = int.TryParse(Console.ReadLine(), out int choice);

				if (!isValid)
				{
					Console.WriteLine("Invalid input, please enter a number.");
				}
				else
				{
					switch (choice)
					{
						case 1: AddNewCustomer(db); break;
						case 2: NewAccount(db); break;
						case 3: UpdateAccountStatus(db); break;
						case 4: RemoveAccount(db); break;
						case 5: ListCustomers(db); break;
						case 0: running = false; break;
						default:
							Console.WriteLine("Invalid choice, please select a valid option.");
							break;
					}
				}

				if (running)
				{
					Console.WriteLine("\nPress any key to return to the menu...");
					Console.ReadKey();
				}
			}
		}
		#region Operations

		static void showMainMenu()
		{
			Console.WriteLine("===============================\nNational Bank\n===============================");
			Console.WriteLine("1) Add new Customer");
			Console.WriteLine("2) Open new account");
			Console.WriteLine("3) Update account status");
			Console.WriteLine("4) Remove an account");
			Console.WriteLine("5) List all accounts");
			Console.WriteLine("0) Exit");			
		}
		static void AddNewCustomer(AppDbContext db)
		{
			Console.WriteLine("============ Add New Customer ============");
			Console.Write("Full Name: ");
			string fullName = Console.ReadLine();
			Console.Write("National ID: ");
			string NationalID = Console.ReadLine();
			Console.Write("Data of Birth: ");
			bool Isdob = DateTime.TryParse(Console.ReadLine(), out DateTime dob);
			Console.Write("Email Address: ");
			string email = Console.ReadLine();
			Console.Write("Phone Number: ");
			string phone = Console.ReadLine();
			Console.Write("Address: ");
			string address = Console.ReadLine();
			Console.Write("Customer Type:\n 1) Individual\n2)Business\nChoice 1 OR 2: ");
			if (!int.TryParse(Console.ReadLine(), out int cusType) || (cusType != 1 && cusType != 2))
			{
				Console.WriteLine("Please enter a valid type (1 or 2)");
				return;
			}

			if (db.Customers.Any(n => n.CustomerNationalID == NationalID))
			{
				Console.WriteLine("The National ID already exists, try new one.");
				return;
			}
			if(db.Customers.Any(n => n.CustomerEmailAddress == email))
			{
				Console.WriteLine("The email address already exists");
				return;
			}

			Customer customer = new Customer
			{
				CustomerFullName = fullName,
				CustomerNationalID = NationalID,
				CustomerEmailAddress = email,
				CustomerPhoneNumber = phone,
				CustomerAddress = address,
				CustomerDateOfBirth = dob,
				CustomerType = (CustomerType)cusType
			};
			db.Customers.Add(customer);
			db.SaveChanges();
			Console.WriteLine($"Customer has been added successfully. Customer ID: {customer.CustomerID}");
		}
		static void NewAccount(AppDbContext db)
		{
			Console.WriteLine("============ Open  ============");
			Console.Write("Account Number: ");
			bool isNum = int.TryParse(Console.ReadLine(), out int accNum);
			Console.Write("Account Type: ");
			string accType = Console.ReadLine();
			Console.Write("Branch Code: ");
			bool isBra = int.TryParse(Console.ReadLine(), out int braCode);
			Console.Write("Customer ID: ");
			bool isCus = int.TryParse(Console.ReadLine(), out int CusID);
			Console.WriteLine("OwnerShip Role:\n1) Primary\n2) CoHolder ");
			bool isRole = int.TryParse(Console.ReadLine(), out int role);
			if( role!= 1 && role !=2 )
			{
				Console.WriteLine("Please enter a valid number '1 OR 2'");
				return;
			}

			Account? acc = db.Accounts.Find(accNum);
			if (acc != null)
			{
				Console.WriteLine("This account number already exist");
				return;
			}

			if (!db.Branches.Any(n => n.BranchCode == braCode))
			{
				Console.WriteLine("The branch code entered does not exists");
				return;
			}

			Customer? cus = db.Customers.FirstOrDefault(n=>n.CustomerID==CusID);
			if (cus == null)
			{
				Console.WriteLine("This customer does not exist");
				return;
			}

			acc = new Account
			{
				AccountNumber = accNum,
				AccountType = accType,
				CurrentBalance = 0,
				OpeningDate = DateTime.Now,
				BranchCode = braCode
			};

			CustomerAccount cusAcc = new CustomerAccount
			{
				Account = acc,
				Customer = cus,
				OwnerShipStartDate = DateTime.Now,
				OwnerShipType = (OwnerShipType)role,
				AccountStatus = AccountStatus.Active
			};
			db.CustomerAccounts.Add(cusAcc);
			db.SaveChanges();
			Console.WriteLine($"Account '{accNum}' is created successfully, and linked to customer {CusID} as the {cusAcc.OwnerShipType}");


		}
		static void UpdateAccountStatus(AppDbContext db)
		{
			Console.WriteLine("================= Update Account Status =================");
			Console.Write("Account Number: ");
			bool isaAcc = int.TryParse(Console.ReadLine(), out int accNum);
			Console.Write("Customer ID: ");
			bool isCus = int.TryParse(Console.ReadLine(), out int cusId);
			Console.Write("New Status: \n1) Active\n2) Closed\nChoice: ");
			bool isStat = int.TryParse(Console.ReadLine(), out int newStatus);
			if (newStatus != 1 && newStatus != 2)
			{
				Console.WriteLine("Please enter a valid number '1 OR 2'");
				return;
			}

			Account? account = db.Accounts.FirstOrDefault(n=>n.AccountNumber==accNum);

			if(account==null)
			{
				Console.WriteLine("This account number does not exist");
				return;
			};
			
			Customer? customer = db.Customers.FirstOrDefault(n => n.CustomerID == cusId);
			if (customer == null)
			{
				Console.WriteLine("This customer ID does not exist");
				return;
			};

			CustomerAccount? cusAcc= db.CustomerAccounts.Find( accNum, cusId);
			if(cusAcc==null)
			{
				Console.WriteLine("There is no a linked account between these both account number and customer ID");
				return;
			}
			cusAcc.AccountStatus = (AccountStatus)newStatus;
			db.SaveChanges();

			Console.WriteLine($"Status updated to {(AccountStatus)newStatus}");



		}
		static void RemoveAccount(AppDbContext db)
		{
			Console.WriteLine("=================== Remove Account From A Customer ===================");
			Console.Write("Account Number: ");
			bool isNum = int.TryParse(Console.ReadLine(), out int accNum);
			Console.Write("Customer ID: ");
			bool isCus = int.TryParse(Console.ReadLine(), out int cusId);

			Account? account = db.Accounts.FirstOrDefault(n => n.AccountNumber == accNum);

			if (account == null)
			{
				Console.WriteLine("This account number does not exist");
				return;
			}
			;

			Customer? customer = db.Customers.FirstOrDefault(n => n.CustomerID == cusId);
			if (customer == null)
			{
				Console.WriteLine("This customer ID does not exist");
				return;
			}
			;

			CustomerAccount? cusAcc = db.CustomerAccounts.Find(accNum, cusId);
			if (cusAcc == null)
			{
				Console.WriteLine("There is no a linked account between these both account number and customer ID");
				return;
			}

			db.CustomerAccounts.Remove(cusAcc);
			db.SaveChanges();
			Console.WriteLine($"Account number {accNum} has been deleted successfully from Customer ID: {cusId}");


		}
		static void ListCustomers(AppDbContext db)
		{
			Console.WriteLine("=============== All Customers ===============");
			var cus = db.Customers.Include(n=>n.CustomerAccounts).ThenInclude(n=>n.Account).ThenInclude(n=>n.Branch);

			foreach (var item in cus)
			{
				Console.WriteLine($"#{item.CustomerID} | {item.CustomerFullName} ({item.CustomerType})\n");


				if (item.CustomerAccounts.FirstOrDefault(n => n.CustomerID == item.CustomerID) == null)
				{
					Console.WriteLine("Customer has no accounts\n--------------------------------------");
				}
				else
				{

					var accounts = item.CustomerAccounts.Where(n=>n.CustomerID==item.CustomerID).Select(n=>n.Account);
					foreach (var acc in accounts)
					{
						Console.WriteLine($"Current Balance: {acc.CurrentBalance} | Account Type: {acc.AccountType} | Account Status: {item.CustomerAccounts.FirstOrDefault(n=>n.AccountNumber==acc.AccountNumber)?.AccountStatus}  | Branch Name: {acc.Branch.BranchName}\n------------------ ");
					}

				} 



			}
		}
		#endregion
	}
}
