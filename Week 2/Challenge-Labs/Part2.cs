/*
=======================================================================
PART2.cs – Week 2 Challenge: Basic Login Attempt Limiter
=======================================================================

This module demonstrates:
- Comparing user input (userid and password) against known values
- Looping with a limited number of attempts (3 max)
- Rejecting user after 3 failed tries
- Using simple string comparison with minimal logic (no dictionary used)

| Step | What Happens                                         | Where It Happens                    |
|------|------------------------------------------------------|-------------------------------------|
| 1    | Define correct userid and password (hardcoded)       | Top of Part2.Run()                  |
| 2    | Loop begins for up to 3 login attempts               | `for` or `while` loop               |
| 3    | Prompt user to enter userid and password             | `Utilities.ReadString(...)`         |
| 4    | Compare input to expected values                     | `if (user == correctUser && ...)`   |
| 5    | If matched, print success and break the loop         | Inside `if` block                   |
| 6    | If not matched, print failure and try again          | Inside `else` block                 |
| 7    | After 3 failed attempts, reject login                | After loop ends                     |

Key Concepts:
- String equality
- Simple credential validation
- Looping with early termination
- No external dependencies (no dictionary, no file, no database)
*/

using System;
using Assignment_Tools;

namespace Challenge_Labs
{
	public class Part2
	{
		public static void Run()
		{
			Console.Clear();
			Console.WriteLine("-- Challenge Lab Part 2: Logins --\n");

			// Step 1: Set the correct credentials (as strings)
			string correctUser = "admin";
			string correctPassword = "password1234";

			// Step 2: Allow up to 3 attempts
			for (int attempt = 1; attempt <= 3; attempt++)
			{
				Console.WriteLine($"Attempt {attempt} of 3\n");

				// Step 3: Prompt user for input using helper method
				var (userID, password) = Utilities.ReadCredentials();

				// Step 4: Check if credentials match
				if (userID == correctUser && password == correctPassword)
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("\nLogin successful!");
					Console.ResetColor();
					Utilities.Pause();
					return; // exit method
				}

				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					int attemptsLeft = 3 - attempt;
					Console.WriteLine($"Login FAILED... {attemptsLeft} attempt{(attemptsLeft == 1 ? "" : "s")} remaining\n");
					Console.ResetColor();
				}
			}

			// Step 7: After 3 failed attempts, lock the user out
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine("Access denied. Too many failed attempts.");
			Console.ResetColor();
			Utilities.Pause();
		}
	}
}