# BikeStore

A sample .NET 10 solution demonstrating centralized NuGet package management and modern project structure.

## Features
- .NET 10 projects
- Centralized NuGet package version management using `Directory.Packages.props`
- Clean separation of API, Application, Domain, and Infrastructure layers

## Projects
- **BikeStore.Api**: ASP.NET Core Web API
- **BikeStore.Application**: Application logic
- **BikeStore.Domain**: Domain models and interfaces
- **BikeStore.Infrastructure**: Data access and external integrations

## Centralized Package Management
All NuGet package versions are managed in the `Directory.Packages.props` file at the solution root. Project files reference packages without specifying versions.

## Getting Started
1. Clone the repository:
   ```sh
   git clone https://github.com/ravi-vishwakarma-hash/BikeStore.git
   ```
2. Open the solution in Visual Studio 2026 or later.
3. Build and run the solution.

## Requirements
- .NET 10 SDK
- Visual Studio 2026 or later

## License
MIT