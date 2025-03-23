# Logicommerce

**Logicommerce** is a multi-layered e-commerce project built using .NET 9, incorporating Clean Architecture principles. The project utilizes a variety of modern tools and technologies to ensure flexibility, scalability, and maintainability.

## Features

- **Multi-layered Architecture**: Built with a focus on Clean Architecture, separating concerns into distinct layers for better organization and maintainability.
- **CQRS & Mediator**: Implements Command Query Responsibility Segregation (CQRS) pattern using Mediator for seamless communication between components.
- **Entity Framework Core In-Memory Database**: Uses EF Core with an in-memory database for development and testing, allowing for quick and easy data manipulation without needing a persistent database.
- **Generic Repository & Unit of Work**: Implements reusable generic repository and unit of work patterns for data access, providing a clean separation of concerns.
- **Ardalis Specification**: Uses the Ardalis Specification pattern to encapsulate business logic and queries in a clean and reusable way.
- **Fluent Validation**: Validates input models using FluentValidation, ensuring that the data adheres to defined business rules.
- **AutoMapper**: Automates object-to-object mapping to reduce boilerplate code and streamline data transformation.
- **Seed Data**: Contains seed data to populate the application with initial data for testing and development purposes.
- **Swagger**: Provides an interactive API documentation for frontend and backend communication.
- **Unit Tests**: Implements unit tests using xUnit and Moq for mock dependencies, ensuring the project is robust and maintainable.

## Technologies Used

- **.NET 9**
- **Entity Framework Core (In-Memory Database)**
- **MediatR** (for CQRS pattern)
- **FluentValidation**
- **AutoMapper**
- **Ardalis Specification**
- **Swagger**
- **xUnit & Moq** (for unit testing)

## Installation

To get started with the project locally, follow the steps below:

### Prerequisites

- .NET 9 SDK
- Visual Studio or Visual Studio Code
- Git

### Steps

1. Clone the repository to your local machine:

    ```bash
    git clone https://github.com/yourusername/logicommerce.git
    ```

2. Navigate to the project directory:

    ```bash
    cd logicommerce
    ```

3. Restore the dependencies:

    ```bash
    dotnet restore
    ```

4. Run the application:

    ```bash
    dotnet run
    ```

5. Access the Swagger UI to test the APIs by navigating to:

    ```
    http://localhost:5000/swagger
    ```

## Running Unit Tests

To run the unit tests for this project:

1. Navigate to the test project directory:

    ```bash
    cd Logicommerce.Tests
    ```

2. Run the tests using xUnit:

    ```bash
    dotnet test
    ```

## Contributing

If you'd like to contribute to this project, feel free to fork the repository, make your changes, and submit a pull request. Please make sure to follow the coding conventions and write tests for any new features or bug fixes.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
