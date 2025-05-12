using _6._1;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Single Linked List - Houses : 6.1.1");
        Console.WriteLine();
        customList houseList = new customList();
        houseList.AddLast(new House(101, "123 Elm St", "Ranch"));
        houseList.AddLast(new House(102, "567 Town Ave", "Town"));
        houseList.AddLast(new House(103, "678 Roy St", "Colonial"));

        Console.WriteLine("Current Houses:");
        houseList.Display();

        Console.WriteLine("Enter a house number to search: ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int searchNumber))
        {
            if (houseList.Search(searchNumber, out int index))
                Console.WriteLine($"House #{searchNumber} found at position {index}.");
        }

        Console.ReadKey();

        Console.WriteLine("\nRemoving first and last houses...");
        houseList.RemoveFirst();
        houseList.RemoveLast();

        Console.WriteLine("Updated List:");
        houseList.Display();

        Console.ReadKey();

        Console.WriteLine();

        Console.WriteLine("Move Zeros in an Array : 6.1.3");
        Console.WriteLine();
        int[] nums = { 0, 1, 0, 3, 12 };
        Console.WriteLine("Original Array: ");
        Console.WriteLine(string.Join(", ", nums));
        MoveZero.MoveZeroes(nums);
        Console.WriteLine("Zeros Moved Array: ");
        Console.WriteLine(string.Join(", ", nums)); 

        Console.ReadKey();
    }
}


