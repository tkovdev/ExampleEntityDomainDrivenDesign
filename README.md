# ExampleEntityDomainDrivenDesign
The purpose of this project is to identify an approach to satisfy SOLID principles in a C#, .NET (8), and Entity Framework context.

## Purpose & Justification
This solution addresses the issue of direct dependency of Application logic upon Entity Framework's Data Access Layer - known as DbContext - which forces developers to write data access code interspersed with application logic.

There are many concerns with this interspersion
1) Testing - The data & access must be mocked or stubbed and sugar-syntax / functions that Entity Framework provides are inherently difficult to mock or stub reliably. E.G. Entity Framework's ".Include()" & Entity Tracking.
2) Clarity - Entity Framework provide an efficient way for developers to think and access data, but leads to laziness or bloated LINQ statements that blur Application Business Logic and Application Data Access Logic. This leads to confusing-to-read code.
3) Separation of Concerns - Consider a decision to move away from Entity Framework or Database Provider (SQL Server to Oracle or MongoDb) with Logic & Data queries in the same location it is impossible to separate Application Business Logic and Application Data Access Logic, requiring an entire rewrite.

## Concept Of Operation

The application is separated into several projects each with its own purpose as outlined.
- API: Primary Application, provides public facing interfaces to access data & functions
- Domain: Models, as close to real-life as possible, the entities the application deals with. This project is concerned with modeling the input & output of accessible data and maps this data to the data layer.
  - Domain.Access: Provides a standard abstraction layer on which the API & Logic can operate. This project provides a factory for creating Domain objects and abstract classes for other projects to use to operate on the domain models.
- Logic: Represents the complicated logic that some application functionality may require. This project shall be used to draw connections between one or more Domain models. Not all I/O of data must pass through this layer, in fact, it is optimal to leave this layer to address complicated functionality only.
- Data: Models how data is stored only. This layer should always match 1:1 with the data storage provider (MS Sql, Oracle, MongoDb, etc.).
  - Data.Access: Provides the Context on which the data is accessed from the data storage provider.
- Exception: Middleware and exception classes to provide standard messaging and throwing of errors from any layer in the system.

### Single-Responsibility
Every class should have 1 fit-to-purpose reason to exist.

### Open-Closed
An entity can allow its behaviour to be extended without modifying its source code.

### Liskov Substitution
Base classes must be able to use objects of derived classes without knowing it.

### Interface Segregation
Developers should not be forced to depend upon interfaces that they do not use.

### Dependency Inversion
Concrete implementations should depend on abstractions.

## Class Diagram
![alt text](https://github.com/tkovdev/ExampleEntityDomainDrivenDesign/blob/main/Class-Diagram.png?raw=true)
