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
