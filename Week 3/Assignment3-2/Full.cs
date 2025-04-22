using System;
using Assignment_Tools;

namespace Assignment3_2
{
    public class Full
    {
        public static void Run()
        {
            while (true)
            {
                string choice = Utilities.DisplayMenu("Assignment 3-2 Menu", new[]
                 {
                    "1. Print 2D Array as Matrix",
                    "2. Add Two Square Matrices",
                    "3. Operator Overloading: Circle Area (+ / -)",
                    "4. Total and Average (params + out)",
                    "5. Find Index of Item in Array",
                    "Return to Main Menu"
                });

                switch (choice)
                {
                    case "1":
                        DisplayMatrix();
                        break;
                    case "2":
                        AddSquareMatrices();
                        break;
                    case "3":
                        CompareCircles();
                        break;
                    case "4":
                        CalculateStats();
                        break;
                    case "5":
                        SearchIndex();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid selection.");
                        Utilities.Pause();
                        break;
                }
            }
        }

        // 1. Display a static 2D array formatted as a matrix
        private static void DisplayMatrix()
        {
            int[,] matrix = { { 2, 3, 4 }, { 1, 4, 6 } };

            Console.WriteLine("\nMatrix Output:");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"| {matrix[row, col]} ");
                }
                Console.WriteLine("|");
            }

            Utilities.Pause();
        }

        // 2. Add two square matrices of same size (<= 4x4)
        private static void AddSquareMatrices()
        {
            int size = Utilities.ReadIntInRange("Enter size of square matrix (max 4): ", 1, 4);

            int[,] first = new int[size, size];
            int[,] second = new int[size, size];
            int[,] sum = new int[size, size];

            Console.WriteLine("\nInput elements for first matrix:");
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    first[i, j] = Utilities.ReadInt($"Element [{i},{j}]: ");

            Console.WriteLine("\nInput elements for second matrix:");
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    second[i, j] = Utilities.ReadInt($"Element [{i},{j}]: ");

            // Calculate sum
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    sum[i, j] = first[i, j] + second[i, j];

            Console.WriteLine("\nFirst Matrix:");
            PrintMatrix(first);

            Console.WriteLine("\nSecond Matrix:");
            PrintMatrix(second);

            Console.WriteLine("\nSum of Matrices:");
            PrintMatrix(sum);

            Utilities.Pause();
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        // 3. Operator overloading: + and - on circle areas
        private static void CompareCircles()
        {
            double r1 = Utilities.ReadPositiveDouble("Enter radius of first circle: ");
            double r2 = Utilities.ReadPositiveDouble("Enter radius of second circle: ");

            Circle c1 = new Circle(r1);
            Circle c2 = new Circle(r2);

            Console.WriteLine($"\nArea of Circle 1: {c1.Area:F2}");
            Console.WriteLine($"Area of Circle 2: {c2.Area:F2}");
            Console.WriteLine($"Sum of Areas (c1 + c2): {c1 + c2:F2}");
            Console.WriteLine($"Difference of Areas (c1 - c2): {c1 - c2:F2}");

            Utilities.Pause();
        }

        // 4. Total and Average with params array and out return
        private static void CalculateStats()
        {
            int[] numbers = new int[4];
            for (int i = 0; i < 4; i++)
            {
                numbers[i] = Utilities.ReadInt($"Enter number {i + 1}: ");
            }

            int total;
            double average;
            ComputeTotalAndAverage(out total, out average, numbers);

            Console.WriteLine($"\nThe average of {string.Join(" , ", numbers)} is: {average:F2}");
            Console.WriteLine($"The total is: {total}");

            Utilities.Pause();
        }

        private static void ComputeTotalAndAverage(out int total, out double average, params int[] values)
        {
            total = 0;
            foreach (int val in values)
            {
                total += val;
            }

            average = (double)total / values.Length;
        }

        // 5. Search for an item in an array and return its index or -1
        private static void SearchIndex()
        {
            int[] array = { 1, 5, 3 };
            int target = Utilities.ReadInt("Enter item to search for: ");

            int index = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    index = i;
                    break;
                }
            }

            Console.WriteLine($"Index of {target}: {index}");
            Utilities.Pause();
        }
    }
}