using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment10_2
{
    class Program
    {
        static void Main()
        {
            RunPositiveNumbersQuery();
            Console.ReadKey();

            RunEmployeeFilterQuery();
            Console.ReadKey();

            RunCityStartEndQuery();
            Console.ReadKey();

            RunNumbersGreaterThan80Query();
            Console.ReadKey();
        }

        static void RunPositiveNumbersQuery()
        {
            Console.WriteLine("=== 10.2.1 - Positive Numbers Using LINQ ===");
            int[] numbers = { 2, -1, 3, -3, 10, -200 };

            Console.WriteLine("Original List:");
            Console.WriteLine(string.Join(", ", numbers));

            Console.WriteLine("Filtering for: Numbers > 0");
            var positiveNumbers = numbers.Where(n => n > 0);
            Console.WriteLine("Filtered Result: " + string.Join(", ", positiveNumbers));
        }

        static void RunEmployeeFilterQuery()
        {
            Console.WriteLine("\n=== 10.2.2 - Employees with Salary > 5000 and Age < 30 ===");

            var employees = new List<Employee>
            {
                new Employee { Name = "Alice", Salary = 6000, Age = 28 },
                new Employee { Name = "Bob", Salary = 4800, Age = 35 },
                new Employee { Name = "Carol", Salary = 7200, Age = 25 },
                new Employee { Name = "Dave", Salary = 5200, Age = 31 },
                new Employee { Name = "Eve", Salary = 5100, Age = 29 }
            };

            Console.WriteLine("Original Employee List:");
            Console.WriteLine("Name\tSalary\tAge");
            foreach (var e in employees)
                Console.WriteLine($"{e.Name}\t{e.Salary}\t{e.Age}");

            Console.WriteLine("\nFiltering for: Salary > 5000 AND Age < 30");
            var filtered = employees.Where(emp => emp.Salary > 5000 && emp.Age < 30);

            Console.WriteLine("Filtered Employees:");
            Console.WriteLine("Name\tSalary\tAge");
            foreach (var emp in filtered)
                Console.WriteLine($"{emp.Name}\t{emp.Salary}\t{emp.Age}");
        }

        static void RunCityStartEndQuery()
        {
            Console.WriteLine("\n=== 10.2.3 - Cities Starting with 'A' and Ending with 'M' ===");

            string[] cities = {
                "ROME", "LONDON", "NAIROBI", "CALIFORNIA", "ZURICH",
                "NEW DELHI", "AMSTERDAM", "ABU DHABI", "PARIS"
            };

            Console.WriteLine("Original City List:");
            Console.WriteLine(string.Join(", ", cities));

            char startChar = 'A';
            char endChar = 'M';
            Console.WriteLine($"Filtering for: City that starts with '{startChar}' and ends with '{endChar}'");

            var matchingCity = cities
                .FirstOrDefault(city =>
                    city.StartsWith(startChar.ToString(), StringComparison.OrdinalIgnoreCase) &&
                    city.EndsWith(endChar.ToString(), StringComparison.OrdinalIgnoreCase));

            if (matchingCity != null)
                Console.WriteLine($"Filtered Result: {matchingCity}");
            else
                Console.WriteLine("No city matches the criteria.");
        }

        static void RunNumbersGreaterThan80Query()
        {
            Console.WriteLine("\n=== 10.2.4 - Numbers Greater Than 80 ===");

            List<int> numbers = new List<int> { 55, 200, 740, 76, 230, 482, 95 };

            Console.WriteLine("Original List:");
            Console.WriteLine(string.Join(", ", numbers));

            Console.WriteLine("Filtering for: Numbers > 80");
            var result = numbers.Where(n => n > 80);
            Console.WriteLine("Filtered Result: " + string.Join(", ", result));
        }
    }

    class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public int Age { get; set; }
    }
}
