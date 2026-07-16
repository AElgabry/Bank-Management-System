using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFC_Project.Migrations
{
    /// <inheritdoc />
    public partial class ReStart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchCode);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerDateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmailAddress = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerType = table.Column<int>(type: "int", nullable: false),
                    CustomerNationalID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    CurrentBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpeningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BranchCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountNumber);
                    table.ForeignKey(
                        name: "FK_Accounts_Branches_BranchCode",
                        column: x => x.BranchCode,
                        principalTable: "Branches",
                        principalColumn: "BranchCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    ManagerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManagerFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ManagerPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BranchCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.ManagerID);
                    table.ForeignKey(
                        name: "FK_Managers_Branches_BranchCode",
                        column: x => x.BranchCode,
                        principalTable: "Branches",
                        principalColumn: "BranchCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAccounts",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    OwnerShipType = table.Column<int>(type: "int", nullable: false),
                    AccountStatus = table.Column<int>(type: "int", nullable: false),
                    OwnerShipStartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAccounts", x => new { x.AccountNumber, x.CustomerID });
                    table.ForeignKey(
                        name: "FK_CustomerAccounts_Accounts_AccountNumber",
                        column: x => x.AccountNumber,
                        principalTable: "Accounts",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAccounts_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionNumber);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_AccountNumber",
                        column: x => x.AccountNumber,
                        principalTable: "Accounts",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchCode", "BranchAddress", "BranchName", "BranchPhoneNumber" },
                values: new object[,]
                {
                    { 1, "12 Corniche St, Alexandria", "Alexandria Main", "0345678901" },
                    { 2, "45 Tahrir Sq, Cairo", "Cairo Downtown", "0223456789" },
                    { 3, "8 Pyramids Rd, Giza", "Giza Branch", "0233445566" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "CustomerAddress", "CustomerDateOfBirth", "CustomerEmailAddress", "CustomerFullName", "CustomerNationalID", "CustomerPhoneNumber", "CustomerType" },
                values: new object[,]
                {
                    { 1, "3 Smouha St, Alexandria", new DateTime(1995, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "youssef.hany@mail.com", "Youssef Hany", "29505121234567", "01055512345", 1 },
                    { 2, "7 Sidi Gaber, Alexandria", new DateTime(1990, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "nour.tarek@mail.com", "Nour ElDin Tarek", "29011031234567", "01166654321", 1 },
                    { 3, "22 Nasr City, Cairo", new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contact@deltatrading.com", "Delta Trading Co.", "10000000000001", "0224455667", 2 },
                    { 4, "5 Dokki, Giza", new DateTime(1998, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "salma.reda@mail.com", "Salma Reda", "29808221234567", "01234567890", 1 },
                    { 5, "9 Agouza, Giza", new DateTime(1988, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "omar.fathy@mail.com", "Omar Fathy", "28804091234567", "01187654321", 1 }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountNumber", "AccountType", "BranchCode", "CurrentBalance", "OpeningDate" },
                values: new object[,]
                {
                    { 1001, "Savings", 1, 15500.00m, new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1002, "Current", 1, 8200.50m, new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1003, "Business", 2, 250000.00m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1004, "Savings", 3, 5000.00m, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1005, "Current", 2, 30250.75m, new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "ManagerID", "BranchCode", "EmailAddress", "HireDate", "ManagerFullName", "ManagerPhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, "ahmed.salah@natbank.com", new DateTime(2019, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ahmed Salah", "01012345678" },
                    { 2, 2, "mona.farouk@natbank.com", new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mona Farouk", "01098765432" },
                    { 3, 3, "karim.adel@natbank.com", new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karim Adel", "01123456789" }
                });

            migrationBuilder.InsertData(
                table: "CustomerAccounts",
                columns: new[] { "AccountNumber", "CustomerID", "AccountStatus", "OwnerShipStartDate", "OwnerShipType" },
                values: new object[,]
                {
                    { 1001, 1, 1, new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 1002, 1, 1, new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 1003, 3, 1, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 1003, 4, 1, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 1004, 4, 1, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 1005, 5, 2, new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionNumber", "AccountNumber", "TransactionAmount", "TransactionDate", "TransactionNote", "TransactionType" },
                values: new object[,]
                {
                    { 1, 1001, 2000.00m, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salary deposit", "Deposit" },
                    { 2, 1001, 500.00m, new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "ATM withdrawal", "Withdrawal" },
                    { 3, 1002, 1200.50m, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Utility bill", "Payment" },
                    { 4, 1003, 50000.00m, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Client payment received", "Deposit" },
                    { 5, 1003, 10000.00m, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transfer to supplier", "Transfer" },
                    { 6, 1004, 1000.00m, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash deposit", "Deposit" },
                    { 7, 1005, 250.75m, new DateTime(2024, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grocery shopping", "Withdrawal" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_BranchCode",
                table: "Accounts",
                column: "BranchCode");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccounts_CustomerID",
                table: "CustomerAccounts",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerEmailAddress",
                table: "Customers",
                column: "CustomerEmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerNationalID",
                table: "Customers",
                column: "CustomerNationalID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Managers_BranchCode",
                table: "Managers",
                column: "BranchCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Managers_EmailAddress",
                table: "Managers",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountNumber",
                table: "Transactions",
                column: "AccountNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAccounts");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Branches");
        }
    }
}
