# Minimal API Demo

A modern, production-ready ASP.NET Core Minimal API demonstration project built with .NET 10, showcasing best practices for API development.

## 🎯 Overview

This project demonstrates a clean, scalable architecture for building RESTful APIs using ASP.NET Core Minimal APIs with:

- **Generic Repository Pattern** for data access
- **Feature-Based Architecture** for organization
- **Comprehensive Validation** with error handling
- **OpenAPI/Swagger Integration** for API documentation
- **API Versioning** support
- **OpenTelemetry** for observability and monitoring
- **Typed Responses** following .NET 10 best practices

## 🏗️ Architecture

### Project Structure

```
Features/
 └── Users/
      ├── Create/
      │   └── CreateUserHandler.cs
      ├── GetAll/
      │   └── GetAllUsersHandler.cs
      ├── GetById/
      │   └── GetByIdUserHandler.cs
      ├── Update/
      │   └── UpdateUserHandler.cs
      └── Delete/
          └── DeleteUserHandler.cs

Data/
 ├── IEntity.cs              # Entity interface contract
 ├── Repository.cs           # Generic repository base class
 ├── UserRepository.cs       # User-specific repository
 └── UserSeeder.cs           # Initial data seeding

Services/
 ├── Abstractions/
 │   └── IGuidGenerator.cs   # GUID generation contract
 └── SequentialGuidGenerator.cs # Version 7 sequential GUID generation

Models/
 ├── User.cs                 # User entity with validation
 ├── CreateUserRequest.cs    # DTO with validation
 └── UpdateUserRequest.cs    # Update DTO with validation

Validators/
 └── UserValidator.cs        # Validation logic

Endpoints/
 └── UserEndpoints.cs        # Route configuration and mapping

Telemetry/
 └── OpenTelemetryExtensions.cs  # Observability setup

Program.cs                   # Application configuration
MinimalApiDemo.csproj        # Project file
```

## 🚀 Getting Started

### Prerequisites

- .NET 10 SDK or later
- Visual Studio 2026 (or any compatible IDE)
- PowerShell or Command Prompt

### Installation

1. Clone the repository:
```bash
git clone https://github.com/yourusername/MinimalApiDemo.git
cd MinimalApiDemo
```

2. Restore NuGet packages:
```bash
dotnet restore
```

3. Build the project:
```bash
dotnet build
```

4. Run the application:
```bash
dotnet run
```

The API will be available at `https://localhost:7000` (or your configured port).

## 📚 API Endpoints

All endpoints are versioned under `/api/v1/users` and fully documented in Swagger.

### Base URL
```
https://localhost:7000/api/v1/users
```

### Endpoints

#### 1. Get All Users
```http
GET /api/v1/users
```
**Response:** `200 OK`
```json
[
  {
    "id": "11111111-1111-1111-1111-111111111111",
    "name": "Maqbul",
    "email": "maqbul@gmail.com"
  },
  {
    "id": "22222222-2222-2222-2222-222222222222",
    "name": "Ahmed",
    "email": "ahmed@gmail.com"
  }
]
```

#### 2. Get User by ID
```http
GET /api/v1/users/{id}
```
**Parameters:**
- `id` (guid, required) - User ID

**Response:** `200 OK` or `404 Not Found`
```json
{
  "id": "11111111-1111-1111-1111-111111111111",
  "name": "Maqbul",
  "email": "maqbul@gmail.com"
}
```

#### 3. Create User
```http
POST /api/v1/users
Content-Type: application/json

{
  "name": "John Doe",
  "email": "john@example.com"
}
```

**Request Validation:**
- `name` - Required, 2-100 characters
- `email` - Required, valid email format

**Response:** `201 Created` or `400 Bad Request`
```json
{
  "id": "33333333-3333-3333-3333-333333333333",
  "name": "John Doe",
  "email": "john@example.com"
}
```

#### 4. Update User
```http
PUT /api/v1/users/{id}
Content-Type: application/json

{
  "name": "Updated Name",
  "email": "updated@example.com"
}
```

**Parameters:**
- `id` (guid, required) - User ID

**Request Validation:**
- `name` - Required, 2-100 characters
- `email` - Required, valid email format

**Response:** `200 OK`, `404 Not Found`, or `400 Bad Request`
```json
{
  "id": "11111111-1111-1111-1111-111111111111",
  "name": "Updated Name",
  "email": "updated@example.com"
}
```

#### 5. Delete User
```http
DELETE /api/v1/users/{id}
```
**Parameters:**
- `id` (guid, required) - User ID

**Response:** `204 No Content` or `404 Not Found`

## 🔧 Key Features

### 1. Generic Repository Pattern
- Reusable `Repository<T>` base class for any entity
- `IEntity` interface contract with `Guid` identity
- Easy to extend for other models

### 2. Sequential GUID Generation
- `IGuidGenerator` abstraction for creating IDs
- `SequentialGuidGenerator` uses `Guid.CreateVersion7()`
- Every new entity can receive a database-friendly time-ordered GUID

### 3. Feature-Based Architecture
- Organized by business features (Users)
- Each operation has its own handler
- Easy to locate and maintain feature code
- Scalable for adding new features

### 4. Comprehensive Validation
- Data annotations on entities
- Custom validation logic in handlers
- Detailed error messages
- Type-safe validation

### 5. Typed API Responses
- `.Produces<T>()` declarations
- Explicit HTTP status codes
- OpenAPI schema generation
- Better IDE support and documentation

### 6. API Versioning
- Routes support `/api/v1/` prefix
- Ready for future versions (`/api/v2/`, etc.)
- Backward compatibility support

### 7. Swagger/OpenAPI Documentation
- Interactive API documentation
- Try-it-out functionality
- Schema validation
- Accessible at application root (`/`)

### 8. OpenTelemetry Integration
- Distributed tracing support
- Metrics collection
- Structured logging
- Console exporter for development
- Easy to add Jaeger, Datadog, etc. exporters

### 9. Data Seeding
- Separate `UserSeeder` class
- Clean initial data setup
- Easy to extend with more seed data

## 🛠️ Technologies Used

- **.NET 10** - Latest .NET runtime
- **ASP.NET Core** - Web framework
- **Minimal APIs** - Lightweight API routing
- **OpenAPI/Swagger** - API documentation
- **OpenTelemetry** - Observability
- **Data Annotations** - Validation
- **Records** - Immutable data structures

## 📦 NuGet Packages

| Package | Version | Purpose |
|---------|---------|---------|
| Microsoft.AspNetCore.OpenApi | 10.0.7 | OpenAPI support |
| Swashbuckle.AspNetCore | 10.1.7 | Swagger/OpenAPI UI |
| OpenTelemetry | 1.15.1 | Observability framework |
| OpenTelemetry.Exporter.Console | 1.15.1 | Console telemetry export |
| OpenTelemetry.Extensions.Hosting | 1.15.1 | Hosting extensions |
| OpenTelemetry.Instrumentation.AspNetCore | 1.15.1 | ASP.NET Core tracing |
| OpenTelemetry.Instrumentation.Http | 1.15.1 | HTTP client tracing |

## 🔍 Swagger UI

Access the interactive API documentation at:
```
https://localhost:7000
```

Features:
- View all endpoints with descriptions
- Test endpoints directly from the browser
- View request/response schemas
- See validation rules
- Try different scenarios

## 📊 Observability

The project includes OpenTelemetry integration for monitoring:

### Traces
- HTTP request tracing
- Automatic ASP.NET Core instrumentation
- Console output in development

### Metrics
- Request metrics
- Performance monitoring
- Extensible for custom metrics

### Logs
- Structured logging
- OpenTelemetry integration
- Development console output

## 🔐 Validation Examples

### Valid User Creation/Update
```json
{
  "name": "John Doe",
  "email": "john@example.com"
}
```

### Invalid Examples (Will Return 400 Bad Request)

**Empty name:**
```json
{
  "name": "",
  "email": "john@example.com"
}
```
Error: "Name must be between 2 and 100 characters"

**Invalid email:**
```json
{
  "name": "John Doe",
  "email": "invalid-email"
}
```
Error: "Email must be a valid email address"

**Missing required field:**
```json
{
  "name": "John Doe"
}
```
Error: "Email is required"

### User Not Found (404)
```http
PUT /api/v1/users/99999999-9999-9999-9999-999999999999
```
Response: `404 Not Found`
```json
{
  "message": "User not found"
}
```

## 🚀 Extending the Project

### Adding a New Feature

1. Create a new feature folder structure:
```
Features/Products/
├── Create/CreateProductHandler.cs
├── GetAll/GetAllProductsHandler.cs
├── GetById/GetByIdProductHandler.cs
└── Delete/DeleteProductHandler.cs
```

2. Create the entity model:
```csharp
public record Product(Guid Id, string Name, decimal Price) : IEntity;
```

3. Create the repository:
```csharp
public class ProductRepository : Repository<Product>
{
    // Initialize with seed data
}
```

4. Create handlers following the pattern
5. Map endpoints in `ProductEndpoints.cs`
6. Register in `Program.cs`

### Adding a New API Version

1. Create v2 endpoints in `Endpoints/UserEndpointsV2.cs`
2. Update `Program.cs` to add both versions:
```csharp
app.MapUserEndpointsV1();
app.MapUserEndpointsV2();
```
3. Configure Swagger for multiple versions

### Adding Custom Exporters

Replace console exporter with production exporters (Jaeger, Datadog, Azure Monitor, etc.):

```csharp
.WithTracing(tracing => tracing
    .AddJaegerExporter(options => { /* config */ }))
```

## 📝 Development Guidelines

### Code Style
- Follow C# naming conventions
- Use records for immutable data structures
- Leverage built-in validation attributes
- Keep handlers focused and testable

### Adding Validation
- Use `System.ComponentModel.DataAnnotations` attributes
- Add custom validation in handlers if needed
- Return detailed error messages

### Response Handling
- Always declare `.Produces<T>()` for responses
- Include appropriate HTTP status codes
- Use typed `IResult` returns

## 🧪 Testing

The project is structured to be easily testable:

```csharp
// Mock UserRepository
var userId = Guid.CreateVersion7();
var mockRepo = new Mock<UserRepository>();
mockRepo.Setup(x => x.GetById(userId)).Returns(new User(userId, "Test", "test@example.com"));

// Test handler
var result = GetByIdUserHandler.Handle(userId, mockRepo.Object);
```

## 🐛 Troubleshooting

### Port Already in Use
Change the port in `launchSettings.json` or run:
```bash
dotnet run --urls=https://localhost:7001
```

### Package Restore Issues
```bash
dotnet nuget locals all --clear
dotnet restore
```

### Build Errors
Ensure you have .NET 10 SDK installed:
```bash
dotnet --version
```

## 📄 License

This project is provided as-is for educational and demonstration purposes.

## 🤝 Contributing

Contributions are welcome! Please follow the existing code structure and patterns.

## 📞 Support

For issues and questions, please check the project structure and refer to the API documentation available through Swagger UI.

---

**Target Framework:** .NET 10
**IDE:** Visual Studio Community 2026
**Status:** Production Ready ✅
