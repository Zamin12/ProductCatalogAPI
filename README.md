## Product Catalog API
  
RESTful service for Managing product catalog solution.
It was designed as Simple data-driven CRUD microservice.

Example illustration taken from microsoft documentation: 
![Simple data-driven CRUD microservice](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/media/data-driven-crud-microservice/simple-data-driven-crud-microservice.png)

## Getting Started

This service will expose information about product catalog entities with RESTFul service.
It provides you add, edit, remove, view and filter endpoints.

Features: 
* Used ASP.NET Core framework.
* API Support for versioning.
* Endpoins implemented in asynchronously.
* Added unit test for controller.
* Photo data are implemented recieving, sending and saving as base64 string. (nvarchar(max))

P.S: As there is only table without any additional complex behaviors decided to use CRUD logic and put it same place with endpoints in controller.


## Technologies

Project is created with frameworks and packages:

* ASP.NET Core: 3.0
* Entity Framework Core and related: 3.1.1
* Newtonsoft.Json: 12.0.3
* Swashbuckle.AspNetCore: 5.0.0
* AspNetCore.Mvc.Versioning.ApiExplorer: 4.0.0

Tools: 

* Visual Studio Professional: 16.3.9
* Microsoft SQL Server: 14.0 (SQLEXPRESS)

For Test project: 

* Microsoft.NET.Test.SDK: 16.4.0
* Microsoft.EntityFrameworkCore.InMemory: 3.1.1
* xunit: 2.4.1
* xunit.runner.visualstudio: 2.4.1

### Prerequisites

As configuration you will need clarify and change connection string in '''appsettings.json''' and '''appsettings.Development.json''' files. 
There must not be database with same name as in configuration. It will be created with migrations on first startup of solution.

```
{
  "ConnectionStrings": {
    "Default": "Server=.\\SQLEXPRESS;Database=ProductCatalogAPI;Integrated Security=true"
  },
  ...
}

```

Also it is possible to change Urls and ports for solution on different profiles. 

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

## Acknowledgments

* 
