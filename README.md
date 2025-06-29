# BankSystemWebAPI

A simple .NET 9 Web API for managing bank accounts, users, transactions, and transfer history. This project demonstrates a clean 3‑tier architecture with separation of concerns, asynchronous programming, and use of AutoMapper for DTO mapping.

## Table of Contents

* [Features](#features)
* [Architecture](#architecture)
* [Prerequisites](#prerequisites)
* [Getting Started](#getting-started)

  * [Clone the Repository](#clone-the-repository)
  * [Configure the Database](#configure-the-database)
  * [Restore the Database](#restore-the-database)
  * [Update Connection String](#update-connection-string)
  * [Run the API](#run-the-api)
* [Default User Credentials](#default-user-credentials)
* [Next Steps](#next-steps)
* [License](#license)

## Features

* CRUD operations for Users, Accounts, Transactions, and Transfer History
* Asynchronous controllers and services using `async`/`await`
* Dependency Injection with ASP.NET Core DI container
* Repository and Service layers for clean separation of concerns
* AutoMapper for mapping between Entities and DTOs

## Architecture

1. **WebAPI**: Controllers and endpoint definitions.
2. **Domain\_BLL**: Business Logic Layer (Services and DTOs).
3. **Infrastructure\_DAL**: Data Access Layer (EF Core DbContext and repository implementations).
4. **Database**: SQL Server `.bak` file for restoring the sample database.

## Prerequisites

* [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
* [SQL Server Express or Developer Edition](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
* [SQL Server Management Studio (SSMS)](https://docs.microsoft.com/sql/ssms/download-sql-server-management-studio-ssms)

## Getting Started

### Clone the Repository

```bash
git clone https://github.com/BilalMahfouf/BankSystemWebAPI.git
cd BankSystemWebAPI
```

### Configure the Database

1. Open SQL Server Management Studio.
2. Connect to your local SQL Server instance.

### Restore the Database

1. In SSMS, right-click on **Databases** and choose **Restore Database...**
2. Select **Device**, click **Browse**, and locate the `.bak` file in the **Database** folder of the repo.
3. Follow the prompts to restore the database (e.g., set target database name to `BankSystemDB`).

### Update Connection String

* Open `WebAPI/appsettings.json`.
* In the `ConnectionStrings` section, update the `DefaultConnection` value to point to your restored database. Example:

  ```json
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=BankSystemDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
  ```

### Run the API

```bash
dotnet build
dotnet run --project WebAPI/WebAPI.csproj
```

The API will start on `https://localhost:5001` (by default).

## Default User Credentials

* **Username**: `Admin`
* **Password**: `1234`

*These credentials can be used for any seeded admin user functionality.*


## Technologies Used
- **Architecture:** 3-tier architecture
- **Framework:** .NET Framework (C#)
- **Database:** Microsoft SQL Server with ADO.NET
- **User Interface:** Windows Forms (WinForms)

For any questions or feedback, please contact me at `billelmh501@gmail.com`.


## License

This project is licensed under the MIT License. See [LICENSE](LICENSE) for details.

