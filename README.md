# BZ Web Mobile Template

[![.NET](https://img.shields.io/badge/.NET-9.0-blue.svg)](https://dotnet.microsoft.com/download/dotnet/9.0)
[![Blazor](https://img.shields.io/badge/Blazor-Server%20%26%20MAUI-blueviolet.svg)](https://blazor.net/)
[![Radzen](https://img.shields.io/badge/Radzen-8.1.5-orange.svg)](https://blazor.radzen.com/)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-9.0.10-green.svg)](https://docs.microsoft.com/en-us/ef/)

A comprehensive **cross-platform Blazor application template** built for the **ANFLOVERSE ecosystem**. This solution provides both web and mobile (MAUI) applications sharing common business logic, UI components, and data access layers.

## ??? Architecture Overview

This is a **multi-project solution** designed for maximum code reusability across web and mobile platforms:

```
BZ_WebMobileTemplate/
??? BZ_WebMobileTemplate (MAUI)           # Cross-platform mobile app
??? BZ_WebMobileTemplate.Web             # Blazor Server web app  
??? BZ_WebMobileTemplate.Shared          # Shared components & logic
```

### Project Structure

| Project | Purpose | Target Framework |
|---------|---------|-----------------|
| **BZ_WebMobileTemplate** | MAUI Blazor hybrid app for mobile platforms | .NET 9.0 (Android, iOS, Windows, macOS) |
| **BZ_WebMobileTemplate.Web** | Blazor Server web application | .NET 9.0 |
| **BZ_WebMobileTemplate.Shared** | Shared Blazor components, data models, and services | .NET 9.0 |

## ?? Key Features

### ?? Cross-Platform Support
- **Web**: Blazor Server with real-time updates
- **Mobile**: .NET MAUI Blazor for native mobile experiences
- **Shared Codebase**: Maximum code reuse between platforms

### ?? Modern UI Framework
- **Radzen Blazor Components**: Professional UI component library
- **Responsive Design**: Mobile-first approach with adaptive layouts
- **Dark/Light Themes**: Built-in theme support
- **Material Design**: Modern, clean interface

### ?? Enterprise Features
- **Multi-Application Portal**: Unified access to ANFLOVERSE apps
- **Role-Based Access**: Identity management with ASP.NET Core Identity
- **Real-time Analytics**: Dashboard with charts and KPIs
- **Export Capabilities**: CSV/Excel export functionality

### ?? Business Applications
- **Function Management**: CRUD operations for system functions
- **Employee Clearance (EC Clear)**: Certificate processing
- **Capital Appropriation Request (CAR)**: Financial request management
- **Requisition Slip (RS)**: Resource request processing
- **ACCEDE**: Expense management system

## ??? Technology Stack

### Backend
- **.NET 9.0**: Latest .NET framework
- **Entity Framework Core 9.0**: Modern ORM with SQL Server support
- **ASP.NET Core Identity**: Authentication and authorization
- **Dependency Injection**: Built-in IoC container

### Frontend
- **Blazor Server & MAUI**: Modern web and mobile UI framework
- **Radzen Components**: Professional UI component library
- **Bootstrap 5**: Responsive CSS framework
- **Chart.js Integration**: Data visualization

### Database
- **SQL Server**: Primary database engine
- **Entity Framework Migrations**: Database schema management
- **Connection Pooling**: Optimized database connections

### Development Tools
- **Hot Reload**: Fast development iteration
- **IntelliSense**: Rich code completion
- **Debugging**: Full debugging support across platforms

## ?? Getting Started

### Prerequisites
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/) (LocalDB or full instance)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/ANFLOCOR-DEVAPPS/BZ_WebMobileTemplate.git
   cd BZ_WebMobileTemplate
   ```

2. **Configure Database Connection**
   
   Update the connection string in `BZ_WebMobileTemplate.Web/appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BZ_WebMobileTemplate;Trusted_Connection=true;MultipleActiveResultSets=true"
     }
   }
   ```

3. **Apply Database Migrations**
   ```bash
   cd BZ_WebMobileTemplate.Web
   dotnet ef database update
   ```

4. **Run the Web Application**
   ```bash
   dotnet run --project BZ_WebMobileTemplate.Web
   ```

5. **Run the MAUI Application**
   ```bash
   dotnet run --project BZ_WebMobileTemplate --framework net9.0-windows10.0.19041.0
   ```

## ?? Project Architecture

### Shared Components (`BZ_WebMobileTemplate.Shared`)

```
Components/
??? ECClearPages/          # Employee Clearance modules
??? SharedComponents/      # Reusable UI components
??? UProPages/            # User Profile and Function management
??? Layout/               # Layout components

Data/
??? ApplicationDbContext.cs    # Entity Framework context
??? ApplicationUser.cs         # Identity user model
??? UPRO_S_Function.cs        # Function data model

Repositories/
??? IRepository/              # Repository interfaces
??? FunctionRepository.cs     # Database repository
??? HttpFunctionRepository.cs # HTTP API repository

Services/
??? IFormFactor.cs           # Platform detection service
```

### Web Application (`BZ_WebMobileTemplate.Web`)
- **Blazor Server**: Real-time web application
- **Entity Framework**: Direct database access
- **Authentication**: Cookie-based authentication

### MAUI Application (`BZ_WebMobileTemplate`)
- **Hybrid App**: Native mobile with Blazor UI
- **HTTP Client**: API-based data access
- **Platform Services**: Device-specific implementations

## ?? UI Components & Features

### Dashboard
- **Analytics Cards**: Key performance indicators
- **Charts**: Revenue, progress, and trend visualization  
- **App Launcher**: Quick access to ANFLOVERSE applications

### Data Management
- **Advanced Grid**: Sorting, filtering, paging, and selection
- **CRUD Operations**: Create, read, update, delete functionality
- **Export**: CSV and Excel export capabilities
- **Search**: Real-time search across data

### Form Components
- **Validation**: Client and server-side validation
- **Rich Controls**: Date pickers, dropdowns, text areas
- **Responsive**: Mobile-optimized form layouts

## ?? Development Patterns

This project follows established patterns for rapid development:

### Repository Pattern
```csharp
// Interface definition
public interface IFunctionRepository
{
    Task<IEnumerable<UPRO_S_Function>> GetAllAsync();
    Task<UPRO_S_Function?> GetByIdAsync(int id);
    Task<bool> CreateAsync(UPRO_S_Function function);
    Task<bool> UpdateAsync(UPRO_S_Function function);
    Task<bool> DeleteAsync(int id);
}

// Implementation for web (Entity Framework)
public class FunctionRepository : IFunctionRepository
{
    private readonly ApplicationDbContext _context;
    // Implementation using EF Core
}

// Implementation for mobile (HTTP client)
public class HttpFunctionRepository : IFunctionRepository  
{
    private readonly HttpClient _httpClient;
    // Implementation using HTTP API calls
}
```

### Dependency Injection
```csharp
// Web (Program.cs)
builder.Services.AddScoped<IFunctionRepository, FunctionRepository>();

// MAUI (MauiProgram.cs)  
builder.Services.AddScoped<IFunctionRepository, HttpFunctionRepository>();
```

### AI-Assisted Development
This project includes an [AI Prompt Guide](BZ_WebMobileTemplate.Shared/AI_Prompt_Guide.md) for rapid development using AI tools to generate:
- Data models with proper Entity Framework annotations
- Repository interfaces and implementations
- Blazor UI components with CRUD operations
- Database context integration

## ?? Platform-Specific Features

### Web Application
- **Real-time Updates**: SignalR integration
- **Server-side Rendering**: Fast initial page loads
- **SEO Friendly**: Search engine optimization
- **Session Management**: Server-side session state

### Mobile Application  
- **Native Performance**: Platform-optimized rendering
- **Offline Capabilities**: Local data caching
- **Push Notifications**: Mobile notification support
- **Device Integration**: Camera, GPS, sensors

## ?? Security Features

- **Authentication**: ASP.NET Core Identity integration
- **Authorization**: Role-based access control
- **HTTPS**: Secure communication
- **CSRF Protection**: Cross-site request forgery protection
- **Input Validation**: Server and client-side validation

## ?? Sample Applications

### Function Management
Complete CRUD application demonstrating:
- List view with search, sort, and filter
- Add/Edit forms with validation
- Delete confirmation dialogs
- Export functionality

### Employee Clearance System
Workflow-based application for:
- Clearance request processing
- Approval workflows
- Document management
- Status tracking

## ?? Target Use Cases

- **Enterprise Applications**: Line-of-business applications
- **Portal Solutions**: Multi-application access points
- **Workflow Systems**: Business process automation
- **Mobile-First Apps**: Cross-platform mobile applications
- **Hybrid Solutions**: Combined web and mobile experiences

## ?? Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## ?? License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## ?? Support

- **Documentation**: [AI Prompt Guide](BZ_WebMobileTemplate.Shared/AI_Prompt_Guide.md)
- **User Guides**: [https://apps.anflocor.com/FAQUserGuides.aspx](https://apps.anflocor.com/FAQUserGuides.aspx)
- **Help Desk**: [https://helpdesk.anflocor.com/](https://helpdesk.anflocor.com/)
- **Feedback**: [Feedback Survey](https://forms.office.com/pages/responsepage.aspx?id=WMSxlctBm0icj7HVdkxg_W5qDcKLxDJCtyAP0SmfY_tUMFdCUURVRzI2SEYyMEdGU1BUQ1ZSWVlDNC4u&route=shorturl)

## ?? About ANFLO Group

**ANFLOVERSE** is the unified application ecosystem for ANFLO Group of Companies, providing integrated business solutions across multiple platforms and devices.

---

**Built with ?? by the ANFLOCOR IT Apps Dev Team**