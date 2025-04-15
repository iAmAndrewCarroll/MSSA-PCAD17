namespace Assignment2_1
{

    // public: Makes the method accessible from other files (Part2.cs w/ menu)
    // static: allows the method to be called on the class itself, without an object
    // - this means you don't need to say 'new Maths()' every time, just use Maths.Add() or Maths.Multiply().
    public static class Maths
    {
        // Add two integers
        public static int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        // Add three decimal values
        public static decimal Add(decimal num1, decimal num2, decimal num3)
        {
            return num1 + num2 + num3;
        }

        // Multiply two floats
        public static float Multiply(float num1, float num2)
        {
            return num1 * num2;
        }

        // Multiply three floats
        public static float Multilply(float num1, float num2, float num3)
        {
            return num1 * num2 * num3;
        }
    }
}

/* What it looks like when calling static vs non-static

class Program
{
    static void Main(string[] args)
    {
        // STATIC CALL – no object needed
        int result1 = Calculator.AddStatic(3, 4);
        Console.WriteLine($"Static result: {result1}");

        // NON-STATIC CALL – requires an object
        Calculator myCalc = new Calculator(); // create an instance of the class
        int result2 = myCalc.AddInstance(5, 6);
        Console.WriteLine($"Instance result: {result2}");
    }
}
*/

/*
===============================================
WHEN TO USE STATIC VS NON-STATIC METHODS
===============================================

| Use Case                                 | Static       | Non-Static         |
|------------------------------------------|--------------|--------------------|
| Utility functions (Add, Multiply, etc.)  | Yes          | No                 |
| General-purpose logic with no state      | Yes          | No                 |
| Actions that depend on object data       | No           | Yes                |
| Behavior tied to a specific instance     | No           | Yes                |
| Access via ClassName.Method()            | Yes          | No                 |
| Access via object.Method()               | No           | Yes                |

Summary:
- Use static methods for general-purpose, reusable logic that doesn't require an object.
- Use non-static methods when behavior depends on specific instance data (like Describe()).
- In this assignment, all Add and Multiply methods are static because they are universal tools that don't depend on any instance.
*/

