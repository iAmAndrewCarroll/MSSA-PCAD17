internal class Program
{
    // Time complexity : O(n)
    static int LinearSearch(int[] array, int val)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == val) return i;
        }

        return -1; // number not found
    }

    static bool LinearBool(int[] array, int val, out int index)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == val)
            {
            index = i;
            return true;
            }
        }

        index = -1;
        return false; // number not found
    }

    // O(logn)
    static int BinarySearch(int[] array, int val)
    {
        int left = 0, right = array.Length - 1, mid = 0;
        if (val < array[0]) return -1;
        if (val > array[array.Length - 1]) return -1;
        while (left <= right)
        {
            mid = (left + right) / 2;
            if (val == array[mid])
                return mid;
            else if (val < array[mid])
                right = mid - 1;
            else if (val > array[mid])
                left = mid + 1;
        }
        return -1;
    }

    static void Main(string[] args)
    {
        int[] nums = { 34, 23, 12, 56, 89, 90, 120 };
        int index;
        bool result = LinearBool(nums, 12, out index);
        if (result)
        {
            Console.WriteLine($"The number is found at {index}");
        }
        else
        {
            Console.WriteLine("Number not present");
        }

        Console.ReadKey();
    }
}