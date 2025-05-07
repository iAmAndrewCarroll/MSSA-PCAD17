using System.Net.Http.Headers;

class Program
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
        Console.WriteLine("Flowerbeds");
        FlowerPlant([1, 0, 0, 0, 1], 1);
        FlowerPlant([0, 1, 0, 1, 0], 1);
        
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
}