
# MSSA Study Bank — Updated Project Framework

## Development Philosophy

This project prioritizes clarity, modular design, and separation of concerns. Flashcard logic is broken into **three pillars** — Methods, Syntax, and Whiteboarding — each delivered via a unified MAUI interface and backed by JSON-structured content. The framework below outlines a modern, component-based build order and MVP-first mindset.

---

## Phase 1: Card Model and Loader Foundation

### 1. Define `ICard` Interface + Models
- Create shared interface `ICard` with:
  - `string Id`
  - `string DisplayTitle`
  - `string DisplayBody()`

- Implement:
  - `MethodCard` (skills, errors, tags)
  - `ProblemCard` (scaffolded prompts)
  - `SyntaxCard` (language patterns)
  - `WhiteboardCard` (restated problem, pseudocode, edge cases)
  - `SolutionCard` (answers for fill-in problems)

**Why**: Enables polymorphic display in UI with uniform method signatures.

---

### 2. Build Generic JSON Loader
- `JsonLoader.LoadJsonAsync<T>()` to parse any list of cards from file
- Maps filenames to expected model

**Why**: Keeps card definitions in data, not hardcoded in views.

---

## Phase 2: UI + Card Navigation Logic

### 3. Implement `MainPage.xaml.cs`
- Load card type via dropdown (`cardTypePicker`)
- Render `DisplayTitle` and `DisplayBody()` from selected card
- Enable `Next`, `Previous`, and `Submit` navigation

**Why**: Gives users an interactive way to navigate flashcards without clutter.

---

### 4. Validate Data with CLI Tool
- In `/Validator/Program.cs`, implement:
  - `Validate<List<MethodCard>>("methods.json")` etc.
  - Prints schema success/failure and entry count

**Why**: Ensures that malformed JSON doesn't crash the UI.

---

## Phase 3: Content Creation

### 5. Fill Out `Resources/Raw` JSON
- `methods.json` → LeetCode-style method breakdowns
- `methodProblems.json` + `methodSolutions.json`
- `syntax.json`, `syntaxProblems.json`, `syntaxSolutions.json`
- `whiteboard.json` → step-by-step algorithm drills

**Why**: Structured datasets mirror curriculum, encourage review by type.

---

## Optional Phase 4: GPT Integration

### 6. Add `GPTTutor.cs` (Optional)
- Generate cards from topic strings
- Explain answers dynamically
- Scaffold new decks using AI

**Why**: GPT enhances coverage, can adapt to live feedback or new topics.

---

## MVP Checklist

| Step | Module                                 | Status   |
|------|----------------------------------------|----------|
| 1    | `ICard` + Card Models                  | Complete |
| 2    | `JsonLoader` Utility                   | Complete |
| 3    | MAUI `MainPage.xaml.cs` Navigation     | Complete |
| 4    | CLI Validator Tool                     | Complete |
| 5    | JSON Card Content                      | Complete |
| 6    | GPT Integration (Optional)             | Pending  |

---

## Design Principles

- **Scalability**: JSON-based content expansion with no code rewrites
- **Maintainability**: DRY logic, model-driven views, single source of truth
- **UI Simplicity**: One screen handles all card types consistently
- **MVP First**: All features work without GPT or external APIs
