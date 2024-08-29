# TodoItems_Project
To-Do List API Description: The To-Do List API is a simple and efficient RESTful web service designed to manage to-do items. It allows users to perform CRUD (Create, Read, Update, Delete) operations on to-do items, which consist of a title and a description. The application is built using ASP.NET Core and Entity Framework Core, with MySQL as the database. This API is ideal for managing tasks and organizing your daily activities.

Features: Create a To-Do Item: Add a new to-do item with a title and description. Retrieve To-Do Items: Fetch a list of all to-do items or retrieve a specific item by its ID. Update To-Do Items: Modify the details of an existing to-do item. Delete To-Do Items: Remove a to-do item from the list. Prerequisites: .NET SDK 7.0 MySQL Server Visual Studio 2022 (or any preferred IDE) Postman (optional, for testing the API) Setup Instructions: Clone the Repository:

Clone the repository from GitHub: bash git clone https://github.com/your-username/todo-list-api.git Configure the Database:

Update the appsettings.json file with your MySQL connection string: json "ConnectionStrings": { "DefaultConnection": "Server=your-server;Database=your-database;User=your-username;Password=your-password;" } Alternatively, you can set the connection string in environment variables. Run Database Migrations:

Open a terminal in the project directory and run the following command to apply the migrations: bash dotnet ef database update Build the Project:

In the terminal, navigate to the project directory and run: bash dotnet build Run the API:

Start the API by running: bash dotnet run The API will be accessible at https://localhost:5001 or http://localhost:5000. Test the API:

You can test the API endpoints using Postman or any other API testing tool. Below are some example endpoints: GET /api/todoitems - Retrieve all to-do items. GET /api/todoitems/{id} - Retrieve a specific to-do item by ID. POST /api/todoitems - Create a new to-do item. PUT /api/todoitems/{id} - Update an existing to-do item. DELETE /api/todoitems/{id} - Delete a to-do item. Run Unit Tests:

To run the unit tests, execute the following command: bash dotnet test Ensure that all tests pass successfully.
