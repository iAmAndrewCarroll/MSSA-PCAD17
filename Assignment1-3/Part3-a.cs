using System;
using System.Threading;

namespace Assignment1_3
{
	public class Part3_a
	{
		public static void Run()
		{
			while (true)
			{
				Console.Write("\nEnter the number of elements to store in the array: ");
				int size = GetPositiveIntFromUser();

				// Get the full array from the user using a reusable method
				int[] originalArray = GetArrayFromUser(size);

				Console.WriteLine("\nThe values stored in the array are:");
				PrintArray(originalArray); // clean display method

				Console.WriteLine("\nThe values stored in the array in reverse order are:");
				int[] reversedArray = ReverseArray(originalArray); // O(n), non-destructive
				PrintArray(reversedArray);

				// Offer user next-step options
				Console.WriteLine("\nWhat would you like to do?");
				Console.WriteLine("1 - Run Again");
				Console.WriteLine("2 - Return to Main Menu");
				Console.Write("Choice: ");

				string choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						continue;
					case "2":
						Console.WriteLine("Returning to main menu...");
						Thread.Sleep(799);
						Console.Clear();
						return;
					default:
						Console.WriteLine("Bad Choices. Returning to main menu...");
						Thread.Sleep(799);
						Console.Clear();
						return;
				}
			}
		}
		
		// Prompts the user for a positive integer input with a label
		private static int GetPositiveIntFromUser()
		{
			int value;
			while (true)
			{
				string input = Console.ReadLine() ?? "";
				bool valid = int.TryParse(input, out value) && value > 0;

				if (valid)
					return value;

				Console.WriteLine("Invalid input. Please enter a positive whole number.");
			}
		}

		// Prompts the user to enter 'size' number of integers and returns a populated array
		private static int[] GetArrayFromUser(int size)
		{
			int[] array = new int[size];

			for (int i = 0; i < size; i++)
			{
				array[i] = GetIntFromUser($"Element - {i}");
			}

			return array;
		}

		// Prompts the user for a single integer value with a specific label
		private static int GetIntFromUser(string label)
		{
			int value;
			while (true)
			{
				Console.Write($"{label}: ");
				string input = Console.ReadLine();
				bool valid = int.TryParse(input, out value);

				if (valid)
					return value;

				Console.WriteLine("Invalid input. Whole numbers only.");
			}
		}

		// Takes an array and returns a new array with elements in reverse order
		private static int[] ReverseArray(int[] original)
		{
			int length = original.Length;
			int[] reversed = new int[length];

			for (int i = 0; i < length; i++)
			{
				reversed[i] = original[length - 1 - i];
			}

			return reversed;
		}

		// Prints an array to the console with space-separated values
		private static void PrintArray(int[] array)
		{
			foreach (int num in array)
			{
				Console.Write(num + " ");
			}
			Console.WriteLine(); // for clean line break after output
		}
	}
}