# 🎮 Game Project Refactor

A C# Console Application that demonstrates how to refactor a monolithic Math Game into a cleaner, maintainable, and scalable Object-Oriented Design using OOP principles.

---

## 📖 Overview

This project started as a single large class containing all game logic, level management, question generation, user interaction, and statistics tracking.

The project was then refactored into multiple classes with clear responsibilities to improve:

- Readability
- Maintainability
- Scalability
- Reusability
- Code Organization

The goal was to practice applying real-world refactoring techniques and Object-Oriented Programming concepts.

---

## 🚀 Features

### Before Refactoring
- Large class handling everything
- Mixed responsibilities
- Difficult to maintain
- Difficult to extend

### After Refactoring
- Level-based architecture
- Question abstraction
- Statistics management
- Separation of concerns
- Cleaner code structure
- Easier maintenance

---

## 🏗️ Project Structure

```text
GameProjectRefactor
│
├── CodeBeforeRefactore.cs
├── Difficulty.cs
├── Statistics.cs
│
├── Level
│   ├── BaseLevel.cs
│   ├── EasyLevel.cs
│   ├── MediumLevel.cs
│   ├── HardLevel.cs
│   └── LevelManager.cs
│
├── Question
│   ├── IQuestion.cs
│   └── Question.cs
│
└── GameProjectAfterRefactor.cs
```

---

## 🧠 OOP Concepts Used

### Abstraction
Implemented using:

```csharp
BaseLevel
IQuestion
```

### Inheritance

```csharp
EasyLevel : BaseLevel
MediumLevel : BaseLevel
HardLevel : BaseLevel
```

### Polymorphism

Different levels override:

```csharp
Min
Max
NumberOfQuestions
Operators
```

through the abstract base class.

### Encapsulation

Each class manages its own behavior and responsibilities.

---

## 🎯 Levels

### Easy Level
- Numbers: 0 - 10
- Operators:
  - +
  - -

### Medium Level
- Numbers: 0 - 15
- Operators:
  - +
  - -
  - *

### Hard Level
- Numbers: 0 - 20
- Operators:
  - +
  - -
  - *
  - /

---

## 📊 Statistics Tracking

The game tracks:

- Total Questions Played
- Correct Answers
- Incorrect Answers
- Addition Questions
- Subtraction Questions
- Multiplication Questions
- Division Questions

---

## 🔄 Refactoring Goals

This project focuses on transforming:

### Before

```csharp
One class
Many responsibilities
Hard to maintain
```

into

### After

```csharp
Multiple focused classes
Single Responsibility Principle
Reusable components
Clean architecture
```

---

## 📚 What I Learned

Through this project I practiced:

- Object-Oriented Programming (OOP)
- Abstraction
- Inheritance
- Polymorphism
- Interfaces
- Refactoring Legacy Code
- Separation of Concerns
- Clean Code Principles
- Project Organization
- Console Application Design

---

## 🛠️ Technologies Used

- C#
- .NET
- Console Applications
- Object-Oriented Programming

---

## ▶️ Run the Project

```bash
git clone https://github.com/HamzaEldeeb/Game-Project-Refactor.git
```

Open the solution and run:

```bash
dotnet run
```

---

## 👨‍💻 Author

Hamza Eldeeb

Aspiring Full Stack .NET Developer

Focused on:
- C#
- OOP
- Data Structures
- Problem Solving
- Clean Architecture
