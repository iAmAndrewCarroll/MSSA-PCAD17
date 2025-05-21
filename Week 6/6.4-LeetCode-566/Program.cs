using System;

namespace _6._4_LeetCode_566
{
    class Program
    {
        static void Main(string[] args)
        {
            // First Test Case
            int[][] mat1 = new int[][]
            {
                new int[] {1, 2 },
                new int[] {3, 4 },
            };

            int r1 = 1;
            int c1 = 4;

            Console.WriteLine("Test 1 - Reshape 2x2 to 1x4:");
            RunTestCase(mat1, r1, c1);

            // Second Test Case
            int[][] mat2 = new int[][]
            {
                new int[] {1, 2, 5, 9 },
                new int[] {3, 4, 7, 6 },
            };

            int r2 = 4;
            int c2 = 2;

            Console.WriteLine("Test 2 - Reshape 2x4 to 4x2:");
            RunTestCase(mat2, r2, c2);

            Console.ReadKey();

        }
        static void RunTestCase(int[][] mat, int r, int c)
        {
            Console.WriteLine("Original Matrix:");
            PrintMatrix(mat);

            int[][] reshaped = MatrixReshape.Reshape(mat, r, c);

            Console.WriteLine("Reshaped Matrix:");
            PrintMatrix(reshaped);
            Console.WriteLine();
        }
        static void PrintMatrix(int[][] matrix)
        {
            foreach (int[] row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}