using System.Xml;

namespace MergeSortDemo
{
    internal class Program
    {
        static void divide(int[] A, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                divide(A, left, mid);
                divide(A, mid + 1, right);
                merge(A, left, mid, right);
            }
        }

        static void merge(int[] A, int left, int mid, int right)
        {
            int i = left;// first index of left sub array
            int j = mid + 1;// first index of right sub array
            int[] B = new int[right + 1];
            int k = left;// index to track the elements in temp array B
            while (i <= mid && j <= right)
            {
                if (A[i] <= A[j]) // smaller element goes in temp array B
                {
                    B[k] = A[i];
                    i++;
                }
                else
                {
                    B[k] = A[j];
                    j++;
                }
                k++;

            }
            while (i <= mid)// there are more elements in left sub array
            {
                B[k] = A[i];
                k++;
                i++;
            }
            while (j <= right)
            {
                B[k] = A[j];
                j++;
                k++;
            }
            //update the elements in array A
            for (int x = left; x <= right; x++)
            {
                A[x] = B[x];
            }
            // hi hello
        }

        static void Main(string[] args)
        {
            int[] A = { 3, 5, 8, 9, 6, 2 };
            divide(A, 0, A.Length - 1);
            foreach(int x in A)
                Console.WriteLine(x);
            Console.ReadKey();

        }
    }
}