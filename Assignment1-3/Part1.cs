using System; // access to the C# system tools

namespace Assignment1_3 // helps organize files under main project
{
    public class Part1 // defines the class that groups everything for this portion of assignment; triangle/square/rectangle logic
    {
        public static void Run() // method that the main menu will call when Part 1 is selected
        {
            while (true) // loop to allow retry or exit to main menu
            {
                // displays options for shape area calculations
                Console.WriteLine("\n-- Area Calculator Menu --");
                Console.WriteLine("1 - Triangle");
                Console.WriteLine("2 - Square");
                Console.WriteLine("3 - Rectangle");
                Console.WriteLine("4 - Circle");
                Console.WriteLine("5 - Return to Main Menu");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine(); // stores user menu selection as string

                // switch evaluates the user selection to call the corresponding function
                switch (choice)
                {
                    case "1":
                        CalculateTriangleArea();
                        break;
                    case "2":
                        CalculateSquareArea();
                        break;
                    case "3":
                        CalculateRectangleArea();
                        break;
                    case "4":
                        CalculateCircleArea();
                        break;
                    case "5":
                        Console.Clear();
                        return; // back to Program.cs main menu
                    default:
                        Console.WriteLine("Bad Selection. Try again."); // gracefully handles unexpected input
                        break;
                }
            }
        }

        // method handling the calculation of the area of a triangle using (base * height) / 2
        private static void CalculateTriangleArea()
        {
            Console.Write("\nEnter the base of the triangle: ");
            bool baseValid = double.TryParse(Console.ReadLine(), out double baseLength);
            // TryParse checking if input can be converted to double without crashing

            Console.Write("Enter the height of the triangle: ");
            bool heightValid = double.TryParse(Console.ReadLine(), out double height);

            // checking that both inputs are valid numbers and positive
            if (!baseValid || !heightValid || baseLength <= 0 || height <= 0)
            {
                Console.WriteLine("Bad input. Enter positive numeric values.");
                return;  // exit this function and return to menu
            }

            double area = (baseLength * height) / 2; // area formula
            Console.WriteLine($"Area of the triangle: {area}"); // displays results to user
        }

        // method handling the calculation of the area of a triangle using: side * side
        private static void CalculateSquareArea()
        {
            Console.Write("\nEnter the length of the square: ");
            bool sideValid = double.TryParse(Console.ReadLine(), out double side);
            // TryParse again makes sure that input can be used as a number

            // makes sure side value is a positive number
            if (!sideValid || side <= 0)
            {
                Console.WriteLine("Bad input! Please enter a positive numeric value.");
                return; // exit method if invalid input
            }

            double area = side * side; // area formula
            Console.WriteLine($"Area of the square: {area}");
        }

        // method handling the area of a rectangle: length * width
        private static void CalculateRectangleArea()
        {
            Console.Write("\nEnter the length of the rectangle: ");
            bool lengthValid = double.TryParse(Console.ReadLine(), out double length);
            // TryParse again makes sure that input can be used as a number

            Console.Write("Enter the width of the rectangle: ");
            bool widthValid = double.TryParse(Console.ReadLine(), out double width);

            // check if both values are positive numbers
            if (!lengthValid || !widthValid || length <= 0 || width <= 0)
            {
                Console.WriteLine("Bad Input! There is enough negativity in the world, try a positive value.");
                return;
            }

            double area = length * width; // area formula
            Console.WriteLine($"Area of the rectangle: {area}");
        }

        // method handling the area of a circle: 3.14r2
        private static void CalculateCircleArea()
        {
            Console.WriteLine("\nEnter the radius of the circle: ");
            bool radiusValid = double.TryParse(Console.ReadLine(), out double radius);
            // TryParse checks to make sure that input can be used as a number

            // check if radius value is positive number
            if (!radiusValid || radius <= 0)
            {
                Console.WriteLine("Bad Input! Circlular radii must be positive.");
                return; // exit if input is bad
            }

            // Math.Pow(base, exponent) is used to raise a number to a power (Pow)
            // Math.PI provides the full precision value of pi 
            double area = Math.PI * Math.Pow(radius, 2);

            Console.WriteLine($"Area of the circle: {area}");
        }
    }
}
