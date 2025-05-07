using System.Net.Http.Headers;

internal class Program
{
    // Big O Notation : Consider the nested loops

    static Nullable<long>[] sequence = new Nullable<long>[25];

    //O(n)
    static int FibIteration(int n)
    {
        int first = 0; int second = 1;
        int result = 0;
        if (n == 0)
        {
            return 0;
        }
        if (n == 1)
        {
            Console.Write(0);
            return 0;
        }
        Console.Write("0" + ",1,");
        for (int i = 2; i <= n; i++)
        {
            result = first + second; // 1
            Console.Write(result + ",");
            first = second;
            second = result;
        }
        return result;
    }

    static int[] FibDP(int n)
    {
        int[] series = new int[n];
        series[0] = 0;
        series[1] = 1;
        for (int i = 2; i < n; i++)
        {
            series[i] = series[i - 1] + series[i - 2];
        }
        return series;
    }
   
    // We do NOT store the results and hence the same valued parameter gets called multiple times
    static int FibRecursion(int n)
    {
        if (n <= 1) return n;
        return FibRecursion(n - 1) + FibRecursion(n - 2);
    }

    static long? Fib_RecDP(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;
        return sequence[n] = Fib_RecDP(n - 1) + Fib_RecDP(n - 2);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Fib by iteration");
        FibIteration(5);  // number of terms to be printed : 0 & 1 are part of this
        Console.WriteLine("\n");

        Console.WriteLine("Fib by Dynamic Programming");
        var results = FibDP(5); // this returns an array
        foreach (var i in results)
        {
            Console.Write(i);
        }
        Console.WriteLine("\n");

        Console.WriteLine("Recusion + Dynamic Programming");
        Fib_RecDP(5);
        foreach (var i in sequence)
        {
            if (i.HasValue)
                Console.Write(i + " ");
        }
        Console.WriteLine("\n");
        Console.WriteLine("Fib by Recursion");

        Console.WriteLine("\n");
        Console.WriteLine("5.3.1 - Flowerbeds");
        FlowerPlant([1, 0, 0, 0, 1], 1);
        FlowerPlant([0, 1, 0, 1, 0], 1);

        Console.WriteLine("\n");
        Console.WriteLine("5.3.2 - The Solution to the Stairs");
        int result1 = ClimbStairs(5);
        Console.WriteLine($"There are {result1} ways to climb 5 stairs.");
        int result2 = ClimbStairs(8);
        Console.WriteLine($"There are {result2} ways to climb 8 stairs.");
        Console.ReadKey();
    }


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

            if (flowerbed[i] == 0 && leftEmpty && rightEmpty)
            {
                Console.WriteLine(n);
                flowerbed[i] = 1;
                n--;
                Console.WriteLine(n);

                if (n == 0)
                {
                    Console.WriteLine("PLANTED!");
                    return true;
                }
            }
        }

        if (n <= 0)
        {
            Console.WriteLine("PLANTED!");
            return true;
        }
        else
        {
            Console.WriteLine("NOT PLANTED!");
            return false;
        }
    }


    /*
     *  5.3.2
     *  
     *  Clarify the Problem:
     *  2. You are climbing a staircase. It takes n steps to reach the top.
     *  Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
     *  
     *  
     *  Example 1:
     *  Input: n = 2 
     *  Output: 2
     *  Explanation: There are two ways to climb to the top.
     *  1. 1 step + 1 step
     *  2. 2 steps
     *  
     *  Example 2:
     *  Input: n = 3
     *  Output: 3
     *  Explanation: There are three ways to climb to the top.
     *  1. 1 step + 1 step + 1 step
     *  2. 1 step + 2 steps
     *  3. 2 steps + 1 step
     *  
     *  Step Through
     *  - I need to get to step n
     *  - I can get to n by : taking one step from n - 1 OR taking 2 steps from n - 2
     *  - Total ways to reach step n : All ways to reach step n - 1 and step n - 2
     *  - ways(n) = ways(n - 1) + ways(n - 2)
     *  - ways(4) = ways(3) + ways(2) --> ways(3) = ways(2) + ways(1) --> ways(2) = ways(1) + ways(0)
     *  - define ways(1) = 1 (one way to take a single step)
     *  - define ways(0) = 1 (one way to do ntohing / start at the bottom)
     *  - build upward : 
     *      - ways(2) = 1 (from step 1) + 1 (from step 0) = 2
     *      - ways(3) = 2 (from step 2) + 1 (from step 1) = 3
     *      - ways(4) = 3 (from step 3) + 2 (from step 2) = 5
     *  - Solved = 5 ways to climb 4 stairs
     *  
     *  Pseudo Code
     *    - a function for ClimbStairs(int n)
     *  {
     *      n = 1 check returns 1;
     *      n = 2 check returns 2;
     *      
     *      int first = 1; // this is ways(1)
     *      int second = 2; // this is ways(2)
     *      
     *      // loop through possibilities
     *      for (int i = 3; i <= n; i++)
     *      {
     *          int third = first + second;
     *          first = second;
     *          second = third;
     *      }
     *      
     *      return second; // because second is the cumulative ways() variable
     *  }
     *  
     *  Big O Notation: O(n) for iteration
     *  Constant space: Only tracks 2-3 variables
     *  
     */

    static int ClimbStairs(int n)
    {
        // define base cases : the "known" answers
        if (n == 1) return 1;
        if (n == 2) return 2;

        // initialize variables
        int first = 1;
        int second = 2;

        // start with i = 3 because i = 1 & 2 are known
        for (int i = 3; i <= n; i++)
        {
            int third = first + second;
            first = second;
            second = third;
        }

        return second;
    }
}

