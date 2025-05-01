PROJECT NAME: StudyBank / TestProjectGPT — GPT-Powered Flashcard Tutor

This document outlines the historical breakdown of the critical bugs, persistent build issues, and fragile architecture problems encountered during development. It is meant to be read alongside project_context_update.txt.

------------------------------------------------------------
1. Tight Coupling Between GPT Logic and FlashCard Model
------------------------------------------------------------
- GPTTutor.cs originally referenced FillInCard and FlashCardDTO within the StudyBank namespace.
- Attempting to use GPTTutor.cs in a clean test environment (like TestProjectGPT) caused:
  - CS0246: type or namespace 'FillInCard' not found
  - Broken builds unless the entire StudyBank codebase was copied in

Resolution:
- GPT testing was decoupled from GPTTutor.cs entirely.
- Minimal Program.cs now handles raw GPT response parsing directly.

------------------------------------------------------------
2. Redundant Assembly Metadata Errors (CS0579)
------------------------------------------------------------
Symptoms:
- dotnet build failed with:
  CS0579: Duplicate 'global::System.Runtime.Versioning.TargetFrameworkAttribute' attribute

Cause:
- Multiple .csproj files (StudyBank.csproj and GPTTester.csproj) under one solution with overlapping output folders and conflicting embedded metadata.

Resolution:
- Remove all obj/ and bin/ folders using:
  rm -rf obj/ bin/
- Ensure each .csproj file includes:
  <GenerateAssemblyInfo>false</GenerateAssemblyInfo>

------------------------------------------------------------
3. Hidden Entry Points (CS8892)
------------------------------------------------------------
Problem:
- Multiple Main() methods across the repo caused:
  CS8892: Method 'Main(string[])' will not be used as an entry point because another Main() was found.

Resolution:
- Renamed or archived secondary Program.cs files (e.g., moved TestGPT.cs to Archive/)
- Used dotnet run --project explicitly to control the entry point

------------------------------------------------------------
4. Build Conflicts from StudyBank.sln and GPTTester.csproj
------------------------------------------------------------
Problem:
- ProjectReference and multiple identical type declarations (e.g., TestRunner) caused:
  CS0436: type 'TestRunner' conflicts with imported type

Resolution:
- Removed or renamed TestRunner.cs
- Removed unnecessary ProjectReference lines
- Split the test and production builds entirely

------------------------------------------------------------
5. DotNetEnv Import Failure (CS0246)
------------------------------------------------------------
Symptoms:
- DotNetEnv.Env.Load(); failed
- CS0246: The type or namespace name 'DotNetEnv' could not be found

Resolution:
- Installed with: dotnet add package DotNetEnv
- Added using DotNetEnv; in Program.cs

------------------------------------------------------------
6. GPT Prompt Drift / Malformed JSON
------------------------------------------------------------
Symptoms:
- GPT returned code with no blanks
- Wrong JSON format
- Markdown-wrapped code

Causes:
- Missing prompt constraints
- No output mirroring (examples)

Resolution:
- Rewrote prompt.txt
- Added example JSON structure
- Added DO NOT instructions

------------------------------------------------------------
7. .env Not Working / Tracked by Git
------------------------------------------------------------
Problem:
- .env was committed by mistake
- Invisible in some editors

Resolution:
- git rm --cached .env
- echo ".env" >> .gitignore
- Recreated file with correct format:
  OPENAI_API_KEY=sk-...

------------------------------------------------------------
8. Prompt Misalignment: Fill-in-the-Blank Not Respected
------------------------------------------------------------
Problem:
- GPT returned full lines like:
  "Array.Sort(myArray);"
- Missing the required "___" placeholder

Cause:
- No example provided
- Instructions too loose

Resolution:
- Updated prompt.txt to include:
  - JSON-only output
  - Multi-line prompt
  - One blank per card
  - Example for output mirroring

------------------------------------------------------------
9. Clean Test Project Structure: TestProjectGPT
------------------------------------------------------------
- Program.cs only
- No StudyBank dependencies
- Uses DotNetEnv + raw GPT call
- Allows isolated testing of prompt quality and GPT behavior

------------------------------------------------------------
10. Persistent Build Failures from Forgotten Cleanup
------------------------------------------------------------
- Even after rm -rf obj/ bin/, Visual Studio would rebuild temp files.
- Caused ghost errors referencing deleted files or invalid entry points.

Resolution:
- Consistently cleaned folders
- Used dotnet clean and dotnet build from the correct root
- Reset Git state with git reset --hard HEAD
- Archived or deleted leftover files (like TestGPT.cs)

------------------------------------------------------------
Summary
------------------------------------------------------------
This project was originally structured by week and manually managed flashcards. It now relies on dynamic GPT generation seeded from a master curriculum.json.

All current GPT testing and validation is handled in a minimal shell project to avoid contamination or cascading errors from other parts of the StudyBank codebase.

Use this document for debugging reference and architectural awareness. All major changes should be validated in TestProjectGPT before reintegrating into the main StudyBank flow.
