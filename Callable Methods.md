/*
=============================================================================
UTILITIES METHOD INDEX (CALLABLES OVERVIEW)
=============================================================================

-- INPUT METHODS (Validated Console Input) ----------------------------------
ReadInt(string prompt)
    → Get a whole number from the user.

ReadPositiveInt(string prompt)
    → Get a whole number greater than 0.

ReadIntInRange(string prompt, int min, int max)
    → Get a number within a specific range (e.g., age 0–130).

ReadDouble(string prompt)
    → Get any decimal number.

ReadPositiveDouble(string prompt)
    → Get a decimal number greater than 0.

ReadNonEmptyString(string prompt)
    → Require the user to enter something—not blank or whitespace.

-- ARRAY UTILITIES ----------------------------------------------------------
PrintArray<T>(T[] array)
    → Print any array of any type (int[], double[], string[], etc.).

ReverseArray<T>(T[] array)
    → Return a new array with the contents reversed.

-- FLOW CONTROL & LOGIC ROUTING ---------------------------------------------
Delay(int milliseconds = 799)
    → Pause the app without freezing (for animation or UX pacing).

Pause(string message = "Press ENTER to continue...")
    → Pause until the user presses ENTER.

Confirm(string question)
    → Prompt the user with (y/n) and return true/false.

PromptFollowUpMenu(string[] options)
    → Print a menu like "1 - Try Again" and return the selected number as a string.

DisplayMenu(string title, string[] options)
    → Print a full menu with a heading and options, then return the user’s choice.

GetIndexedChoice(string label, int count, bool includeCancel = true)
    → Select a numbered item from a list (e.g., choosing a person to edit).

-- CONSOLE UI OUTPUT TOOLS --------------------------------------------------
DrawBox(string[] lines)
    → Draw a nice boxed menu or header with custom text lines.

OverwriteLine(int lineNumber, string message)
    → Write text at a fixed console line (used for dynamic UIs).

ClearLines(int fromLine, int toLine)
    → Erase multiple lines in the console (used for redrawing menu sections).

=============================================================================
Each method is DRY, safe, switch-friendly, and reusable across all modules.
All methods tested against Assignments 1.1 to 1.3 and built for future scale.
=============================================================================
*/
