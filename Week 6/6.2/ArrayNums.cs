using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._2
{
    /*
    * restate the problem:
    * Given array int nums[]
    * return an array int answer[] where answer[i] = product of all elements EXCEPT nums[i]
    * product guaranteed to fit in 32-bit int
    * 
    * must be O(n) WITHOUT the division operator
    * 
    * input: nums = [1,2,3,4]
    * output: [24,12,8,6]
    * 
    * input: nums = [-1,1,0,-3,3]
    * output: [0,0,9,0,0]
    * 
    * step through:
    * create int nums[] = new nums[]
    * while i < nums.Length - 1 : if i skip, else multiply
    * result add to answer[]
    * return completed answer[]
    * 
    * better understanding:
    * answer[i] = product before me * product after me
    * 
    * Index:     0   1   2   3
    * nums:     [1,  2,  3,  4]
    * 
    * Index 0, nums 1 : Skip me.  Multiply everything after me. 2 × 3 × 4 = 24
    * Index 1, nums 2 : Skip me. Multiply 1 × 3 × 4 = 12
    * Index 2, nums 3 : Skip me. Multiply 1 × 2 × 4 = 8 
    * Index 3, nums 4 : Skip me. Multiply 1 × 2 × 3 = 6
    * 
    * Split the work into 2 parts : Product before (prefix) & Product after (suffix)
    * 
    * | Index | nums\[i] | Product Before (`prefix`) | Product After (`suffix`) |
    * | ----- | -------- | ------------------------- | ------------------------ |
    * | 0     | 1        | none → 1                  | 2×3×4 = 24               |
    * | 1     | 2        | 1                         | 3×4 = 12                 |
    * | 2     | 3        | 1×2 = 2                   | 4                        |
    * | 3     | 4        | 1×2×3 = 6                 | none → 1                 |
    * 
    * answer[i] = product before me × product after me
    * 
    * answer = [1×24, 1×12, 2×4, 6×1]
    *        = [24, 12, 8, 6]
    * 
    * pseudo code:
    * new int nums[1,2,3,4]
    * prefix = nums[i] = prefix[none --> 1] * suffix[2*3*4]
    * suffix = nums[i - 2] = prefix[1*2*3] * suffix[none --> 1]
    * answer[i] = prefix[i] * suffix[i]
    * 
    * 
    * 
    * 
    *  
    * 
    */
    internal class ArrayNums
    {
        public static int[] ExceptSelf(int[] nums)
        {
            Console.WriteLine("Before / After Me Input Array:");
            Console.WriteLine(string.Join(", ", nums));
            int n = nums.Length;
            int[] answer = new int[n];

            // prefix product in answer[]
            // why do we set to 1?  Because there is no number before index 0 — and the identity of multiplication is 1.
            // identity of multiplication : the identity for an operation is the value that doesn’t change anything when you use it.
            // identity of multiplication : 1 because 1 * anything remains unchanged
            answer[0] = 1;  
            for (int i = 1; i < n; i++)
            {
                answer[i] = answer[i - 1] * nums[i - 1];
            }

            // suffix product in reverse
            int suffix = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                answer[i] *= suffix;
                suffix *= nums[i];
            }
            Console.WriteLine("Before / After Me Product Array:");
            Console.WriteLine(string.Join(", ", answer));
            return answer;

        }
    }
}
