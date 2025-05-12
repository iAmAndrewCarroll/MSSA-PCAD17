using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1
{
/*
* Assignment 6.1.3
* 
* Restate the Problem:
* Given an int arry nums : int[] nums = { 0, 1, 0, 3, 12 };
* Move all 0's  to the end
* Maintain relative order of non-zero elements
* Must be done in place : no copy of array
* 
* Input : nums = [0,1,0,3,12]
* Output : [1,3,12,0,0]
* 
* Input : nums = [0]
* Output : [0]
* 
* Step Through:
* create an int array of nums[]
* iterate through the array
* while (i = 0; i < array.length; i++)
* if i == 0 --> temp[i, count]
* if i != 0 --> next
* when i == array.length -- append temp[i] count times
* return MoveZero[]
* 
* 
* 
*/
    internal class MoveZero
    {

        public static void MoveZeroes(int[] nums)
        {
            int writeIndex = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[writeIndex] = nums[i];
                    writeIndex++;
                }
            }

            for (int i = writeIndex; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }
    }
}
