using System.Collections.Concurrent;

namespace QuickSortDemo
{
    internal class Program
    {
        // in this logic we are considering the low (left most index) as pivot and placing the pivot on its correct position
        // there can be diff implementations when the pivot changes (maybe it become right most element)
        static void QuickSort(int []A, int low, int high)
        {
            if (low < high)
            {
                int p_index = Partition(A, low, high);
                QuickSort(A, low, p_index - 1); //left
                QuickSort(A, p_index, high); //right

            }
        }

        // returns the pivot index / partition index p_index which is the correct position for the first number in the list
        static int Partition(int[] A, int low, int high)
        {
            int pivot = A[low]; //start on left
            int i = low;
            int j = high;
            do
            {
                while (i <= j && A[i] <= pivot)
                {
                    i++; // i moves right if the num at i is <= pivot
                }
                while (i <= j && A[j] > pivot)
                {
                    j--; // j moves towards left if the num at j is > pivot
                }
                // if i and j both stop then swap
                if (i <= j)
                {
                    // intermediate swap
                    Swap(A, i, j); // greater num moves right and lesser num moves left of pivot
                }
            }
            while (i < j);
            // j crossed i and we foudn pivot position
            if (low != j) // not swapo with itself
            {
                Swap(A, low, j);
            }
            return j;
        }

        static void Swap(int[] A, int i, int j)
        {
            int temp = A[i];
            A[i] = A[j];
            A[j] = temp;
        }

        static void Main(string[] args)
        {
            int[] A = { 54, 78, 63, 92, 45, 86, 15, 28, 37 };
            QuickSort(A, 0, A.Length-1);
            foreach (int i in A)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}