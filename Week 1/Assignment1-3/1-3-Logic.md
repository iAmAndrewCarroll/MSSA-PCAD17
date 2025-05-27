# Assignment 1.3 – Logic Overview

This document provides a clean, step-by-step logic breakdown for every part of Assignment 1.3, including how the main `Program.cs` file interacts with each module.

---

## Program.cs – Main Menu Controller

**Purpose**  
Controls user flow across all assignment modules.

**Logic Flow**
- Display main menu options:
  - 1 – Area Calculator (Part 1)
  - 2 – Array Exploration (Part 2)
  - 3 – Reverse Array Display (Part 3)
  - 4 – Exit Program
- Read user input
- Use `if` or `switch` to route to the correct `PartX.Run()` method
- Return to menu after each module unless user chooses to exit

---

## Part 1 – Geometry Area Calculator

**Objective**  
Calculate area of triangle, square, and rectangle using separate functions.

**Logic Flow**
- Begin `Part1.Run()`
- Display shape menu:
  - 1 – Triangle
  - 2 – Square
  - 3 – Rectangle
  - 4 – Return to Main Menu
- Based on selection:
  - Triangle:
    - Prompt for base and height
    - Validate inputs using `TryParse`
    - Compute `(base * height) / 2`
    - Display result
  - Square:
    - Prompt for side length
    - Validate input
    - Compute `side * side`
    - Display result
  - Rectangle:
    - Prompt for length and width
    - Validate inputs
    - Compute `length * width`
    - Display result
- After each calculation:
  - Ask user if they want to calculate another or return to main menu

---

## Part 2 – Exploring Arrays

**Objective**  
Demonstrate various array declarations, initializations, and `Array` class properties/methods.

**Logic Flow**
- Begin `Part2.Run()`
- Show examples of arrays:
  - Declare with fixed size: `int[] nums = new int[5];`
  - Initialize with values: `int[] nums = { 1, 2, 3 };`
- Demonstrate built-in methods and properties:
  - `Length`
  - `Array.Sort()`
  - `Array.Reverse()`
  - `Min` / `Max` (via `LINQ` or loop)
- Display results in console
- Offer option to repeat or return to main menu

---

## Part 3 – Reverse Array Display

**Objective**  
Accept `n` integers from user, store in array, then display forward and in reverse.

**Logic Flow**
- Begin `Part3.Run()`
- Prompt user for array size (`n`)
  - Validate `n` using `TryParse` and ensure > 0
- Create an array of size `n`
- Loop from 0 to n-1:
  - Prompt for and validate each element using `TryParse`
  - Store each number in the array
- After input:
  - Display values in original order
  - Display values in reverse order using:
    - Reverse loop (`for (int i = n - 1; i >= 0; i--)`)
    - Or `Array.Reverse()`
- Ask if user wants to run again or return to main menu

---

This logic outline ensures each part is modular, testable, and aligned with clean C# coding practices.