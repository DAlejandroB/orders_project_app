# Orders Project App

An order management application designed to handle clients, stock items, and order processing. This project demonstrates backend architecture using C# and .NET, with a modular design for scalability and maintainability.

## Tech Stack
- Backend: C# (.NET 8+)
- Database: Entity Framework Core (Code First Migrations)
- Architecture: Repository pattern with layered controllers, models, DTOs, and custom exceptions

## Features (Current)
- Client management (CRUD)
- Stock item management (inventory with quantities)
- Order creation and processing
- Custom exceptions for entity not found and insufficient stock
- Database migrations with EF Core
- Modular repository pattern for data access

## Planned Enhancements
- Authentication and authorization for user roles
- Frontend integration (React or Angular)
- Detailed reporting for sales and inventory
- Docker support for containerized deployment
- Unit and integration testing
