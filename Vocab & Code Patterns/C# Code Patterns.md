# C# Assignment 1.1 – Technical ELI5 Code Patterns

| Code Pattern | Beginner-Friendly Definition | Example Usage |
|--------------|------------------------------|----------------|
| `int i = 0; i < count; i++` | This is a loop structure that runs a block of code multiple times. It starts with `i = 0`, checks if `i` is less than `count`, runs the code, then increases `i` by 1. It’s used to go through items one by one or repeat something a set number of times. | `for (int i = 0; i < people.Count; i++) { Console.WriteLine(people[i].Name); }` |
| `if (!valid)` | This means 'if NOT valid.' The exclamation mark `!` means 'not.' So this runs the next block of code if a value is false (invalid). It's used for error checking or handling unexpected input. | `if (!validAge) { Console.WriteLine("Invalid age"); continue; }` |
| `if (!TryParse(...))` | `TryParse` attempts to convert a string into a number (like '25' into 25). If it fails, it doesn't crash—just returns false. The `!` checks if it failed, so we can respond safely if the input was bad. | `if (!int.TryParse(input, out number)) { Console.WriteLine("Invalid input"); continue; }` |
| `if (string.IsNullOrWhiteSpace(input))` | This checks if the input is empty or just spaces. It helps ensure that the user actually typed something meaningful. Prevents saving blank data. | `if (string.IsNullOrWhiteSpace(newPerson.Name)) { Console.WriteLine("Name cannot be empty"); continue; }` |
| `List<Type> list = new List<Type>();` | A `List` is a dynamic collection—it grows as needed. You can add, remove, or access items by index. It’s like an expandable array. | `List<Person> people = new List<Person>();` |
| `list[index - 1]` | Lists count from 0, but users think in terms starting from 1. So if the user picks option 2, we access index 1. This adjusts user-friendly input to system indexing. | `Person person = people[index - 1];` |
| `while (true)` | An infinite loop. It keeps running the same block of code until something inside it breaks or returns. Common in menus or programs that wait for user actions. | `while (true) { ShowMenu(); if (choice == "4") return; }` |
| `Console.Write("..."); Console.ReadLine();` | This pair shows a message to the user and waits for them to type something. `ReadLine()` captures their input as text. | `Console.Write("Enter age: "); string input = Console.ReadLine();` |
| `break;` | Stops the current loop immediately and moves on to the next part of the program. Useful to escape early. | `if (choice == "1") { break; }` |
| `continue;` | Skips the rest of the current loop’s code and jumps to the next iteration. Used to skip invalid cases without stopping the whole loop. | `if (!valid) { Console.WriteLine("Invalid"); continue; }` |
| `return;` | Ends a method early and optionally returns a value. It hands control back to the caller. | `if (choice == "4") { return; }` |
| `out int variable` | `out` lets a method give back multiple outputs. With `TryParse`, it means 'if this worked, put the result into this variable.' | `int.TryParse(input, out int result)` |
| `Console.WriteLine($"Name: {obj.Name}")` | This is called string interpolation. It lets you embed variables inside a string by wrapping them in curly braces `{}` and prefixing the string with `$`. | `Console.WriteLine($"Age: {person.Age}");` |
| `int quotient = a / b; int remainder = a % b;` | This divides one number by another. `/` gives the whole-number result (quotient), `%` gives what’s left over (remainder). | `int q = dividend / divisor; int r = dividend % divisor;` |
| `choice == "1"` | Checks if the user's input is exactly equal to the string "1". It's a string comparison, used for menu selections. | `if (choice == "1") { RunAddPerson(); }` |
| `runningTotal += value;` | `+=` means 'add this value to the current total.' It’s shorthand for: `runningTotal = runningTotal + value;` | `runningTotal += addVal;` |
