# BrewVerse Microservices

**Description:**
BrewVerse Microservices is a modular and scalable .NET Core Web API project that simulates a platform for managing and discovering different types of beers, breweries, and bars. The project is designed using microservices architecture to ensure maintainability, extensibility, and separation of concerns. It features a set of interconnected microservices, each responsible for specific aspects of beer, brewery, and bar management.

**Features:**
- Provides RESTful APIs for CRUD operations on beers, breweries, and bars.
- Allows linking and retrieving relationships between breweries and beers, as well as between bars and beers.
- Utilizes Entity Framework Core for data persistence and SQLite as the database engine.
- Implements Swagger for interactive API documentation and testing.
- Supports modularization with separate projects for each microservice.
- Adheres to SOLID principles to ensure clean and maintainable code.

## Microservices

1. **BeerService:** Manages different types of beers, including their names and alcohol content.
2. **BreweryService:** Handles breweries' information, focusing on their names.
3. **BarService:** Manages bars, including names and addresses, as well as the beers they serve.

**Technologies Used:**
- .NET Core
- Entity Framework Core
- SQLite
- Swashbuckle (Swagger)
- Microservices Architecture

## Usage

1. Clone this repository to your local development environment.
2. Open each microservice project in your preferred IDE (Visual Studio, Visual Studio Code, etc.).
3. Configure the database connection strings in the `appsettings.json` files.
4. Run the microservices to interact with the APIs and explore the provided functionality.
5. Use Swagger UI to test API endpoints and view documentation at `https://localhost:{port}/swagger`.
