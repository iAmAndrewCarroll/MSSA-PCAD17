namespace BubbleSortDemo
{
    internal class Program
    {
        static void BubbleSort(int[] arr)
        {
            int temp = 0;
            for (int pass = arr.Length - 1; pass >= 0; pass--)
            {
                for (int i = 0; i < pass; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int[] A = { 23, 12, 11, 100, 45, 2 };
            Console.WriteLine("Original Array:");
            foreach (int i in A)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();

            BubbleSort(A);
            Console.WriteLine("\nSorted Array:");
            foreach (int i in A)
            {
                Console.Write(i + " ");
            }
            Console.ReadKey();
        }
    }
}