


// set the number of elements in the array
Console.Write("Input the number of elements in the array: ");
int size = int.Parse(Console.ReadLine());

// integer array 'numbers' length = size
int[] numbers = new int[size];

// move through array index prompting for entry
Console.WriteLine($"Input {size} elements in the array:");
for (int i = 0; i < size; i++)
{
    Console.Write($"element - {i} : ");
    numbers[i] = int.Parse(Console.ReadLine());
}

Console.WriteLine("\nSuccess");
Console.WriteLine(string.Join(" ", numbers));

Dictionary<int, int> frequency = new Dictionary<int, int>();

foreach (int i in numbers)
{
    if (frequency.ContainsKey(i))
    {
        frequency[i]++;
    }
    else
    {
        frequency[i] = 1;
    }
}

Console.WriteLine("\nUnique Elements:");
foreach (var pair in frequency)
{
    if (pair.Value == 1)
    {
        Console.WriteLine($"Yes: {pair.Key}");
    }
}
