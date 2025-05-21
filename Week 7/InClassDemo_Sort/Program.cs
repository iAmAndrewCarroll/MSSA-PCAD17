using System;

namespace InClassDemo_Sort
{
    class Program
    {
        class SelectionSortDemo
        {
            // 23 2 11
            // make sure all the left side elements are less than
            internal static void SelectionSort(int[] A)
            {
                int minposition = 0;
                int temp = 0; // for the swap as needed

                // i is tracking the correct position to put the swapped element from beginning to end
                for (int i = 0; i < A.Length - 1; i++)
                {
                    // minposition tracks the index of the min number
                    minposition = i;

                    // get the remaining minimum number
                    for (int j = i + 1; j < A.Length; j++)
                    {
                        if (A[j] < A[minposition])  // logic to find min number
                        {
                            minposition = j; // update minposition with index of min number

                        }
                    }

                    if (minposition != i) // to avoid swapping with itself
                    {
                        temp = A[i];
                        A[i] = A[minposition];
                        A[minposition] = temp;
                    }
                }
            }
        }

        // O(nsq) but is stable
        // sorts by comparing, moving, and placing
        internal static void InsertionSort(int[] arr)
        {
            int temp = 0;
            int position = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                temp = arr[i]; // the number to be inserted
                position = i; // index of temp; decremented until 0

                while (position > 0 && arr[position - 1] > temp)
                {
                    arr[position] = arr[position - 1];
                    position--;
                }
                arr[position] = temp; // correct spot such that all left side elements are <
            }
        }

        static void ShellSort(int[] arr)
        {
            int n = arr.Length;
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = arr[i];
                    int j;
                    for (j = i; j >= gap && arr[j - gap] > temp; j -= gap)
                    {
                        arr[j] = arr[j - gap];
                    }
                    arr[j] = temp;
                }
            }
        }

        static void DeepaliShellSort(int[] arr)
        {
            int gap = arr.Length / 2;
            int i, j;
            while (gap > 0)
            {
                i = gap;
                while (i < arr.Length)
                {
                    int temp = arr[i];
                    j = i - gap;
                    while (j >= 0 && arr[j] > temp)
                    {
                        arr[j + gap] = arr[j];
                        j = j - gap;
                    }
                    arr[j + gap] = temp;
                    i++;
                }
                gap = gap / 2;
            }
        }

        static void Main(string[] args)
        {
            int[] arr = { 3, 5, 8, 9, 6, 2 };
            Console.WriteLine("-- Selection Sort --");
            Console.WriteLine("Original array: " + string.Join(" ", arr));
            SelectionSortDemo.SelectionSort(arr);
            Console.WriteLine("Selection Sorted array: " + string.Join(" ", arr));
            Console.WriteLine();
            //Console.ReadKey();

            int[] insert = { 3, 5, 8, 9, 4, 2 };
            Console.WriteLine("-- Insertion Sort --");
            Console.WriteLine("Original array: " + string.Join(" ", insert));
            InsertionSort(insert);
            Console.WriteLine("Insertion Sorted Array: " + string.Join(" ", insert));
            Console.WriteLine();
            //foreach(int i in insert) 
            //Console.Write(i + " ");
            //Console.ReadKey();

            int[] shell = { 7, 4, 10, 5, 1, 8 };
            Console.WriteLine("-- Shell Sort --");
            Console.WriteLine("Original array: " + string.Join(" ", shell));
            ShellSort(shell);
            Console.WriteLine("Shell Sorted Array: " + string.Join(" ", shell));
            Console.WriteLine();
            //Console.ReadKey();

            int[] deepali = { 3, 5, 8, 9, 6, 2 };
            Console.WriteLine("-- Deepali Shell Sort --");
            Console.WriteLine("Original array: " + string.Join(" ", deepali));
            DeepaliShellSort(deepali);
            Console.WriteLine("Shell Sorted Array: " + string.Join(" ", deepali));
            Console.ReadKey();
        }
    }
}