# Users Management Application

This is an ASP.NET Core MVC application for managing Users, Students, and Teachers.

## API Endpoints (Localhost URLs)

Assuming the app runs on `https://localhost:7215`.

- **GET https://localhost:7215/Users/Add**: Form to add a new user.
- **GET https://localhost:7215/Users/Get**: View list of users.
- **GET https://localhost:7215/Students/Add**: Form to add a new student.
- **GET https://localhost:7215/Students/Get**: View list of students.
- **GET https://localhost:7215/Teachers/Add**: Form to add a new teacher.
- **GET https://localhost:7215/Teachers/Get**: View list of teachers.

## Notes

- POST requests are handled via the forms on the Add pages.
- Data is not persisted; it's handled in-memory.

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
