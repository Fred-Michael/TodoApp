# To-Do List Application

A simple To-Do List Application with a C# ASP.NET Core backend and an Angular frontend, allowing users to manage tasks efficiently.

The way to run the Todo App is to have the backend up and running first before launching the frontend. This readme details how to launch the backend. 

## Table of Contents
- Backend Setup Guide
- API Endpoints
- Thoughts and Improvements

Backend (ASP.NET Core)
The backend provides a RESTful API using ASP.NET Core with SQLite for data persistence.
Tech Stack
- Language: C#
- Framework: ASP.NET Core Web API
- Database: SQLite with Entity Framework Core
- Containerization: Docker

### Setup Guide
1. Clone the repository
` git clone <repository-url>
cd TodoApp `

2. Install dependencies
` dotnet restore `

3. Set up the database
Since a light-weight SQLite db is used, and migration scripts exist, run ` update-database ` to apply the latest migration.

4. Run the application via the command line using ` dotnet run ` or by clicking the play button from Visual Studio. You should see your endpoints on Swagger in your browser. If you don't, navigate to ` localhost://<portNumber>/swagger ` where portNumber can be found in launchSettings


### API Endpoints

| Method  | Endpoint                  | Description                           |
|---------|---------------------------|---------------------------------------|
| `POST`  | `/api/todos`               | Create a new to-do                   |
| `GET`   | `/api/todos`               | Retrieve all to-dos                   |
| `GET`   | `/api/todos/{id}`          | Get a specific to-do item             |
| `PUT`   | `/api/todos/{id}`          | Update a to-do item                   |
| `PATCH` | `/api/todos/{id}/complete` | Mark as completed                     |
| `PATCH` | `/api/todos/{id}/incomplete` | Mark as incomplete                  |
| `DELETE` | `/api/todos/{id}`         | Delete a to-do                        |


### Thoughts and Improvements
For this project, I am using a DDD approach with Clean Architecture folder structure to make it easier to maintain the code base and for readability.

What I couldn't implement due to time constraints, but would do if I had more time, would be:
- to make use of DTOs and mappers, and to add JSON standardized responses rather than the plain HTTP code responses
- to write unit tests
- to add logging into the application in critical places like CRUD operations in the service layers for easy debugging.



