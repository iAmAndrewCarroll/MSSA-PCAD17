
# MSSA Final Project: C# Study Bank — Methods, Syntax, and Whiteboard Practice

## Problem Statement

Students in the Microsoft Software & Systems Academy (MSSA) often struggle to retain and apply foundational programming concepts — particularly C# syntax, algorithmic reasoning, and method mastery. Traditional lectures and exercises may lack the repetitive practice, contextual feedback, and adaptive difficulty needed to promote retention. There is a need for an interactive and modular tool that reinforces core patterns and prepares students for whiteboard interviews, technical assessments, and day-to-day coding.

## Solution Overview

Build a cross-platform C# flashcard app using .NET MAUI that dynamically loads JSON-encoded flashcards across three pillars of learning:

1. Method Review — concept-based cards with tags, common errors, and LeetCode mappings.
2. Syntax Reinforcement — fill-in-the-blank scaffolds for C# control flow, parameter modes, memory types, etc.
3. Whiteboard Practice — step-by-step algorithm prompts with edge case analysis, pseudocode, and solution walkthroughs.

Cards are rendered interactively using a unified interface, navigated via a MAUI dropdown. Users can cycle forward/back, with answer checking functionality to follow.

## Project Goals

- Deepen conceptual fluency in methods, syntax, and logical reasoning
- Use JSON to separate content from code (fully extensible)
- Reinforce DRY principles and clean model-view separation
- Support scalable review and spaced repetition workflows
- Phase 2: Integrate GPT-driven explanation and card generation

## Project Architecture

/MSSA-Project
│
├── MainPage.xaml/.cs         # Card viewer logic, interactive navigation
├── MethodCard.cs             # Unified models: MethodCard, ProblemCard, SyntaxCard, WhiteboardCard
├── /Resources/Raw/           # JSON-based flashcard data (below)
│   ├── methods.json              # Method concept overviews
│   ├── methodProblems.json       # Fill-in-the-blank method scaffolds
│   ├── methodSolutions.json      # Answer key for method problems
│   ├── syntax.json               # Syntax concepts (tags, errors)
│   ├── syntaxProblems.json       # Syntax scaffold prompts
│   ├── syntaxSolutions.json      # Answer key for syntax problems
│   ├── whiteboard.json           # Full algorithm whiteboard walk-throughs
│
├── /Utility/
│   └── JsonLoader.cs         # Generic async JSON parser
│
├── /Validator/
│   └── Program.cs            # CLI tool for JSON schema validation

## Development Progress

| Feature           | Description                                         | Status |
|------------------|-----------------------------------------------------|--------|
| Card Models       | Polymorphic ICard system: MethodCard, ProblemCard, etc. | Complete |
| Card Loader       | Loads card lists based on type using JsonLoader     | Complete |
| Main UI           | Picker, forward/back cycle, card renderer           | Complete |
| Method Deck       | Conceptual + scaffold + solution (JSON-linked)      | Complete |
| Syntax Deck       | Basic C# structures + parameter modes + control flow | Complete |
| Whiteboard Deck   | Pseudocode, step walkthroughs, code examples        | Complete |
| Answer Checking   | To be implemented (OnSubmitClicked)                 | Complete |
| Performance Tracking   | Phase 2: implement performance metrics          | Pending |

## Next Steps

1. Export Sessions / Progress
   - Track user performance (optional Phase 3)

2. GPT Integration (Phase 3)
   - Explore best use cases and ROI of integration

## Study Pillars

| Pillar        | Source                            | Purpose                            |
|---------------|-----------------------------------|------------------------------------|
| Methods       | methods.json + methodProblems.json | LeetCode-style prep + applied logic |
| Syntax        | syntax.json + syntaxProblems.json  | Drill core language patterns        |
| Whiteboard    | whiteboard.json                    | Reinforce test-style explanations   |

