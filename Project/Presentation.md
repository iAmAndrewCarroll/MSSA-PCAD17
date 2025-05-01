# ✅ **C# Class Structure Overview — MVP Scope**

This summary outlines your current and near-future core:

| Area | Description |
|------|-------------|
| **Classes** | Primary models and interfaces |
| **Properties** | Data carried by each class |
| **Methods** | How they behave |
| **Constructors** | Object creation signatures |
| **OOP Concepts** | Inheritance, overrides, polymorphism |

---

## 1. **`FlashCard` (abstract base class)**
Represents the parent structure for all flashcard types.

### Properties:
- `string Prompt`  
- `string? Explanation`  
- `virtual string TypeLabel` → auto-derived or overridden in child

### Constructor:
`protected FlashCard(string prompt)`

### Methods:
- `abstract Task Run()` → must be implemented by subclasses

### OOP Concepts:
- **Abstract**: cannot be instantiated directly
- **Override-ready**: `TypeLabel` is `virtual`

---

## 2. **`FillInCard : FlashCard`**
Single-answer fill-in-the-blank question.

### Additional Properties:
- `string Answer`

### Constructor:
`public FillInCard(string prompt, string answer)`

### Methods:
- `override async Task Run()` — input vs answer validation

### OOP Concepts:
- **Inherits** from `FlashCard`
- **Overrides** `Run()` and optionally `TypeLabel`

---

## 3. **`ShortAnswerCard : FlashCard`**
Supports short freeform responses and comparisons.

### Properties:
- `string Answer`

### Constructor:
`public ShortAnswerCard(string prompt, string answer)`

### Methods:
- `override async Task Run()`

---

## 4. **`CodeTraceCard : FlashCard`**
Used to trace what code does (e.g. output).

### Properties:
- `string ExpectedOutput`

### Constructor:
`public CodeTraceCard(string prompt, string expectedOutput)`

### Methods:
- `override async Task Run()`

---

## 5. **`DynamicFillInCard : FlashCard`**
Multi-blank syntax-aware cards (from GPT + Roslyn).

### Additional Properties:
- `Dictionary<string, string> LabeledAnswers` (e.g. `"___1": "Console.ReadLine"`)

### Constructor:
`public DynamicFillInCard(string prompt, Dictionary<string, string> labeledAnswers)`

### Methods:
- `override async Task Run()`
- Auto-explains with GPT if `Explanation` is missing

---

## 6. **`GPTTutor`**
Handles all OpenAI interaction.

### Methods:
- `Task<string> GenerateRawCardFromTopic(string topic)`
- `Task<string> ExplainAnswerAsync(...)`
- `Task<FillInCard?> GenerateFillInCardFromMethod(...)`

---

## 7. **`TopicLoader`**
Loads curriculum and topic hierarchy from `curriculum.json`.

### Methods:
- `GetCurriculum()`
- `GetAllPrograms()`
- `GetModules(string program)`
- `GetTopics(string program, string module)`
- `GetRandomTopic()`

---

## 8. **`CardValidator`**
Validates JSON structure of GPT output.

### Methods:
- `ValidateFillInCardJson(string rawJson) → (bool, string)`
- Uses regex to match `___` blanks to `answers` count

---

## 9. **`TestRunner`**
Runs GPT flashcard structure tests.

### Methods:
- `Task Run()` → one topic at a time
- `Task RunAllTopics()` (planned)

---

## ✅ Key OOP Concepts Used

| Concept | Examples |
|--------|----------|
| **Inheritance** | `DynamicFillInCard : FlashCard` |
| **Polymorphism** | `List<FlashCard>.ForEach(card => await card.Run());` |
| **Abstraction** | `FlashCard` as an abstract base |
| **Override** | `Run()` and `TypeLabel` overridden in subclasses |
| **Encapsulation** | Internal card behavior hidden from caller |
| **Composition** | `GPTTutor` uses injected topic content + returns structured flashcards |
