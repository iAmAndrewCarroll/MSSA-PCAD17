using System;
using System.Threading;

namespace Assignment1_3
{
    public class Part1_a
    {
        public static void Run()
        {
            while (true)
            {
                DrawStaticBox(); // calculator "box" area

                OverwriteLine(9, "Select: ");
                int inputStartX = 2 + "Select: ".Length; // 2 for left box edge
                Console.SetCursorPosition(inputStartX, 9); // input line inside box
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "t":
                        HandleShape("Triangle", isTriangle: true);
                        break;
                    case "s":
                        HandleShape("Square");
                        break;
                    case "r":
                        HandleShape("Rectangle");
                        break;
                    case "c":
                        HandleCircle();
                        break;
                    case "5":
                        Console.SetCursorPosition(2, 9);
                        Console.WriteLine("Returning to main menu...");
                        Thread.Sleep(799); // pause for effect
                        Console.Clear();
                        return;
                    default:
                        OverwriteLine(10, "Bad Choices break programs. Try again.");
                        Console.ReadKey(true);
                        break;
                }
            }
        }

        private static void DrawStaticBox()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗"); // line 0
            Console.WriteLine("║          Area Calculator               ║"); // line 1
            Console.WriteLine("╠════════════════════════════════════════╣"); // line 2
            Console.WriteLine("║ t - Triangle                           ║"); // line 3 
            Console.WriteLine("║ s - Square                             ║"); // line 4
            Console.WriteLine("║ r - Rectangle                          ║"); // line 5
            Console.WriteLine("║ c - Circle                             ║"); // line 6
            Console.WriteLine("║ 5 - Return to Main Menu                ║"); // line 7
            Console.WriteLine("╠════════════════════════════════════════╣"); // line 8
            Console.WriteLine("║                                        ║"); // line 9
            Console.WriteLine("║                                        ║"); // line 10
            Console.WriteLine("║                                        ║"); // line 11
            Console.WriteLine("║                                        ║"); // line 12
            Console.WriteLine("╚════════════════════════════════════════╝"); // line 13
        }

        private static void OverwriteLine(int line, string message)
        {
            Console.SetCursorPosition(2, line);
            Console.Write(message.PadRight(38));
        }

        private static void ClearContentLines()
        {
            for (int i = 10; i <= 12; i++)
            {
                OverwriteLine(i, "");
            }
        }

        private static double CalculateArea(double a, double b, bool isTriangle = false)
        {
            return isTriangle ? (a * b) / 2 : a * b;
        }

        private static void HandleShape(string shape, bool isTriangle = false)
        {
            ClearContentLines();

            double first = PromptForInput(isTriangle ? "Enter base: " : $"Enter {shape.ToLower()} length:");
            double second = shape == "Square" ? first : PromptForInput(isTriangle ? "Enter height: " : $"Enter {shape.ToLower()} width: ");

            double area = CalculateArea(first, second, isTriangle);
            string label = isTriangle ? $"Base, Height: ({first:0.##}, {second:0.##})" : shape == "Square" ? $"Side: {first:0.##}" : $"Length, Width: ({first:0.##}, {second:0.##})";

            OverwriteLine(9, label);
            OverwriteLine(10, $"Area of the {shape.ToLower()}: {area:0.##}");
            Console.ReadKey(true);
        }

        private static void HandleCircle()
        {
            ClearContentLines();

            double radius = PromptForInput("Enter radius: ");
            double area = Math.PI * Math.Pow(radius, 2);

            OverwriteLine(9, $"Radius: {radius:0.##}");
            OverwriteLine(10, $"Area of the circle: {area:0.##}");
            Console.ReadKey(true);
        }
        
        private static double PromptForInput(string prompt)
        {
            double value;
            while (true)
            {
                OverwriteLine(10, prompt); // Line 10: Prompt line 
                int inputStartX = 2 + prompt.Length;
                Console.SetCursorPosition(inputStartX, 10); // adjust cursor after prompt

                string input = Console.ReadLine();
                bool valid = double.TryParse(input, out value) && value > 0;

                if (valid) break;

                OverwriteLine(12, "Invalid input. Use positive numbers.");
                Console.ReadKey(true);
                ClearContentLines();
            }

            return value;
        }
    }
}