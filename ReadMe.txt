This solution was originally created to show a basic clean architecture approach using ASP.Net core.
The idea was to create projects how they could be created if implementing a simple microservice
architecture. The data sccess also shows my interpretation of the Repository and unit of work patterns.

DotNet Version: 2.1.2
Node Version: v6.11.1
NPM Version: 3.10.10

Running the Solution
--------------------
The solution is set to run SimpleCRM.API on start up.
The solution uses an in memory database for simplicity.

When the browser is displayed navigate to http://localhost:5000/api/Customer/GetAllCustomers
this action will display the customer details as JSON.
Refer to the CustomerController class for the other action names specified on each of the action methods.


SimpleCRM.API
-------------
The SimpleCRM.API project is the main wbe API project.

SimpleCRM.Core
--------------
The SimpleCRM.Core project is a class library that contains the core code that can be used by
all other parts of the application

SimpleCRM.Infrastructure
------------------------
The SimpleCRM.Infrastructure project is a class library that contains the infrastructure related
functionality for the application like database access.

