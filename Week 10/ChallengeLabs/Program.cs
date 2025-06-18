using System;

namespace Week10ChallengeLabs
{
    class Program
    {
        static void Main()
        {
            RunFindAddedLetter();
            Console.ReadKey();

            RunMergeSortedArrays();
            Console.ReadKey();
        }

        // Challenge 1
        static void RunFindAddedLetter()
        {
            Console.WriteLine("=== Challenge 1: Find the Added Letter ===\n");

            string s1 = "abcd", t1 = "abcde";
            string s2 = "", t2 = "y";

            Console.WriteLine("Test Case 1:");
            Console.WriteLine($"Original string:      \"{s1}\"");
            Console.WriteLine($"Modified string:      \"{t1}\"");
            Console.WriteLine($"=> Added letter:      '{FindTheDifference(s1, t1)}'\n");

            Console.WriteLine("Test Case 2:");
            Console.WriteLine($"Original string:      \"{s2}\"");
            Console.WriteLine($"Modified string:      \"{t2}\"");
            Console.WriteLine($"=> Added letter:      '{FindTheDifference(s2, t2)}'\n");
        }

        static char FindTheDifference(string s, string t)
        {
            int sumS = 0, sumT = 0;
            foreach (char c in s) sumS += c;
            foreach (char c in t) sumT += c;
            return (char)(sumT - sumS);
        }

        // Challenge 2
        static void RunMergeSortedArrays()
        {
            Console.WriteLine("=== Challenge 2: Merge Sorted Arrays ===\n");

            RunMergeCase(new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { 2, 5, 6 }, 3, "Test Case 1");
            RunMergeCase(new int[] { 5, 0, 0, 0 }, 1, new int[] { 3, 6, 9 }, 3, "Test Case 2");
            RunMergeCase(new int[] { 8, 7, 6, 0 }, 3, new int[] { 7, 0, 0, 0 }, 1, "Test Case 3");
        }

        static void RunMergeCase(int[] nums1, int m, int[] nums2, int n, string label)
        {
            Console.WriteLine($"{label}:");
            Console.WriteLine($"Input nums1 (before): [{string.Join(", ", nums1)}]");
            Console.WriteLine($"Input nums2:          [{string.Join(", ", nums2)}]");
            Console.WriteLine($"m = {m}, n = {n}");

            Merge(nums1, m, nums2, n);

            Console.WriteLine($"Merged nums1 (after): [{string.Join(", ", nums1)}]\n");
        }

        static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1, j = n - 1, k = m + n - 1;
            while (j >= 0)
            {
                if (i >= 0 && nums1[i] > nums2[j])
                    nums1[k--] = nums1[i--];
                else
                    nums1[k--] = nums2[j--];
            }
        }
    }
}
