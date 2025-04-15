# Assignment 2.3 – File I/O and Tip Calculator

## Overview

This assignment demonstrates two foundational C# programming concepts:

1. **Reading from and writing to text files** using helper methods and `StreamReader` / `StreamWriter`
2. **Performing percentage-based calculations** (tip logic) with properly formatted currency and percent output

Both parts reinforce DRY structure and clean, reusable logic using `Utilities.cs`.

---

## Part 1: Write and Read Personal Info (File I/O)

### Description

The program creates a text file called `PersonalInfo.txt`, writes dummy personal details into it (name, age, address), then reads and displays the file contents back in the console.

### Concepts Reinforced

- File creation and overwriting
- StreamWriter and StreamReader use via helper methods
- Text formatting with `Environment.NewLine`
- Encapsulation of I/O logic into `Utilities.cs`

### File I/O Flow

| Step | What Happens                             |
|------|------------------------------------------|
| 1    | Dummy data is defined (name, age, etc.)  |
| 2    | File path is set                         |
| 3    | File is created and written using helper |
| 4    | File is closed safely via `using` block  |
| 5    | File is re-opened and read completely    |
| 6    | Contents are printed to console          |

---

## Part 2: Tip Calculator with Format Specifiers

### Description

Prompts the user for a bill total and a tip %, calculates the tip amount and grand total, and displays all results formatted using currency and percent symbols.

### Concepts Reinforced

- Numeric input and validation
- Basic arithmetic (percentage of a number)
- Format specifiers for clean console output
- DRY interaction using `Utilities.ReadDouble()`

### Tip Calculation Flow

| Step | What Happens                             |
|------|------------------------------------------|
| 1    | User enters bill amount                  |
| 2    | User enters tip percentage               |
| 3    | Tip amount is calculated                 |
| 4    | Grand total is calculated                |
| 5    | Values printed with formatting           |
| 6    | Pause before return to menu              |

---

## Program Structure

```text
Assignment2-3/
├── Program.cs         // Main menu dispatcher
├── Part1.cs           // File write/read logic
├── Part2.cs           // Tip calculator logic
├── Utilities.cs       // Reusable helpers (input, pause, file I/O)
```
| syntax | Description |
|------------|-------------------------|
| `{value:C}` | Currency $12.34 |
| `{value}%` | Percent 12% |
