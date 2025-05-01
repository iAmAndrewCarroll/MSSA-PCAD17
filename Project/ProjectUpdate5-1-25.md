PROJECT NAME: StudyBank – GPT-Powered Flashcard Tutor for MSSA

This is a C# console application that has been evolving since its original version, which was built to reinforce key weekly topics from the Microsoft Software & Systems Academy (MSSA). It originally followed a Week1.json / Week2.json format with hardcoded flashcards grouped by week. 

However, the project has since pivoted and expanded. Here is the full evolution and current state:

---

## 🔁 Original Architecture:
- One JSON file per week (`Weeks/Week1.json`, etc.)
- FlashCard types: FillInCard, CodeTraceCard, ShortAnswerCard
- Static flashcards manually created for each week
- StudyBank.csproj organized with:
  - Program.cs
  - FlashCardRunner.cs
  - FlashCards/
  - Helpers/
  - Utilities.cs
  - GPTTutor.cs (early GPT integration)

---

## 🔄 Key Pivot:
The project is now migrating toward **dynamic generation of flashcards using OpenAI GPT-3.5 Turbo**, seeded by structured curriculum topics.

The focus is no longer on manually curated `.json` files per week. Instead, we're now:
- Generating new flashcards dynamically based on curriculum topic
- Validating GPT responses (e.g., correct structure, formatting, JSON compliance)
- Saving validated cards to JSON (planned)
- Dynamically expanding the study bank over time with community use

---

## ✅ Key New Assets and Design Changes:

### 1. `curriculum.json`
A **master dictionary** of all MSSA content areas, created from:
- 10975 (Intro to Programming)
- 20483 (C# Fundamentals)
- Azure Certifications (AZ-900, AZ-204)
- AI-900 (Azure AI Fundamentals)
- .NET MAUI module topics
- Data Structures & Algorithms topics

This is the **source of truth** for topic selection and GPT input prompts going forward.

### 2. `prompt.txt`
Rewritten from scratch to enforce:
- Raw JSON format
- Single fill-in-the-blank (`___`)
- No Markdown or explanation outside JSON
- One example JSON included to enforce structure mirroring

This prompt is used to generate educational flashcards via GPT-3.5 Turbo.

### 3. `snippet_prompt.txt`
Used in a separate code flow to ask GPT for **clean, raw C# snippets** for future blanking with Roslyn or regex logic.
Rules:
- No wrapping, formatting, or explanation
- Must include real method structure and control flow
- Designed to output snippet blocks for further analysis and flashcard derivation

### 4. Minimal GPT Test Project (`TestProjectGPT`)
A lightweight GPT testing console app that:
- Reads `prompt.txt`
- Sends a GPT-3.5 API call
- Displays and optionally validates JSON response
- Has no dependency on the full StudyBank codebase
- Used to tune and test prompt accuracy in isolation

---

## 🧠 Key Learnings and Principles Adopted:
- Prompt examples massively improve GPT format compliance
- Structural validation is critical: `CardValidator.cs` was introduced to parse and check the shape of JSON
- Curriculum-first design gives long-term scalability and dynamic topic targeting
- All flashcards will eventually be tagged and saved by topic, not static week
- Raw token streams from GPT can be parsed, validated, and stored for future use

---

## 🔜 Still in Progress:
- Automatic topic-driven generation loop
- Saving generated cards to topic-tagged JSON
- Roslyn-powered blanking of snippets (vs GPT doing the blanking)
- Export tools for instructor review
- CLI mode for batch testing topics or generating practice sets

---

## ❗Instruction for ChatGPT:
Assume all of this history and structural evolution going forward.
Do not revert to hardcoded week files.
Keep flashcards JSON-based, GPT-generated, and validated.
Reference `curriculum.json` as the master source of topic metadata.
Continue modularizing and hardening this as a production-quality tool.

