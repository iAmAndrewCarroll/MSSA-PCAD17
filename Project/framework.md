TARGET:
USER → Topic Menu → Select Program > Module > Topic
     → Calls GPTTutor.GenerateFromTopic(...)
     → Validates JSON structure with CardValidator
     → Creates DynamicFillInCard
     → Runs card session
     → Saves to file for topic

LOW-RESISTANCE NEXT STEPS

    Replace week menu in Program.cs with topic selector

    Add GenerateFromTopic(...) to GPTTutor.cs

    Update CardValidator.cs to support MultipleChoiceCard

    Write SaveCardToTopic(...) helper

    Prompt GPT to match latest expected JSON format with "answers" array 







    Perfect. With this clean file snapshot, I now have **100% accurate insight into your project directory** and can confidently guide you forward. Here's your **refined audit, aligned with the actual file system** — no assumptions, no drift.

---

## VERIFIED FILE SNAPSHOT

### Root Files (Entry + Docs)
```
Program.cs              # Main menu logic (Week-based for now)
FlashCardRunner.cs      # Study session loop
GPTTutor.cs             # GPT-3.5 API logic (needs topic support)
framework.md            # Dev workflow doc
Presentation.md         # Class map overview
ProjectUpdate5-1-25.md  # Current architecture strategy
PersistentIssues.md     # Bug tracker and history
prompt.txt              # GPT input prompt template
snippet_prompt.txt      # Snippet-only prompt (no explanations)
whiteboard.md           # High-level roadmap
```

### Core Class Logic
```
FlashCards/
├── FlashCard.cs
├── FillInCard.cs
├── DynamicFillInCard.cs
├── CodeTraceCard.cs
├── ShortAnswerCard.cs
├── MultipleChoiceCard.cs
```

### Helpers
```
Helpers/
├── FlashCardLoader.cs       # JSON file → card object
├── CardValidator.cs         # Validates GPT card shape
├── TopicLoader.cs           # Pulls from curriculum.json
├── BlankGenerator.cs        # (Unused?)
├── Utilities.cs             # DRY console utilities
```

### GPT Test Harness (Isolated)
```
TestGPT/GPTTester/
├── Program.cs               # Raw GPT test runner
├── GPTTestRunner.cs         # Likely test orchestrator
├── GPTTester.csproj
```

### Canonical Curriculum Source
```
Truth/
└── curriculum.json          # Program > Module > Topic tree
```

---

##  MVP BLOCKERS

| Feature | Missing or Incomplete | Required For |
|--------|------------------------|--------------|
| **Topic-driven generation** |  `GenerateFromTopic(...)` not implemented in `GPTTutor.cs` | Curriculum-aligned dynamic flashcards |
| **CLI topic selection** |  No menu to choose Program → Module → Topic | Replaces hardcoded “Week 1–4” menu |
| **Card saving** |  `SaveCardToTopic(...)` not yet present | Storing validated cards for reuse |
| **Proper `DynamicFillInCard` loader support** | ⚠ Not confirmed in `FlashCardLoader.cs` | Deserializing cards from GPT |
| **Roslyn-powered blanking** |  Not started | Phase 2 snippet-to-flashcard transformation |
| **MultipleChoiceCard GPT generation** |  No prompt format, no generator method | Full support of flashcard types |

---

## PATH TO MVP

### 1. Replace Week Menu in `Program.cs`  
Add a `SelectTopic()` function that uses:
```csharp
var program = TopicLoader.GetAllPrograms();
var module = TopicLoader.GetModules(program);
var topic = TopicLoader.GetTopics(program, module);
```

### 2. Add to `GPTTutor.cs`:
```csharp
public static async Task<DynamicFillInCard?> GenerateFromTopic(string program, string module, string topic)
```
Use this instead of `GenerateFillInCardFromMethod`.

### 3. Add to `Program.cs`:
```csharp
private static void SaveCardToTopic(FlashCard card, string program, string module, string topic)
```
Save to:
```
Truth/StudyBankCards/{Program}/{Module}/{Topic}.json
```

### 4. Update `FlashCardLoader.cs`
- Fix `GetOptinoal` typo
- Support cards with `"answers"` array → create `DynamicFillInCard`
- Add support for `MultipleChoiceCard` (if you’ll use it)






























## **Recommended Project Workflow (Top-Down, Accurate, DRY)**

### 1. **Define the Control Flow and Entry Point**
- Scaffold `Program.cs` to:
  - Load a menu
  - Route to a selected week’s flashcard set
  - Launch `FlashCardRunner`

**Why**: This defines your app’s top-level behavior. It anchors navigation, week loading, and user session flow.

---

### 2. **Create the FlashCard Base Model**
- Build `FlashCard.cs` (abstract or base class)
- Create `FillInCard`, `CodeTraceCard`, and `ShortAnswerCard` as separate derived models

**Why**: This creates a clean and extensible domain model for your core app logic.

---

### 3. **Implement JSON Schema + Loader**
- Define the JSON format in `Week1.json` (one or two cards per type to start)
- Implement `FlashCardLoader.cs` to:
  - Read from JSON
  - Deserialize to appropriate flashcard types

**Why**: This ensures the flashcards can be edited and extended without touching the code.

---

### 4. **Build the FlashCard Runner**
- Implement `FlashCardRunner.cs` to:
  - Accept a list of cards
  - Loop through and display them
  - Check answers, provide feedback
  - Use `Utilities` for input and feedback

**Why**: This is the engine of your flashcard logic — your users will interact here most.

---

### 5. **Integrate Utilities and Testing**
- Use `Utilities.cs` across all layers (input, menu, validation, etc.)
- Add test cards for Week 1 and verify input/output loop

**Why**: Validate DRY reuse and make sure user flow feels natural.

---

### 6. **Add GPTTutor Interface (Optional Phase 2)**
- Scaffold `GPTTutor.cs` to accept a card and return:
  - Explanation
  - Regenerated variant

**Why**: This brings in dynamic learning but can be added after MVP is stable.

---

## ✅ MVP CHECKLIST TRACKER (I will track these as we proceed)

| Step | Module | Status |
|------|--------|--------|
| 1 | `Program.cs` basic menu + dispatch | ⬜ |
| 2 | `FlashCard.cs` base + 3 types | ⬜ |
| 3 | `Week1.json` sample cards | ⬜ |
| 4 | `FlashCardLoader.cs` loader logic | ⬜ |
| 5 | `FlashCardRunner.cs` interactive runner | ⬜ |
| 6 | `Utilities.cs` validated and imported | ✅ |
| 7 | `GPTTutor.cs` integration (optional) | ⬜ |
