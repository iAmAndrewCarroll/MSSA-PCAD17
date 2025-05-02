# MSSA Final Project: C# Flashcard Tutor

## Problem Statement

Students in a new learning environment can struggle to retain and 
    apply fundamental C# concepts taught in the initial weeks of a course. Traditional 
    study methods may not provide the repetitive practice and immediate feedback necessary 
    for mastery. There is a need for an interactive, scalable tool that reinforces key 
    programming patterns and prepares students for whiteboard interviews.

## Proposed Solution

Develop a console-based C# flashcard application that covers topics relevant to the MSSA curriculum. 
The application will present users with various types of flashcards, including fill-in-the-blank 
syntax drills and multiple choice. Flashcard data will be stored 
in JSON format for flexibility and scalability. Integration with the GPT-3.5 API will provide 
dynamic explanations and content generation, enhancing the learning experience.

## Project Objectives

- Reinforce key C# concepts via interactive flashcards.
- Utilize JSON for modular and scalable flashcard data management.
- Integrate GPT-3.5 for dynamic content generation and explanations.
- Design a clean, maintainable, and extensible codebase adhering to DRY principles.
- Offer a new tool to help practice whiteboard interviews by simulating relevant questions.

## Project Structure


```
/StudyBank
│
├── Program.cs               // Entry point and main menu
├── FlashCardRunner.cs       // Handles flashcard sessions
├── GPTTutor.cs              // Interfaces with GPT-3.5 API
├── /FlashCards
│   ├── FlashCard.cs         // Base class for flashcards
│   ├── FillInCard.cs        // Derived class for fill-in-the-blank cards
│   ├── DynamicFillInCard.cs // Derived class for dynamic fill in cards
│   └── MultipleChoiceCard.cs // Derived class for multiple choice cards
└── /Helpers
    ├── BlankGenerator.cs    // Generates blanks for fill-in-the-blank cards
    ├── CardValidator.cs     // Validates fill-in-card
    ├── CodeSnippetLoader.cs // Loads internal project code snippets to create fill-in-the-blank cards
    ├── FlashCardLoader.cs   // Loads flashcards from JSON
    ├── RoslynBlanker  .cs   // Leverages Microsoft Code Analysis for C# Syntax
    ├── FlashCardLoader.cs   // Loads flashcards from JSON
    ├── TopicLoader.cs       // Creates a dictionary of curriculums
    └── Utilities.cs         // Common utility functions
```


## Development Checklist

### Week 1: Project Initialization

- [ ] Set up GitHub repository with the outlined structure
- [ ] Implement base `FlashCard` class and derived classes
- [ ] Develop JSON schema for flashcards

### Week 2: Core Functionality

- [ ] Create `FlashCardLoader` to parse JSON files
- [ ] Implement `FlashCardRunner` to handle sessions
- [ ] Design and populate `Week1.json` with sample flashcards

### Week 3: GPT Integration

- [ ] Integrate GPT-3.5 API via `GPTTutor`
- [ ] Enhance `FlashCardRunner` to utilize GPT explanations
- [ ] Develop flashcards for Weeks 2–4

### Week 4: Testing and Documentation

- [ ] Conduct thorough testing and debugging
- [ ] Prepare documentation and user guide
- [ ] Finalize project for submission and GitHub release

## Key Considerations

- **Scalability**: Design the system to easily incorporate additional weeks and topics.
- **Maintainability**: Ensure code is clean, well-documented, and adheres to DRY principles.
- **User Experience**: Focus on intuitive navigation and clear prompts within the console application.
- **GPT Integration**: Implement robust error handling for API interactions and provide fallback explanations when necessary.

## Next Steps

1. **Set Up Repository**: Initialize a GitHub repository with the outlined structure.
2. **Develop Base Classes**: Implement `FlashCard` and its derived classes in the `/FlashCards` directory.
3. **Design JSON Schema**: Define a consistent format for flashcard data in JSON files.
4. **Implement Loader and Runner**: Develop `FlashCardLoader` and `FlashCardRunner` to handle data parsing and session management.
5. **Integrate GPT-3.5**: Set up `GPTTutor` to fetch explanations and generate dynamic content.
6. **Populate Flashcards**: Create and test flashcards for Weeks 1–4, ensuring coverage of key concepts.
7. **Testing and Documentation**: Conduct comprehensive testing and prepare user documentation.
