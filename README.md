# Employee Benefits Calculator

This solution demonstrates a Clean Architecture implementation of an Employee Benefits Calculator using .NET 6, MediatR, MongoDB, and Redis. The system calculates the cost of employee benefits packages and provides a payroll preview.

## Class Diagram

View the class diagram here: [Class Diagram](https://github.com/dmitry-kiselev-1/paylocity-benefits/blob/main/Paylocity.Benefits/Paylocity.Benefits.Application.png)

## Features

- Create employees and add dependents
- Calculate the cost of benefits for employees and dependents
- Generate a payroll preview with gross salary, benefit cost, and net salary
- Use MongoDB for storing employee and dependent data
- Use Redis for caching employee data

## Project Structure

The solution is organized according to Clean Architecture principles and consists of four projects:

1. **Domain**: Contains the core business logic, entities, and interfaces.
2. **Application**: Implements the application logic, command and query handlers, and DTOs.
3. **Infrastructure**: Provides concrete implementations of the repositories using MongoDB and Redis.
4. **Presentation**: Contains the Web API project with controllers and endpoints for employee management and payroll previews.

## Getting Started

### Prerequisites

- .NET 6 SDK
- MongoDB server
- Redis server

### Configuration

1. Update the connection strings in the `appsettings.json` file in the Presentation project:

   - Set the `EmployeeDb` connection string to your MongoDB server.
   - Set the `Redis` connection string to your Redis server.

2. Configure the Dependency Injection in the `Startup` class to use the desired repositories:

   - `services.AddSingleton<IEmployeeReadRepository, EmployeeReadRedisRepository>();` for using Redis as a read repository.
   - `services.AddSingleton<IEmployeeReadRepository, EmployeeRepository>();` for using MongoDB as a read repository.
   - `services.AddSingleton<IEmployeeWriteRepository, EmployeeRepository>();` for using MongoDB as a write repository.

### Running the Application

1. Open the solution in Visual Studio or Visual Studio Code.
2. Set the Presentation project as the startup project.
3. Run the application.

## API Endpoints

- `POST /employee`: Create a new employee.
- `GET /employee/{id}`: Get the benefit cost for an employee by ID.
- `POST /employee/{employeeId}/dependents`: Add a dependent to an employee.
- `GET /payroll/preview`: Get the payroll preview.

## License

This project is open-source and available under the [MIT License](LICENSE).
