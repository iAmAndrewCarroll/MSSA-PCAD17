using System;
using System.Collections.Generic;
using System.Linq;

internal static class Assignment7_2
{
    public static void ShellSort(int[] arr)
    {
        int n = arr.Length;
        for (int gap = n / 2; gap > 0; gap /= 2)
        {
            for (int i = gap; i < n; i++)
            {
                int temp = arr[i];
                int j = i;
                while (j >= gap && arr[j - gap] > temp)
                {
                    arr[j] = arr[j - gap];
                    j -= gap;
                }
                arr[j] = temp;
            }
        }
    }

    public static string ReverseVowels(string s)
    {
        HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        char[] chars = s.ToCharArray();
        int left = 0, right = s.Length - 1;

        while (left < right)
        {
            if (!vowels.Contains(chars[left])) { left++; continue; }
            if (!vowels.Contains(chars[right])) { right--; continue; }

            // swap
            char temp = chars[left];
            chars[left] = chars[right];
            chars[right] = temp;

            left++;
            right--;
        }
        return new string(chars);
    }

    public static bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) return false;

        var sArr = s.ToCharArray();
        var tArr = t.ToCharArray();
        Array.Sort(sArr);
        Array.Sort(tArr);

        return sArr.SequenceEqual(tArr);
    }

    public static void Run()
    {
        Console.WriteLine("-- 7.2.1 Shell Sort --");
        int[] arr = { 5, 8, 3, 9, 4, 1 };
        Console.WriteLine("Original: " + string.Join(" ", arr));
        ShellSort(arr);
        Console.WriteLine("Sorted:   " + string.Join(" ", arr));
        Console.WriteLine();

        Console.WriteLine("-- 7.2.2 Reverse Vowels --");
        Console.WriteLine(ReverseVowels("hello"));      // holle
        Console.WriteLine(ReverseVowels("avacado"));    // ovacada
        Console.WriteLine(ReverseVowels("intelligent")); // entillegint
        Console.WriteLine();

        Console.WriteLine("-- 7.2.3 Anagram Check --");
        Console.WriteLine(IsAnagram("anagram", "nagaram")); // True
        Console.WriteLine(IsAnagram("rat", "car"));         // False
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Assignment7_2.Run();
        Console.ReadKey();
    }
}
