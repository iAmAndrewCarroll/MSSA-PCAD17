/*
============================================================
Assignment 2.1 – Part 3: Abstract Class Shape Area Calculator
============================================================

This file demonstrates how to use an abstract base class to enforce structure and behavior
across multiple derived classes.

Key Concepts:
-------------
- Instantiation is the process of creating a real object from a class.  
    - Classes are blueprints that define structure and behavior
    - Instantiation is when you actually build something from the blueprint
- An abstract class (Shape) cannot be instantiated directly.
  It acts as a blueprint, defining shared properties (Id, Name, Color) and requiring that all
  derived classes implement their own version of the abstract method CalculateArea().

- Circle and Square both inherit from Shape.
  They provide their own logic for how to calculate area based on their specific dimensions.

- The user selects a shape and enters the required values at runtime — no hardcoded values.
  The program then displays the shape's information and the calculated area.

This approach demonstrates inheritance, encapsulation, method overriding,
and polymorphism (a Shape variable calling the correct child method).
*/

/*
====================================================
Flow Guide
====================================================

This table walks through the step-by-step execution of the abstract
shape calculator. It shows how user input is routed into concrete
subclasses, how values are stored, and how polymorphic behavior is triggered.

| Step | What Happens                                           | Where It Happens                          |
|------|--------------------------------------------------------|-------------------------------------------|
| 1    | User selects Circle or Square from menu               | `Console.ReadLine()` + `switch (choice)`  |
| 2    | Corresponding factory method is called                | `CreateCircle()` or `CreateSquare()`      |
| 3    | Shape-specific input is gathered using Utilities      | `ReadInt`, `ReadString`, `ReadPositiveDouble` |
| 4    | An object (Circle or Square) is returned              | via object initializer                    |
| 5    | Object is assigned to Shape variable (polymorphism)   | `Shape shape = new Circle();`            |
| 6    | `Describe` block prints shape details using getters   | `shape.Name`, `shape.Color`, etc.        |
| 7    | `shape.CalculateArea()` calls correct override        | Circle → `πr²`, Square → `side²`         |
| 8    | Area result is printed, user pauses before loop       | `Console.WriteLine(...) + Utilities.Pause()` |

Concepts Reinforced:
---------------------
- Abstract class as a blueprint (`Shape`)
- Method overriding via `override CalculateArea()`
- Object initialization using properties
- Enum-free class branching using polymorphic references
- Factory Methods: return a constructed object (new Circle { ... }), encapsulate
    the setup/initialization logic and are named methods that build a class instance
- Factory methods are NOT constructors.  public Circle { ... } is a constructor
*/


using Assignment_Tools; // toolbox access: input validation, pause, delay, etc.

namespace Assignment2_1
{
    public class Part3
    {
        public static void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-- Assignment 2.1 Part 3: Abstract Shape Area Calculator --");
                Console.WriteLine("This demonstrates:");
                Console.WriteLine("  - Abstract base classes and method overriding");
                Console.WriteLine("  - Dynamic object creation using user input");
                Console.WriteLine("  - Encapsulation and polymorphic behavior\n");

                Console.WriteLine("Choose a shape:");
                Console.WriteLine("1 - Circle");
                Console.WriteLine("2 - Square");
                Console.WriteLine("3 - Return to Main Menu");
                Console.Write("Choice: ");
                string choice = Console.ReadLine()?.Trim() ?? "";

                Shape shape;

                switch (choice)
                {
                    case "1":
                        shape = CreateCircle();
                        break;

                    case "2":
                        shape = CreateSquare();
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        Utilities.Pause();
                        continue;
                }

                Console.WriteLine($"\nShape Info:");
                Console.WriteLine($"ID: {shape.Id}");
                Console.WriteLine($"Name: {shape.Name}");
                Console.WriteLine($"Color: {shape.Color}");
                Console.WriteLine($"Calculated Area: {shape.CalculateArea():F2}");

                Utilities.Pause();
            }
        }
        
        // Prompt for and return a Circle object
        // This is a Factory Method: it hides the complexity of collecting input, returns
        // ready-to-use Circle object and keeps Run() clean and readable
        private static Circle CreateCircle()
        {
            Console.Clear();
            Console.WriteLine("Creating a Circle:\n");

            int id = Utilities.ReadInt("Enter Shape ID: ");
            string name = Utilities.ReadString("Enter Shape Name: ");
            string color = Utilities.ReadString("Enter Color: ");
            double radius = Utilities.ReadPositiveDouble("Enter Radius: ");

            return new Circle
            {
                Id = id,
                Name = name,
                Color = color,
                Radius = radius,
            };
        }

        // Prompt for and return a Square object
        private static Square CreateSquare()
        {
            Console.Clear();
            Console.WriteLine("Creating a Square:\n");

            int id = Utilities.ReadInt("Enter Shape ID: ");
            string name = Utilities.ReadString("Enter Shape Name: ");
            string color = Utilities.ReadString("Enter Color: ");
            double side = Utilities.ReadPositiveDouble("Enter Side Length: ");

            return new Square
            {
                Id = id,
                Name = name,
                Color = color,
                SideLength = side
            };
        }

        // Abstract class Shape: cannot be instantiated directly
        public abstract class Shape // more clearly, can be inherited but not used directly
        {   
            // shared properties that every shape has
            public int Id { get; set; }
            public string Name { get; set; }
            public string Color { get; set; }

            // This is a method contract - any subclass MUST define how to calculate area
            public abstract double CalculateArea();
        }

        // Circle inherits from Shape and implements CalculateArea
        public class Circle : Shape
        {
            public double Radius { get; set; } // inherits Id, Name & Color from Shape

            public override double CalculateArea() // provides its own logic for CalculateArea()
            {
                return Math.PI * Radius * Radius;
            }
        }

        // Square inherits from Shape and implements CalculateArea
        public class Square : Shape
        {
            public double SideLength { get; set; }

            public override double CalculateArea()
            {
                return SideLength * SideLength;
            }
        }
    }
}
