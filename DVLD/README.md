# DVLD - Desktop Solution (Windows Forms)

## Solution description

`DVLD` is a Windows desktop application implemented with Windows Forms and a layered architecture (UI, Business Layer, Data Layer, DTO). The solution targets .NET Framework 4.7.2 / 4.8 and is intended for on-premise use with a SQL Server-compatible database backend. It provides user and sitting management features and includes event logging for diagnostics.

## Features

- Driving License Management System (create, read, update, delete)
- Detailed user info forms and dialogs 
- Detailed Local Driving licenses Managemnet info forms and dialogs 
- Detailed International Driving licenses Managemnet info forms and dialogs 
- Detailed Detain and Release Driving licenses Managemnet info forms and dialogs 
- Test and appointment management features 
- - Data access layer (DAL) and DTOs for separation of concerns
- Event logging for runtime diagnostics

## Prerequisites / Dependencies

- Windows 10 or later
- Visual Studio 2019 or 2022 with the ".NET desktop development" workload
- .NET Framework 4.7.2 and/or 4.8 developer targeting packs (installed by Visual Studio workload)
- SQL Server 2012 or newer (SQL Server Express or LocalDB are supported for development)
- SQL Server Management Studio (SSMS) or `sqlcmd` for database restore / script execution

NuGet packages used by projects will be restored automatically by Visual Studio when the solution is opened.

## Important: Event Log and Administrator privileges

Run Visual Studio as Administrator the first time you open and run the solution. The application creates Event Log source(s) on first run; creating Event Log sources requires administrative privileges. If you do not run as Administrator the first time, Event Log write attempts may fail at runtime.

## Database setup

The application requires a SQL Server-compatible database. This repository may include a database backup or data files in the DVLD project folder. Follow the appropriate instructions below to restore or create the database.

1) Restore database from a backup file (recommended if `*.bak` is provided)

- Locate the backup file in the repository (look under the DVLD project root or a `Database/`, `DbBackup/`, or `sql/` folder). Typical names include `DVLD.bak` or similar.
- Using SQL Server Management Studio (SSMS):
  - Connect to your SQL Server instance
  - Right-click `Databases` -> `Restore Database...`
  - Choose `Device` -> `Add` -> select the `.bak` file from the project folder
  - Specify the target database name (e.g., `DVLD.bak`) and complete the restore
- Using `sqlcmd` (example):
  ```powershell
  sqlcmd -S .\SQLEXPRESS -E -Q "RESTORE DATABASE DVLD_DB FROM DISK='C:\path\to\DVLD.bak' WITH REPLACE"
  ```
  Replace the path and server instance as needed.

2) Attach MDF / LDF data files (if `.mdf`/`.ldf` are provided)

- In SSMS: right-click `Databases` -> `Attach...` -> `Add` -> select the `.mdf` file from the project folder
- Ensure the database files are accessible to the SQL Server service account


Connection string configuration

- The Windows Forms startup project's `App.config` contains the connection string used at runtime (it becomes `YourApp.exe.config` after build). Open the startup project (the UI project) and update the `<connectionStrings>` entry.

Example connection strings:

- LocalDB (development):
  ```xml
  <add name="DVLDConnection" connectionString="Server=(localdb)\\MSSQLLocalDB;Database=DVLD_DB;Trusted_Connection=True;" providerName="System.Data.SqlClient" />
  ```
- SQL Server Express:
  ```xml
  <add name="DVLDConnection" connectionString="Server=.\\SQLEXPRESS;Database=DVLD_DB;Trusted_Connection=True;" providerName="System.Data.SqlClient" />
  ```
- SQL Server (SQL Authentication):
  ```xml
  <add name="DVLDConnection" connectionString="Server=SERVER_NAME;Database=DVLD_DB;User Id=sa;Password=YourPassword;" providerName="System.Data.SqlClient" />
  ```

- Confirm the `name` value (`DVLDConnection` above) matches what the Data Layer expects. Search the Data Layer for `ConfigurationManager.ConnectionStrings` or the literal key to confirm.

Security note: do not commit production credentials to source control. Prefer Integrated Security (trusted connection) in development and secure secrets for production.

Running initial scripts / migrations

- If the project uses a migration framework (Entity Framework Migrations, FluentMigrator, etc.), follow the framework-specific commands in its documentation or repo README.
- If no migration framework is present, locate SQL scripts in the repository and run them in SSMS or using `sqlcmd` against the restored/created database.

Example `sqlcmd` execution:

```powershell
sqlcmd -S .\SQLEXPRESS -i .\sql\init-schema.sql -d DVLD_DB
```

## How to build and run

1. Open `DVLD.sln` in Visual Studio (2019 or 2022 recommended).
2. Restore NuGet packages if prompted.
3. Run Visual Studio as Administrator the first time to allow Event Log source creation.
4. Set the UI project (Windows Forms) as the startup project.
5. Ensure the `App.config` of the startup project has the correct connection string for your environment.
6. Build the solution: `Build` -> `Build Solution`.
7. Run (F5) to debug or Ctrl+F5 to run without debugging.

Note: This is a .NET Framework desktop solution; the `dotnet` CLI is not used to build/run.

## Usage examples
-Run the Application and enter UserName 'Admin' and Password '123456789' to log into the System. (This is a default user account for testing purposes; change or remove in production.)
- Start the application and open the `Main Menue` screen (`FormMainMenueForm`) to view and manage System Driving License Management System.
- Navigate to `People` -> `Manage People` (`FormPeople`) to view the list of People in the System. You can edit existing People by selecting a Person and clicking `Edit`, or delete users by clicking `Delete`.
- Click `Add` to open the `FormAddNewPerson` form and create a Person. Fill in required fields and save.
- From `MainMenue Form` Use `Menue Strip bar` -`Application` -`Manage Application`-`Local Driving License Application` manage Local Driving License Application records and Take the Tests to Issue Your License For the First Time
- Typical flow:
  1. Launch the app
  2. Authenticate (if authentication is required)
  3. Open `People` -> Add / Edit / Delete People
  4. Verify changes in the UI and database

For specific field names, validations, or business rules, inspect the Business Layer classes such as `clsUsers`, `clsPeople`, and `clsDVLDSittings`.

## Troubleshooting

- Event Log permission errors: close Visual Studio and re-open as Administrator, then run the app once so Event Log sources can be created.
- Database connection errors: verify the connection string in `App.config`, ensure SQL Server is running, and the database exists and is accessible.
- Missing NuGet packages: restore packages from Visual Studio's NuGet Package Manager.

## Important notes and warnings

- Do not commit sensitive credentials to the repository.
- Back up any production data before running scripts that modify or drop data.
- Ensure proper permissions for SQL Server service account if attaching database files.
- Confirm which project is the startup project before running (the startup project's `App.config` is used at runtime).

## Contributing

- To contribute, fork the repository and submit a pull request. Open issues for bugs or feature requests. Follow repository code style and testing practices when contributing.

---

If you need the README to reference a specific backup filename or include exact script names present in the DVLD project folder, tell me the filename(s) or I can scan the repository and update the README with exact paths.