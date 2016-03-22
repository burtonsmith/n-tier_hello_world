#Hello World Demo App
_______
This is a simple application for demonstration purposes. The goal is to demonstrate some key features of enterprise software design such as:

 - N-Tier Architecture
 - SOLID Prinicples of Object-Oriented Programming
 - MVC Pattern Develoment Techniques
 - Generic Repository Pattern
 - And more...

----------


##Technologies Used

####The technologies used to build this demonstration are Microsoft related technologies that include:

 - C#
 - MS SQL Server
 - Entity Framework
 - ASP.Net MVC Framework
 - StructureMap
 - AutoMapper

A Brief Summary of the Architecture
-------------

####Data Layer (HelloWorld.Data)

This project includes the logic and the generic repository for interacting via Entity Framework with data in the MS SQL database. This particular application is using a LocalDB instance that is stored in the App_Data folder of the HelloWorld.MVC project.  
__________

####Business Logic/Domain Layer (HelloWorld.Domain)

This is where all of the data Entities are defined and services are stored for passing data to and from the Data Access Layer and for the business rules for creating, validating, and manipulating data objects.
__________

####Presentation Layer (HelloWorld.MVC)

The presentation layer of this solution happens to be an MVC project, but could possibly be any number of things such as a console application or a web API. As a matter of fact, it can include all of them. A solution like this can have multiple types of projects in its presentation layer. This is extremely beneficial as it encourages code reuse. Code and logic used in the Data Layer and the Business Logic layer can be used across all of these projects.

___________

####In addition
Additionally AutoMapper is used for mapping Entities between and ViewModels for writing code more quickly and all-around cleaner code. StructureMap is use for dependency resolution to insure IoC and encapsulation of code.
