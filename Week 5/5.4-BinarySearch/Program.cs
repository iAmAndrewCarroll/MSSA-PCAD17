internal class Program
{
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

    }
}