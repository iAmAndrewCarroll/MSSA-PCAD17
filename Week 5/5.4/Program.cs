internal class Program
{
    /*
     * 5.4.1 - Display Individual Digits
     * Restate the problem:
     * Using recursion return individual digits of a number
     * input any number : 12345
     * output : The digits in the number 12345 are : 1 2 3 4 5
     * 
     * step through
     * - take number input : 1234
     * - expected output : 1 2 3 4
     * - use recursion to cut off digits one at a time from right to left
     * - integer division (number / 10) to remove the last digit and recurse (down the call stack)
     * - divide by 10 until number < 10
     * - BASE CASE : single digit number
     * - hit BASE CASE --> print digits using number % 10 (up the call stack)
     * - digits are printed left to right
     * - no strings, lists, or arrays
     *  
     *  Pseudo Code:
     *  function PrintDigits(int number);
     *  if number < 10 : print number // base case: single digit
     *  else : 
     *  call PrintDigits(number / 10) // recurse with smaller number
     *  print number % 10             // print digits on way up
     *
     */

    static void PrintDigits(int number)
    {
        if (number < 10)
        {
            Console.Write(number + " ");
        }
        else
        {
            PrintDigits(number / 10);
            int digit = (number % 10);
            Console.Write(digit + " ");
        }

        return;
    }

    /*
     * 5.4.2 - Sum Right Diagnols
     * Restate the problem:
     * find the sum of the right diagnoals of a matrix
     * input : size = 2 ; matrix elements [ 1,2,3,4 ]
     * Output:
     * The matrix is:
     * 12
     * 34
     * Addition of the right diagnal element is : 5
     * 
     * step through
     * - ask user for matrix size (square)
     * - create empty 2d in array 'matrix[n,n]
     * - Enter value for [0,0]: 
     * - Enter value for [0,1]:
     * - Enter value for [1,0]: --> all the way through n * n times
     * - anti-diaganol index is [i, n - 1 - i]
     * - if n = 3 : anti-diaganols = [0,2] [1,1] [2,0]
     * - sum += matrix[i, n - 1 - i];
     * - print the matrix
     * - print the right diagnols sum
     *  
     *  Pseudo Code:
     *  function RightDiaganolSum()
     *  print "input size n of a square matrix:"
     *  Read Input : int.TryParse
     *  if valid input : store value as n"
     *  else: print "invalid size. Exit or re-prompt."
     *  
     *  create matrix[, ]
     *  
     *  for i from 0 to n - 1:
     *      for j from 0 to n - 1:
     *          prompt: "Enter value for position [i, j]:"
     *          read input
     *          if int.TryParse(input) is valid:
     *              matrix[i, j] = parsed integer
     *          else:
     *              re-prompt for the same position
     *  
     *  initialize sum = 0
     *  
     *  for i from 0 to n - 1:
     *      sum += matrix{i, n - 1 - i] // right diagonal element
     *      
     *  print "The matrix is:"
     *  for i from 0 to n - 1:
     *      for j from 0 to n - 1:
     *          print matrix[i, j] with spacing
     *          
     *  print "Sum of right diagonal elements is: " + sum
     *
     */

    static void RightDiaganolSum()
    {
        Console.WriteLine("Input the size (n) of a square matrix:");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int n) && n > 0)
        {
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    while (true)
                    {
                        Console.WriteLine($"Input cell value for position [{i}, {j}]: ");
                        string inputValue = Console.ReadLine();

                        if (int.TryParse(inputValue, out int value))
                        {
                            matrix[i, j] = value;
                            break; // input valid move to next cell
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Try again.");
                        }
                    }
                }
            }
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("5.4.1 - Print Single Digits");
        Console.WriteLine("Enter a valid integer: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int number) && number >= 0)
        {
            Console.WriteLine($"The digits of {number} are :");
            PrintDigits(number);
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a non-negative integer.");
        }
    }
}