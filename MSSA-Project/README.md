# MSSA Project: C# Study Trainer App

A cross-platform .NET MAUI application designed to reinforce C# programming fundamentals using interactive flashcards, inline code prompts, and review-based learning.

## Project Overview

### Purpose

This application was developed as a midterm project for the Microsoft Software & Systems Academy (MSSA). It provides structured, self-paced study support for mastering:

- C# syntax and method usage
- Inline logic reasoning
- Whiteboard problem solving
- Real-time answer validation
- Retention via review mode and performance tracking

## Screenshots and Flow

### 1. System Architecture

![System Architecture](Assets/projectOverview.png)

### 2. Learning Objective Justification

![Why This Matters](Assets/projectMatters.png)

### 3. UI Wireframe

![UI Wireframe](Assets/wireframe.png)

### 4. Live Execution Flow

Demonstrates the runtime behavior of the app. When users submit answers, the system validates them, updates the review queue, and displays accuracy feedback in real-time.


![Run Example](Assets/projectRun.png)


## Features

* Modular deck loading for:

  * Assignment Cards
  * Method Problems
  * Syntax Problems
  * Whiteboard Exercises
* Toggle between Method and Syntax views
* Hint system with controlled visibility
* Entry sync groups for mirrored answer fields
* Immediate validation and visual feedback
* Review Mode for incomplete mastery
* Local performance tracking saved to JSON
* Stats page for accuracy and history display
* Bot simulation for training at scale

## Project Structure

```

MSSA\_Project/
├── App.xaml
├── App.xaml.cs
├── AppShell.xaml
├── AppShell.xaml.cs
├── MainPage.xaml
├── MainPage.xaml.cs
├── StatsPage.xaml
├── StatsPage.xaml.cs
├── MauiProgram.cs
├── MSSA\_Project.csproj
├── MSSA\_Project.sln
├── README.md

├── Assets/
│   └── projectOverview\.png
│   └── projectMatters.png
│   └── wireframe.png
│   └── projectRun.png

├── Models/
│   └── MethodCard.cs

├── Notes/
│   ├── Assignments.md
│   ├── framework.md
│   ├── ProjectReview5.19.2025.md
│   ├── ProjectReview5.27.2025.md
│   ├── ProjectReview5.28.2025.md
│   ├── ProjectStructure.md
│   ├── whiteboard.md
│   └── xamls.md

├── Resources/
│   └── Raw/
│       ├── Assignments.json
│       ├── methodCards.json
│       ├── methodProblems.json
│       ├── methodSolutions.json
│       ├── methods.json
│       ├── project.json
│       ├── syntax.json
│       ├── syntaxCards.json
│       ├── syntaxProblems.json
│       ├── syntaxSolutions.json
│       └── whiteboard.json

├── Simulation/
│   └── StudyBot.cs

├── Utility/
│   ├── AnswerUtility.cs
│   ├── CardLoader.cs
│   ├── CardRenderer.cs
│   ├── CardStateManager.cs
│   ├── DebugLogger.cs
│   ├── HintRender.cs
│   ├── JsonTester.cs
│   ├── PerformanceStorage.cs
│   ├── PromptRenderer.cs
│   ├── ReviewService.cs
│   ├── UIService.cs
│   └── jsonLoader.cs

├── Performance/               # (if used for additional tracking or telemetry views)
├── Platforms/                 # .NET MAUI platform-specific code
├── Properties/
├── Staging/                   # Temporary or experimental files
├── Validator/                 # Reserved for custom validation logic
├── bin/
├── obj/

```

## Tech Stack

* .NET MAUI (Multi-platform App UI)
* C# 11 / .NET 9 (preview)
* XAML for layout and styling
* Local file storage (System.Text.Json)
* Visual Studio 2022

## Running the App

1. Open `MSSA_Project.sln` in Visual Studio 2022.
2. Restore NuGet packages.
3. Build and run on your target platform:

   * Android emulator
   * Windows desktop
   * macOS Catalyst (if supported)

## Notes

* JSON flashcards live in `Resources/Raw/`
* Images used in documentation are stored under `Assets/`
* Requires .NET 9 preview and Visual Studio MAUI workload
