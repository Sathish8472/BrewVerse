# BrewVerse Microservices Architecture

BrewVerse is a .NET Core Web API project that embodies microservices architecture for managing and serving different types of beer, their associated breweries, and bars. This project follows a clean and modular structure, leveraging microservices to enhance maintainability and scalability.

## Table of Contents

- [Architecture](#architecture)
- [Technologies](#technologies)
- [Project Structure](#project-structure)
- [Advantages](#advantages)
- [Usage](#usage)
- [Endpoints](#endpoints)
- [Getting Started](#getting-started)
- [Unit Tests](#unit-tests)
- [Future Extensions](#future-extensions)
- [Feedback](#feedback)

## Architecture

### Design Principles

The BrewVerse project follows several design principles, including:

- **Single Responsibility Principle (SRP)**: Each microservice has a clear and single responsibility, making the system more maintainable and easier to reason about.
- **Separation of Concerns**: The project separates concerns into different microservices, ensuring modularity and easier updates.
- **Dependency Injection**: Dependency Injection is used to manage dependencies and promote loose coupling between components.

### Microservice Architecture

The project is organized into several microservices:

- **BrewVerse.API**: This is the main API gateway responsible for handling client requests and routing them to the appropriate microservices.
- **BrewVerse.Abstractions**: Contains DTOs (Data Transfer Objects), helpers, and enums shared across microservices.
- **Brewery.Core**: Handles core business logic and data operations for breweries.
- **BeerService**: Manages beer-related operations.
- **BarService**: Manages bar-related operations.
- **BreweryService**: Manages brewery-related operations.
- **BrewVerse.Data**: Defines database contexts and data models.
- **BrewVerse.DependencyInjection**: Handles dependency injection for various services.

## Technologies

- .NET 6
- Entity Framework Core
- SQLite (for simplicity; other databases can be used)
- Swagger (for API documentation)
- xUnit (for unit testing)

## Project Structure

BrewVerse.API
- Controllers
- BeerController
- BarController
- BreweryController
- Services
IBeerServices
BeerServices
IBarServices
IBreweryServices
BreweryServices

BrewVerse.Abstractions
- DTO
- BeerDto
- BarDto
- BreweryDto
- Helpers
- Enums

Brewery.Core
- Data
- BeerDataService
- BarDataService
- BreweryDataService

BrewVerse.Data
- Context
- BrewVerseDbContext
- Extension
- ServiceCollectionExtension
- Models
- Beer
- Bar
- Brewery

BrewVerse.DependencyInjection
- Extension
- DependencyInjectionExtension
- Middleware


## Advantages

- **Modularity**: Microservices promote modularity, making it easier to maintain and extend the system.
- **Scalability**: Each microservice can be scaled independently based on demand.
- **Flexibility**: Different technologies and databases can be used for each microservice, providing flexibility in implementation.
- **Testability**: Microservices can be independently unit tested, ensuring reliability.

## Usage

To use BrewVerse, follow these steps:

1. Clone the repository to your local machine.
2. Open the solution in Visual Studio or your preferred IDE.
3. Build the solution to restore packages and dependencies.
4. Configure your database connection in `appsettings.json`.
5. Run the project using your IDE or `dotnet run`.

## Endpoints

### Beers

- POST /api/beer - Insert a single beer
- PUT /api/beer/{id} - Update a beer by ID
- GET /api/beer?gtAlcoholByVolume=5.0&ltAlcoholByVolume=8.0 - Get all beers with optional alcohol content filtering
- GET /api/beer/{id} - Get beer by ID

### Breweries

- POST /api/brewery - Insert a single brewery
- PUT /api/brewery/{id} - Update a brewery by ID
- GET /api/brewery - Get all breweries
- GET /api/brewery/{id} - Get brewery by ID

### Brewery Beers

- POST /api/brewery/beer - Insert a single brewery beer link
- GET /api/brewery/{breweryId}/beer - Get a single brewery by ID with associated beers
- GET /api/brewery/beer - Get all breweries with associated beers

### Bars

- POST /api/bar - Insert a single bar
- PUT /api/bar/{id} - Update a bar by ID
- GET /api/bar - Get all bars
- GET /api/bar/{id} - Get bar by ID

### Bar Beers

- POST /api/bar/beer - Insert a single bar beer link
- GET /api/bar/{barId}/beer - Get a single bar with associated beers
- GET /api/bar/beer - Get all bars with associated beers

## Getting Started

To get started with BrewVerse, follow these steps:

1. Clone the repository to your local machine.
2. Open the solution in Visual Studio or your preferred IDE.
3. Build the solution to restore packages and dependencies.
4. Configure your database connection in `appsettings.json`.
5. Run the project using your IDE or `dotnet run`.

## Unit Tests

BrewVerse includes unit tests to ensure the reliability of its components. You can run the tests using your IDE or the `dotnet test` command.

## Future Extensions

BrewVerse can be extended in various ways, including:

- Adding more endpoints for advanced beer, brewery, and bar management.
- Implementing authentication and authorization for secure access.
- Introducing caching mechanisms for improved performance.
- Integrating with external APIs or services for additional data sources.

## Feedback

Your feedback is valuable! If you have any suggestions, issues, or improvements for BrewVerse, please [open an issue](https://github.com/sathish8472/brewverse/issues) on GitHub.

Happy brewing with BrewVerse!
