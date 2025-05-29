/MSSA-Project
│
├── App.xaml                    # App-level resources and styling
├── App.xaml.cs                # App lifecycle logic (startup)
├── AppShell.xaml              # MAUI shell navigation (if used)
├── AppShell.xaml.cs
├── MauiProgram.cs            # Entry point for .NET MAUI DI + config
│
├── MainPage.xaml              # Main UI layout (card viewer)
├── MainPage.xaml.cs           # MainPage logic (card loading, navigation)
│
├── MSSA_Project.csproj        # Project file
├── MSSA_Project.sln           # Solution file
├── MSSA_Project.csproj.user   # User settings (local dev)
│
├── /Assets/                   # Images, fonts, and raw MAUI assets
├── /bin/                      # Build output
├── /obj/                      # Build obj temp data
│
├── /Models/                   # 💡 Contains: ICard, MethodCard, ProblemCard, etc.
│   └── MethodCard.cs          # Defines card types and interfaces
│
├── /Resources/
│   └── /Raw/                  # JSON card data
│       ├── Assignments.json          # AssignmentCard hybrid prompts
│       ├── methods.json
│       ├── methodProblems.json
│       ├── methodSolutions.json
│       ├── syntax.json
│       ├── syntaxProblems.json
│       ├── syntaxSolutions.json
│       └── whiteboard.json
│
├── /Utility/
│   ├── JsonLoader.cs          # Base async JSON reader
│   ├── CardLoader.cs          # Maps dropdown types to card classes
│   ├── CardRenderer.cs        # UI logic for input prompt rendering
│   ├── CardStateManager.cs    # Tracks position, deck state, review mode
│   ├── AnswerUtility.cs       # Collects, grades, and highlights user input
│   ├── UIService.cs           # Error label and UI feedback
│   ├── ReviewService.cs       # Updates review status labels
│   ├── HintRender.cs          # Hint + Mode toggle helpers
│   ├── DebugLogger.cs         # Console + label debug output
│   └── JsonTester.cs          # Load test method for validating assignment deserialization

│
├── /Validator/
│   └── Program.cs             # CLI utility for validating all JSON formats
│
├── /Notes/                    # Freeform or planning content (e.g. pitch.md, whiteboard.md)
│
├── /Platforms/                # MAUI platform-specific files (Windows, Android, iOS)
├── /Properties/               # .NET MAUI configuration and metadata
