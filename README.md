# Library Management System

## Overview

A console-based Library Management System built using C# and .NET. The application allows members to borrow and return books while tracking active and overdue loans.

## Features

- Manage books and members
- Issue and return books
- Track active and overdue loans
- Custom exception handling
- Unit testing with xUnit

## Technologies Used

- C#
- .NET
- LINQ
- Async/Await
- xUnit
- Moq
- Git & GitHub

## Architecture

```text
Console App
     ↓
 LoanService
     ↓
Repositories
     ↓
In-Memory Storage
```

## Design Concepts

- Object-Oriented Programming (OOP)
- Encapsulation
- Dependency Injection
- Dependency Inversion Principle (DIP)
- Generic Repository Pattern
- LINQ
- Async/Await
- Custom Exceptions

## Testing

Implemented xUnit tests for:

- Successful book issuance
- Book availability validation
- Member validation
- Successful book return
- Loan validation
- Overdue loan reporting

## Project Structure

```text
LibraryApp
├── LibraryApp.Console
├── LibraryApp.Domain
├── LibraryApp.Tests
├── LibraryApp.sln
└── README.md
```

## Learning Outcomes

This project helped me gain hands-on experience with:

- Domain Modeling
- Generic Repositories
- Service Layer Architecture
- Asynchronous Programming
- Unit Testing
- Git and GitHub Workflow
``