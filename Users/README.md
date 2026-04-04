# Users Management Application

An ASP.NET Core MVC app that manages Users, Students, Teachers, and Employees using EF Core with a MySQL database.

## Features

- MVC pages to add and list users, students, teachers, and employees.
- Server-side validation via model state checks.
- EF Core with Pomelo MySQL provider.
- Basic scaffolding for future expansion (controllers, views, migrations).

## Tech Stack

- ASP.NET Core MVC (.NET 10 target in build output)
- Entity Framework Core 9
- Pomelo.EntityFrameworkCore.MySql
- MySQL 8

## Packages

- Microsoft.EntityFrameworkCore (9.0.0)
- Microsoft.EntityFrameworkCore.Design (9.0.0)
- Microsoft.EntityFrameworkCore.Tools (9.0.0)
- Pomelo.EntityFrameworkCore.MySql (9.0.0)
- Npgsql.EntityFrameworkCore.PostgreSQL

## Local Development

### Prerequisites

- .NET SDK (compatible with the project target)
- MySQL 8.x running locally

### Configure Database

Update the connection string in [Users/appsettings.json](Users/appsettings.json) as needed:

```
Server=localhost;Database=Users_Db;User=root;Password=;Port=3306;
```

### Run the App

From the solution root:

```bash
dotnet run --project ./Users/Users.csproj
```

By default, the app listens on:

- HTTPS: https://localhost:7215
- HTTP: http://localhost:5253

## Endpoints (Localhost)

Assuming the app runs on `https://localhost:7215`.

- **GET /Users/Add**: Form to add a new user.
- **GET /Users/Get**: View list of users.
- **GET /Students/Add**: Form to add a new student.
- **GET /Students/Get**: View list of students.
- **GET /Teachers/Add**: Form to add a new teacher.
- **GET /Teachers/Get**: View list of teachers.
- **GET /Employees/Add**: Form to add a new employee.
- **GET /Employees/Get**: View list of employees.

## Database Migrations

Migrations are stored in [Users/Migrations](Users/Migrations). To create or apply migrations:

```bash
# Add a migration
dotnet ef migrations add <Name> --project ./Users/Users.csproj

# Apply migrations
dotnet ef database update --project ./Users/Users.csproj
```

## Notes

- POST requests are handled via the forms on the Add pages.
- Data is persisted to MySQL using EF Core.
- Controllers use `UsersDBcontext` for CRUD operations.

## Commands Used For EF Core Packages

```bash
# Initial command from solution root (failed: no project at root)
dotnet add package Microsoft.EntityFrameworkCore

# Add package by targeting the project file
dotnet add ./Users/Users.csproj package Microsoft.EntityFrameworkCore

# Add requested packages
dotnet add ./Users/Users.csproj package Microsoft.EntityFrameworkCore.Design
dotnet add ./Users/Users.csproj package Microsoft.EntityFrameworkCore.Tools
dotnet add ./Users/Users.csproj package Pomelo.EntityFrameworkCore.MySql

# Align versions for compatibility with Pomelo 9.0.0
dotnet add ./Users/Users.csproj package Microsoft.EntityFrameworkCore --version 9.0.0
dotnet add ./Users/Users.csproj package Microsoft.EntityFrameworkCore.Design --version 9.0.0
dotnet add ./Users/Users.csproj package Microsoft.EntityFrameworkCore.Tools --version 9.0.0

# Restore
dotnet restore ./Users/Users.csproj
```
