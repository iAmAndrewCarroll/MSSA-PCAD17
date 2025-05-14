using System;

namespace Challenge_Lab_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Challenge Lab 6 - 90 Degree Image Rotation of a 2D Matrix");
            Console.WriteLine();
            Console.WriteLine("restate the problem: " +
                "\ngiven an n x n 2D matrix representing " +
                "\nan image : rotate the image 90 degrees clockwise");
            Console.WriteLine();

            int[][] matrix = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 },
            };

            Console.WriteLine("Original Matrix: ");
            PrintMatrix(matrix);
            Console.WriteLine();
            
            Matrix90.Transpose(matrix);
            Console.WriteLine("\nAfter Transpose: ");
            PrintMatrix(matrix);

            Matrix90.ReverseRows(matrix);
            Console.WriteLine("\nNow Reverse Rows completing 90 degree clockwise rotation:");
            PrintMatrix(matrix);
        }

        static void PrintMatrix(int[][] matrix)
        {
            foreach (int[] row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
            Console.ReadKey();
        }

    }
}