# Whiteboard Interview Framework

## Step 1: Repeat the Problem

Restate the task in your own words to show understanding and clarify the objective.

Examples:
- "Write a program that calculates the area of a shape based on user input."
- "This feature reads numbers from the user and prints them in reverse order."

--------------------------------------------------------------------------------

## Step 2: Ask Clarifying Questions

List any assumptions, input types, edge conditions, and scope constraints.

Sample prompts:
- Will input always be numeric?
- Should we validate against negatives or zero?
- Is there a max/min value range?
- What happens on invalid input?
- Are decimals allowed?
- Should output be printed, returned, or both?
- Should the program loop or exit after one run?

--------------------------------------------------------------------------------

## Step 3: Work Through Examples by Hand

Do 1–2 quick test cases manually to ensure logic is sound.

Examples:
Triangle:
- Base = 10, Height = 5 → Area = (10 * 5) / 2 = 25

Reverse Array:
- Input = [1, 2, 3, 4] → Output = [4, 3, 2, 1]

--------------------------------------------------------------------------------

## Step 4: State Your Plan (Pseudocode)

Describe how you will approach the problem step-by-step.

Examples:
- Prompt user for input
- Validate that input is numeric and positive
- Apply correct formula based on shape
- Display result
- Prompt to run again or return to menu

Optional: Include short pseudocode block:

// Example pseudocode
Prompt for base and height
If valid: area = (base * height) / 2
Else: display error
Print result

--------------------------------------------------------------------------------

## Step 5: Write the Code

Use clean, DRY, modular code with inline teaching comments.

Example:
double base = Utilities.ReadPositiveDouble("Enter base: ");
double height = Utilities.ReadPositiveDouble("Enter height: ");
double area = (base * height) / 2;
Console.WriteLine($"Area of triangle: {area}");

--------------------------------------------------------------------------------

## Step 6: Test Edge Cases

Document what edge conditions you tested.

Examples:
- Negative numbers → rejected
- Zero → rejected
- Decimal input → accepted
- Large values → confirmed no crash
- Non-numeric input → handled gracefully with TryParse

--------------------------------------------------------------------------------

## Step 7 (Optional): Refactor or Optimize

Ask:
- Can you move repeated logic to Utilities.cs?
- Can your shape logic use a shared method?
- Can the loop or menu be cleaned up?
- Is there a more efficient data structure?

