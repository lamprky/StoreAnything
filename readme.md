# StoreAnything

StoreAnything is an simple application where you can store any json object.

## Installation

1. Run bellow command to fetch all necessary packages for project
`dotnet restore`

2. Adjust ConnectionStrings.DatabaseConnection on */appsetting.json* file to fit with your SQL Server connection info

3. DB Setup
This project is based on a MS SQL. In order to setup the database you could use
a. */Installation/StoreAnynthing.bak* file to restore the database
b. Entity Framework migrations by running the bellow command
`dotnet ef database update`

4. Use the bellow command to execute the application
`dotnet run`

5. (optional) Import postman collection */Installation/StoreAnything.postman_collection.json* to test functionallity

