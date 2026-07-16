# Bank Management System — EF Core Code-First

A console-based data layer and CRUD application for a fictional bank ("National Bank Group"), built with **Entity Framework Core (Code-First)** and **SQL Server**. This project models branches, managers, customers, accounts (including joint accounts), and transactions, and exposes an interactive console menu for managing customers and accounts.

## Overview

The National Bank Group operates multiple branches, each managed by one manager. Customers (individuals or businesses) can open one or more accounts, and accounts can be jointly owned by multiple customers (e.g., business partners sharing a savings account). Every account belongs to exactly one branch, and all transactions are tied to a specific account.

This project focuses purely on the **data layer** — entity modeling, relationships, migrations, and seed data — plus a console menu for performing core operations against that data.

## Tech Stack

- **.NET 8**
- **C#**
- **Entity Framework Core** (Code-First, Fluent API)
- **SQL Server**

## Entity Relationship Diagram

The schema is based on the following relationships:

- **Branch ↔ Manager** — One-to-One (each branch has exactly one manager)
- **Branch ↔ Account** — One-to-Many (a branch can have many accounts, each account belongs to one branch)
- **Customer ↔ Account** — Many-to-Many, modeled via an explicit join entity `CustomerAccount`, which carries additional attributes: `OwnerShipType` (Primary/Co-Holder), `AccountStatus` (Active/Closed), and `OwnerShipStartDate`
- **Account ↔ Transaction** — One-to-Many (each account has many transactions)

## Project Structure

```
├── Models/
│   ├── Branch.cs
│   ├── Manager.cs
│   ├── Customer.cs
│   ├── Account.cs
│   ├── CustomerAccount.cs   (join entity for Customer ↔ Account)
│   └── Transaction.cs
├── Enum/
│   ├── CustomerType.cs      (Individual / Business / Organization)
│   ├── OwnerShipType.cs     (Primary_Holder / Co_Holder)
│   └── AccountStatus.cs     (Active / Closed)
├── Configurations/
│   ├── BranchConfiguration.cs
│   ├── ManagerConfiguration.cs
│   ├── CustomerConfiguration.cs
│   ├── AccountConfiguration.cs
│   ├── CustomerAccountConfiguration.cs
│   └── TransactionConfiguration.cs
├── App_Context/
│   └── AppDbContext.cs
└── Program.cs                (console menu + operations)
```

## Key Design Decisions

- **Composite key on `CustomerAccount`** (`AccountNumber` + `CustomerID`) instead of a surrogate `Id` — since a given customer/account pairing is naturally unique and nothing else references this join record directly.
- **`AccountNumber` configured with `ValueGeneratedNever()`** — account numbers are assigned by the application/user rather than auto-generated as a database identity column.
- **Enums for closed, fixed-value fields** (`CustomerType`, `OwnerShipType`, `AccountStatus`), while `AccountType` and `TransactionType` are kept as `string` since the case study describes them as open-ended ("savings, current, business, etc.").
- **`decimal(18,2)` precision** explicitly set on all currency fields (`CurrentBalance`, `TransactionAmount`) to avoid silent truncation.

## Seeded Data

The database is seeded via `HasData()` in each configuration class with:
- 3 Branches
- 3 Managers
- 5 Customers (including one Business customer)
- 5 Accounts
- 6 CustomerAccount ownership records — including a genuine **joint account** (two customers sharing one business account, one as Primary Holder and one as Co-Holder)
- 7 Transactions across various accounts

## Console Menu

| Option | Action |
|--------|--------|
| 1 | Add a new Customer |
| 2 | Open a new Account for a Customer |
| 3 | Update Account Status (toggle Active/Closed) |
| 4 | Remove an Account from a Customer |
| 5 | List all Customers with their Accounts |
| 0 | Exit |

All inputs are validated (invalid entries show a friendly error and re-prompt instead of crashing), and the menu redraws with a "Press any key to return to the menu..." pause after each operation.

## Getting Started

1. Clone the repository
2. Update the connection string in `AppDbContext.cs` if needed (defaults to a local SQL Server instance with Windows Authentication)
3. Run the following in the Package Manager Console:
   ```
   Update-Database
   ```
4. Run the project — the seeded data will be available immediately, and the console menu will guide you through the rest.

## Challenges Faced

- **Identity column conflict**: `AccountNumber` was initially treated by EF Core's convention as an auto-generated identity column, which conflicted with the requirement that account numbers be manually assigned. Resolved with `ValueGeneratedNever()` and a fresh migration.
- **Composite key lookups**: Working with `CustomerAccount`'s composite primary key required using `Find(accountNumber, customerId)` with positional arguments rather than a single object.
- **Many-to-many traversal**: Listing each customer's accounts required `.Include().ThenInclude()` chains through the `CustomerAccount` join entity to reach both the ownership details and the underlying `Account` data.

## Notes

This project implements the data layer and console CRUD operations only, per the assignment scope. Automatic balance adjustment from transactions (deposits/withdrawals affecting `CurrentBalance`) is described in the business rules but is outside the scope of the required console menu operations for this version.
