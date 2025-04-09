# C# Keywords and Functions

| Keyword/Function | Definition |
|------------------|------------|
| **Object-oriented / code structure** | |
| class | Defines a container for methods and fields; used to build objects or group logic. |
| declaration | Saying “I need a variable named X to hold a Y”. |
| field | A variable inside a class (like Name, Age in a Person). |
| initialization | Giving a variable its first value. |
| instantiate | To create a real object from a class using new. |
| method | An action a class or object can do (like Run(), Bark(), Calculate()). |
| object | A real thing created from a class; it holds data and can perform actions. |
| variable | A labeled box that stores a piece of data (number, word, object, etc.). |
|
| **Access modifiers / structure keywords** | |
| namespace | Defines a logical grouping for related classes and methods to avoid naming conflicts. |
| public | Makes a class or method accessible from outside its current file or namespace. |
| static | Means the method or variable belongs to the class itself rather than an instance. |
| using | Directive to include namespaces that provide access to classes and methods. |
| void | Specifies that a method does not return any value. |
|
| **Console & user interaction** | |
| Console.ReadLine() | Waits for the user to type something and hit enter, then returns it as text. |
| Console.Write() | Displays text to the console without adding a new line. |
| Console.WriteLine() | Displays a line of output to the console and moves to the next line. |
|
| **Conditionals and branching** | |
| break | Exits the current loop or switch statement. |
| case | Each possible match in a switch statement. |
| continue | Skips the rest of the loop body and starts the next loop cycle. |
| default | Runs if no switch case matches. |
| else | Runs a different block of code if the if condition was false. |
| if | Runs a block of code only when a specific condition is true. |
| return | Ends the current method and optionally sends a value back. |
| switch | A way to check many possible values of a variable and pick one block of code to run. |
|
| **Loops** | |
| for | A loop that runs a specific number of times, often using a counter. |
| foreach | Loops through every item in a collection. |
| while | Repeats a block of code while a condition is true. |
| while (true) | A loop that keeps running until you manually stop it. |
|
| **Logic & comparison** | |
| != | Checks if two values are not the same. |
| < | Checks if the left side is less than the right. |
| <= | Checks if the left side is less than or equal to the right. |
| == | Checks if two values are exactly the same. |
| > | Checks if the left side is greater than the right. |
| >= | Checks if the left side is greater than or equal to the right. |
|
| **Math & operators** | |
| % | Returns the remainder of a division. |
| * | Multiplies two values. |
| + | Adds two values. |
| - | Subtracts one value from another. |
| / | Divides one value by another. |
| Math.PI | Represents the mathematical constant pi. |
| Math.Pow | Performs exponentiation (raises a number to a specified power). |
|
| **Data types** | |
| bool | Stores true/false values for logic decisions. |
| double | Used to store decimal numbers, more precise than int. |
| int | Used to store whole numbers like 1, 42, or -7. |
| IsNullOrWhiteSpace | Checks if a string is null, empty, or only whitespace. |
| List<T> | A growable collection used to store multiple values of the same type. |
| out | Used with TryParse to store the result if the conversion succeeds. |
| Parse | Converts text into a number or other type, but will crash if the input is invalid. |
| string | Stores text, like names or typed input. |
| TryParse | Tries to convert text into a number or other type safely, without crashing. |
|
| **Arrays & collections** | |
| Array.Reverse() | Reverses the sequence of elements in the entire one-dimensional array. |
| Array.Sort() | Sorts the elements in a one-dimensional array in ascending order. |
| Count | Returns the number of items in a list. |
| Length | Gets the number of elements in the array. |
|
| **Timing & control** | |
| Environment.Exit() | Closes the entire program. |
| Thread.Sleep() | Pauses the program for a specific number of milliseconds. |
