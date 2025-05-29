# MSSA Study Bank — Updated Framework Overview (as of 5/27/2025)

This document consolidates the current application architecture, working features, and known issue resolutions based on the most recent debugging and file uploads.

---

## 1. Project Structure Summary

/MSSA-Project
├── App.xaml
├── App.xaml.cs
├── AppShell.xaml
├── AppShell.xaml.cs
├── MainPage.xaml
├── MainPage.xaml.cs
├── MauiProgram.cs
├── MSSA_Project.csproj
├── MSSA_Project.sln
├── MSSA_Project.csproj.user
├── Assets/
├── bin/
├── obj/
├── Notes/
├── Platforms/
├── Properties/
├── Staging/
├── Validator/
├── Models/
│   └── MethodCard.cs
├── Utility/
│   ├── AnswerUtility.cs
│   ├── CardLoader.cs
│   ├── CardRenderer.cs
│   ├── CardStateManager.cs
│   ├── DebugLogger.cs
│   ├── HintRender.cs
│   ├── JsonTester.cs
│   ├── PromptRenderer.cs
│   ├── ReviewService.cs
│   └── UIService.cs
├── Resources/
│   └── Raw/
│       ├── AboutAssets.txt
│       ├── Assignments.json
│       ├── methodCards.json
│       ├── methodProblems.json
│       ├── methodSolutions.json
│       ├── methods.json
│       ├── syntax.json
│       ├── syntaxCards.json
│       ├── syntaxProblems.json
│       ├── syntaxSolutions.json
│       └── whiteboard.json

---

## 2. Card Types and Decks

Three core learning pillars are supported:

- Methods
  - methods.json, methodCards.json, methodSolutions.json

- Syntax
  - syntax.json, syntaxCards.json, syntaxSolutions.json

- Whiteboard
  - whiteboard.json

- Assignments (combined method/syntax scaffold cards with metadata)
  - Assignments.json

All data is stored in /Resources/Raw/ and loaded via JsonLoader.

---

## 3. Card Rendering and Validation Flow

- User selects a deck from Picker
- Cards are loaded into memory via CardLoader
- MainPage tracks current index and handles navigation
- CardRenderer and PromptRenderer display scaffolded prompts with blanks
- AnswerUtility:
  - Collects user input (by blank-ID)
  - Validates against solution list
  - Highlights correct/incorrect fields
  - Logs card-level performance

---

## 4. Known Bug (Answer Highlighting Incomplete)

### Symptom
After clicking Submit:
- Answer validation message is accurate
- But Entry border/background colors do not reflect correct/incorrect status
- Applies to both MethodProblem and SyntaxProblem cards

### Cause
AnswerUtility.HighlightAnswerBoxes was iterating directly over inputStack.Children, expecting each child to be a Border. However, PromptRenderer wraps Entry inside nested layouts, breaking shallow traversal logic.

### Comparison Reference
MainPage.xaml.cs.bak used a recursive `HighlightRecursive` function that traversed nested Views and successfully reached Entry elements within Border → HorizontalStackLayout structures.

---

## 5. Highlighting Patch (Current Fix)

### Proposed Fix Implementation in AnswerUtility.cs

Replace HighlightAnswerBoxes with the following recursive approach:

```csharp
public static void HighlightAnswerBoxes(StackLayout inputStack, AnswerResult result)
{
    var correctnessMap = new Dictionary<string, bool>();
    for (int i = 0; i < result.Details.Count; i++)
    {
        correctnessMap[$"blank-{i + 1}"] = result.Details[i].IsCorrect;
    }

    foreach (var child in inputStack.Children)
    {
        HighlightRecursive(child, correctnessMap);
    }
}
````

This ensures compatibility with deeply nested PromptRenderer structures and restores correct Entry-level highlighting.

### HighlightRecursive handles:

* Border
* Entry
* ContentView
* Nested Layouts

Entry fields are matched by ClassId pattern "blank-N" and highlighted with green/red stroke and background based on correctness.

---

## 6. Review Mode State Logic

CardStateManager:

* Tracks full deck vs review-only queue
* Supports toggling review mode
* Auto-advances on correct answer (outside review)
* Exits review if all review cards are passed

ReviewService:

* Updates feedbackLabel to show "Reviewing: X of Y" or "For Review: Y"

AnswerUtility:

* Logs all attempts
* Tracks whether a card was correct on first try

---

## 7. In Progress Features

* Answer reveal toggle
* Performance export/logging
* GPT Tutor integration for explanation generation
* UI polishing (syntax highlighting, padding, responsive spacing)

---

## 8. Testing Recommendations

* Verify answer highlighting for MethodCard, ProblemCard, AssignmentCard (both method and syntax modes)
* Confirm ClassId mapping is consistent between RenderPrompt and HighlightAnswerBoxes
* Stress test nested blank usage
* Confirm sync entry values stay consistent across duplicate blanks
* Validate review queue flow after toggling modes


