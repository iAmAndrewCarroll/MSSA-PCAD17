using System;
using System.Collections.Generic;

namespace FrequencyCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Prompt user for array size
            Console.Write("Input the number of elements to be stored in the array: ");
            int size = ReadPositiveInt();

            int[] numbers = new int[size];

            // 2. Collect array elements
            Console.WriteLine($"Input {size} elements in the array:");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"element - {i} : ");
                numbers[i] = ReadInt();
            }

            // 3. Count frequencies using a Dictionary
            Dictionary<int, int> frequencies = new Dictionary<int, int>();

            foreach (int num in numbers)
            {
                if (frequencies.ContainsKey(num))
                    frequencies[num]++;
                else
                    frequencies[num] = 1;
            }

            // 4. Display frequency output
            Console.WriteLine("\nFrequency of all elements of array:");
            foreach (var pair in frequencies)
            {
                Console.WriteLine($"{pair.Key} occurs {pair.Value} times");
            }
        }

        // Helper: Read any int
        static int ReadInt()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int value))
                    return value;

                Console.Write("Invalid input. Enter a whole number: ");
            }
        }

        // Helper: Read positive int (for array size)
        static int ReadPositiveInt()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int value) && value > 0)
                    return value;

                Console.Write("Please enter a number greater than 0: ");
            }
        }
    }
}
