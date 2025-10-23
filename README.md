# ToDo Management API

A Clean Architecture-based ASP.NET Core 8.0 Web API for managing todo tasks with CQRS pattern implementation.

## 🚀 Technologies Used

- **ASP.NET Core 8.0** - Web API Framework
- **Entity Framework Core 8.0.15** - ORM
- **SQL Server** - Database
- **MediatR 12.5.0** - CQRS Pattern Implementation
- **Mapster** - Object Mapping
- **FluentValidation** - Request Validation
- **JWT Authentication** - Security
- **Swagger/OpenAPI** - API Documentation

## 📋 Prerequisites

Before running this project, ensure you have the following installed:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Express or Developer Edition)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/) (optional)

## ⚙️ Setup Instructions

### 1. Clone the Repository

```bash
git clone <repository-url>
```

### 2. Configure Database Connection

Update the connection string in `ToDoMangament.ApI/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ToDoMangamentTodo;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

**Note:** Adjust the connection string based on your SQL Server configuration.

### 3. Apply Database Migrations

Navigate to the API project directory and run migrations:

```bash
cd ToDoMangament.ApI
dotnet ef database update --project ..\ToDoMangament.Persistence\ToDoMangament.Persistence.csproj
```

### 4. Build the Solution

```bash
dotnet build
```

### 5. Run the Application

```bash
cd ToDoMangament.ApI
dotnet run
```

The API will be available at:
- **HTTPS:** `https://localhost:7xxx`
- **HTTP:** `http://localhost:5xxx`

(Exact ports will be displayed in the console)

### 6. Access Swagger Documentation

Once the application is running, navigate to:
```
https://localhost:7xxx/swagger
```

## 🏗️ Project Architecture

The solution follows **Clean Architecture** principles with the following layers:

```
├── ToDoMangament.Domain        # Enterprise Business Rules (Entities, Interfaces)
├── ToDoMangament.Application   # Application Business Rules (Use Cases, CQRS)
├── ToDoMangament.Infrastructure # Infrastructure (Generic Repositories)
├── ToDoMangament.Persistence   # Data Access (EF Core, Database)
├── ToDoMangament.Presentation  # Controllers & API Endpoints
└── ToDoMangament.ApI          # Entry Point & Configuration
```

## 📚 API Endpoints

### Todo Management

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/TodoManagement/Todo/AddTodo` | Create a new todo |
| PUT | `/api/TodoManagement/Todo/EditTodo` | Update an existing todo |
| GET | `/api/TodoManagement/Todo/GetTodo` | Get all todos |
| GET | `/api/TodoManagement/Todo/GetTodoById` | Get todo by ID |
| PUT | `/api/TodoManagement/Todo/ToggleTodo` | Toggle todo status (Pending → InProgress → Completed) |

## 🎯 Features Implemented

### ✅ Core Features
- [x] **Todo CRUD Operations** - Create, Read, Update todos
- [x] **Status Management** - Pending, InProgress, Completed statuses
- [x] **Priority Levels** - Low, Medium, High priority assignment
- [x] **Due Date Tracking** - Optional due date for todos
- [x] **Toggle Status** - Cycle through status states

### ✅ Architecture & Patterns
- [x] **Clean Architecture** - Separation of concerns across layers
- [x] **CQRS Pattern** - Command/Query separation using MediatR
- [x] **Repository Pattern** - Generic repository with Unit of Work
- [x] **Specification Pattern** - Flexible query building
- [x] **Validation Pipeline** - Automatic request validation with FluentValidation

### ✅ Infrastructure
- [x] **Entity Framework Core** - Database access with migrations
- [x] **JWT Authentication** - Configured (ready for implementation)
- [x] **CORS Policy** - Configured for frontend integration
- [x] **Swagger Integration** - API documentation with JWT support
- [x] **Dependency Injection** - Proper service registration

### ✅ Code Quality
- [x] **Domain-Driven Design** - Rich domain entities with business logic
- [x] **Auditable Entities** - CreatedAt and LastModifiedDate tracking
- [x] **Object Mapping** - Automated mapping with Mapster
- [x] **Response Models** - Standardized API responses

## 🔧 Configuration

### JWT Settings

Located in `appsettings.json`:

```json
{
  "Jwt": {
    "Key": "ThisIsASecretKeyForJwtTokenDontShare",
    "Issuer": "ToDoMangamentAPI"
  }
}
```

**⚠️ Security Note:** Change the JWT key in production!

### CORS Policy

The API is configured to allow requests from:
- `http://localhost:4200` (Angular default port)

Modify in `Program.cs` to add more origins if needed.

## 🧩 Domain Model

### Todo Entity
```csharp
- Id (Guid)
- Title (string, required, max 100 chars)
- Description (string, optional)
- Status (Pending/InProgress/Completed)
- Priority (Low/Medium/High)
- DueDate (DateTime, optional)
- CreatedAt (DateTime)
- LastModifiedDate (DateTime)
```

## 🎓 What I Managed to Complete

1. **Full Clean Architecture Setup** - Properly separated domain, application, infrastructure, persistence, and presentation layers
2. **CQRS Implementation** - Complete command and query separation with MediatR
3. **Todo Management System** - All CRUD operations with business logic in domain entities
4. **Database Integration** - EF Core with SQL Server, including migrations
5. **Validation Pipeline** - Automatic validation using FluentValidation behaviors
6. **API Documentation** - Swagger/OpenAPI with JWT authentication support
7. **Repository Pattern** - Generic repository with specification pattern for flexible queries
8. **Unit of Work Pattern** - Transaction management across repositories
9. **JWT Infrastructure** - Authentication pipeline configured and ready
10. **CORS Configuration** - API ready for frontend integration

## 🤔 What I Found Challenging


###  **Architecture Complexity for Simple Features**
While Clean Architecture is excellent for large applications, it adds significant overhead for simple CRUD operations. Each feature requires:
- Command/Query classes
- Handlers
- Validators
- DTOs
- Multiple layers of abstraction




###  **Specification Pattern Complexity**
The specification pattern adds flexibility but increases complexity for simple queries. The learning curve for developers new to the pattern can be steep.

###  **Dual Infrastructure/Persistence Layers**
Having both `Infrastructure` and `Persistence` layers with overlapping responsibilities (both have repositories and unit of work) creates confusion about separation of concerns.

**Current State:** Both layers implement similar patterns, which is redundant.



---

