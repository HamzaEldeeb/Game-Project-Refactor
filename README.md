# 🎮 Game Project Refactor

A console-based Math Game that was refactored using **Object-Oriented Programming (OOP)** principles and clean code practices.

The goal of this project is to transform a poorly structured codebase into a more maintainable, readable, and extensible design.

---

## 📌 Project Overview

This project demonstrates the process of refactoring an existing game application by improving:

- Code organization
- Class responsibilities
- Maintainability
- Readability
- Extensibility

The original version contained tightly coupled code, and the refactored version applies better software design practices.

---

## 🚀 Features

- Multiple difficulty levels:
  - Easy
  - Medium
  - Hard

- Different mathematical operations:
  - Addition
  - Subtraction
  - Multiplication
  - Division

- Random question generation

- Player score tracking

- Game statistics

- Level management

- Clean separation of responsibilities between classes

---

## 🏗️ Project Structure

```text
GameProjectRefactor
│
├── Question
│   ├── IQuestion.cs
│   └── Question.cs
│
├── Level
│   ├── BaseLevel.cs
│   ├── EasyLevel.cs
│   ├── MediumLevel.cs
│   ├── HardLevel.cs
│   └── LevelManager.cs
│
├── MathGame.cs
├── Difficulty.cs
├── Statistics.cs
└── Program.cs
