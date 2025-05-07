/*
 * 5.1.1 - Palindrome
 * Clarify the problem:
 * 1. Given an integer x, return true if x is a palindrome, and false otherwise.
 * - Identify a palindrome
 * - Negative numbers cannot be palindromes (-121 =/= 121-)
 * - No string conversions
 * 
 * Step through
 * Input: an integer x
 * - compare digits from both ends moving towards the middle
 * 
 * Isolate digits
 * - x % 101 splits last digit 1
 * - x / 101 splits first digit 1
 * 
 * Two pointers
 * - left begins at 0 element
 * - right begins at .length - 1
 * 
 * Compare pointers
 * - if left == right, continue
 * - if left =/= right not a palindrome
 * 
 */

using System;

bool IsPalindrome(int x)
{
    if (x < 0)
        return false;

    if (x != 0 && x % 10 == 0)
        return false; // 10 and 100 are not palindromes

    // calculate divisor
    int div = 1;
    while (x / div >= 10)
    {
        div *= 10;
    }

    while (x != 0)
    {
        int left = x / div;
        int right = x % 10;

        if (left != right)
            return false;

        // Get left & right digits
        x = (x % div) / 10;
        div /= 100;
    }

    return true;
}
Console.WriteLine("5.1.1");
Console.WriteLine(IsPalindrome(12321));
Console.WriteLine(IsPalindrome(-12321));
Console.WriteLine();

/*
 * Clarify the Problem:
 * - Write a C# program to create a function to calculate the sum of the individual
 *   digits of a given number
 *   - Test Data: 1234 --> Expected Output: The sum of the digits of the number 1234
 *     is: 10
 * 
 * Step Through
 * 1. initialize variable 'sum' 
 * 2. get the last 'digit': 1234 % 10 = 4
 * 3. add 4 to 'sum'
 * 4. remove digit from x: x = x / 10
 * 5. repeat get last 'digit': 123 % 10 = 3
 * 6. add 3 to 'sum'
 * 7. continue while x > 0
 * 8. digit = x % 10
 * 9. return 'sum'
 * 
 * */

static int SumDigits(int x)
{
    int sum = 0;

    while (x > 0)
    {
        int digit = x % 10; // get last digit
        sum += digit;       // add to sum
        x /= 10;            // remove last digit
    }

    return sum;
}
Console.WriteLine("5.1.2");
Console.WriteLine(SumDigits(12345));
Console.WriteLine();

/* 
 * 5.1.3
 * 
 * Clarify the Problem:
 * 3. Given an integer array nums, return true if any value appears at 
 *    least twice in the array, and return false if every element is distinct.
 * - initialize a dictionary or hashset to track what is seen in the initial array
 * - If a value is identified as a duplicate the program returns true
 * - No duplicates, return true
 * 
 * Step Through
 * - Initialze HashSet<int> to store seen numbers
 * - Loop the array, track numbers seen
 *   - if a number is already seen --> return true
 *   - if not, add to set
 * - Loop completes --> return false
 * 
 */

static bool Duplicate(int[] nums)
{
    HashSet<int> seen = new HashSet<int>();

    foreach (int num in nums)
    {
        if (seen.Contains(num))
            return true;

        seen.Add(num);
    }

    return false;
}
int[] array1 = [1, 2, 3, 1, 4, 5, 6];
int[] array2 = [1, 2, 3, 4, 5];
Console.WriteLine("5.1.3");
Console.WriteLine(Duplicate(array1));
Console.WriteLine(Duplicate(array2));
Console.WriteLine();

/*
 *  5.3.1
 *  
 *  Clarify the Problem:
 *  1. You have a long flowerbed in which some of the plots are planted, and some are not. However, flowers 
 *  cannot be planted in adjacent plots. Given an integer array flowerbed containing 0's and 1's, where 0 
 *  means empty and 1 means not empty, and an integer n, return true if n new flowers can be planted in the 
 *  flowerbed without violating the no-adjacent-flowers rule and false otherwise.
 *  
 *  Example 1:
 *  Input: flowerbed = [1,0,0,0,1], n = 1
 *  Output: true
 *  
 *  Example 2:
 *  Input: flowerbed = [1,0,0,0,1], n = 2
 *  Output: false
 *  
 *  Step Through
 *  - I have a 1D array of flower beds. --> bool function array
 *  - Some are planted and some are not. --> assign value
 *  - int i array flowerbed containing empty (0) and not empty (1)
 *  - given an integer, n : new flowers to be planted 
 *  - rule : no-adjacent-flowers
 *  - return : true n new flowers can be planted in the flowerbed w/o violating the rule [1, 0, 0, 0, 1] n=1 --> [1, 0, 1, 0, 1]
 *    - or : false [1, 1, 0, 0, 1] 
 *  
 *  Pseudo Code
 *  bool FlowerPlant(int[] flowerbed, int n)
 *  {
 *      for (int i = 0; i < flowerbed.Length; i++)
 *      {
 *          if (flowerbed[i] == 0)
 *          {
 *              // check left neighbor
 *              bool leftEmpty = (i == 0) || (flowerbed[i - 1] == 0);
 *              
 *              //check right neighbor
 *              bool rightEmpty = (i == flowerbed.Length - 1) || (flowerbed[i + 1] == 0);
 *              
 *              if (leftEmpty && rightEmpty
 *              {
 *                  flowerbed[i] = 1; // Plant the flower
 *                  n--; // decrement n (flowers to be planted)
 *                  
 *                  if (n == 0)
 *                  {
 *                      return true; 
 *                  }
 *              }
 *          }
 *      }
 *      
 *      return n <= 0;
 *  }
 *      
 */



static bool FlowerPlant(int[] flowerbed, int n)
{
    for (int i = 0; i < flowerbed.Length; i++)
    {
        bool leftEmpty = (i == 0) || (flowerbed[i - 1] == 0);

        bool rightEmpty = (i == flowerbed.Length - 1) || (flowerbed[i + 1] == 0);

        if (leftEmpty && rightEmpty)
        {
            flowerbed[i] = 1;
            n--;

            if (n == 0)
            {
                return true;
            }
        }
    }
    
    return n <= 0;
}

Console.WriteLine("Flowerbed");
FlowerPlant((1, 0, 0, 0, 1), 1);
