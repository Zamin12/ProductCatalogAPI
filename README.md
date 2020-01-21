## Product Catalog API
  
RESTful service for Managing product catalog solution.
It was designed as Simple data-driven CRUD microservice.

Example illustration taken from microsoft documentation: 
![Simple data-driven CRUD microservice](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/media/data-driven-crud-microservice/simple-data-driven-crud-microservice.png)

## Getting Started

This service exposes information about product catalog entities with RESTFul service.
It provides add, edit, remove, view and filter endpoints.

Features: 
* ASP.NET Core framework.
* API Support for versioning.
* Asynchronous endpoins.
* Unit tests for controller.
* Photo data is implemented as base64 string.
* Additional controller for System information and status

## Technologies

Frameworks and packages:

* ASP.NET Core: 3.0
* Entity Framework Core and related: 3.1.1
* Newtonsoft.Json: 12.0.3
* Swashbuckle.AspNetCore: 5.0.0
* AspNetCore.Mvc.Versioning.ApiExplorer: 4.0.0

Test project frameworks and packages: 

* Microsoft.NET.Test.SDK: 16.4.0
* Microsoft.EntityFrameworkCore.InMemory: 3.1.1
* xunit: 2.4.1
* xunit.runner.visualstudio: 2.4.1

Tools: 

* Visual Studio Professional: 16.3.9
* Microsoft SQL Server: 14.0 (SQLEXPRESS)

## Prerequisites

As configuration you will need clarify and change connection string in ```appsettings.json``` and ```appsettings.Development.json``` files. 
There must not be database with same name as in configuration. It will be created with migrations on first startup of solution.

```
{
  "ConnectionStrings": {
    "Default": "Server=.\\SQLEXPRESS;Database=ProductCatalogAPI;Integrated Security=true"
  },
  ...
}

```

Also it is possible to change Urls and ports for different profiles in ```Properties\launchsettings.json``` 

```
{
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:9000",
      "sslPort": 44373
    }
  },
  "profiles": {
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "launchUrl": "swagger",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "ProductCatalogAPI": {
      "commandName": "Project",
      "launchBrowser": true,
      "launchUrl": "swagger",
      "applicationUrl": "https://localhost:5001;http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

## Authors

* **Zamin Ismayilov**
