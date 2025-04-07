using System; // access to classes and tools in System namespace
using System.Collections.Generic;

namespace Assignment1_1 // similar to python modules and packages, namespaces help me organize code and avoid naming conflicts.
                        // They help organize code into groups like folders or directories in a file system.
                        // I can refer to this code elsewhere by using: Assignment1_1.Part1 (this is similar to a python import statement)
{
    public class Part1 // classes are blueprints for organizing code.
                       // Like a container that groups methods (actions) & variables (data) together
    {
        public static void Run() // this method is called by Program.Main() upon user selection.
                                 // It's the entry point for this part.
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                Console.WriteLine("\n-- Personal Details Menu --");
                Console.WriteLine("1 - Add a new person");
                Console.WriteLine("2 - View all records");
                Console.WriteLine("3 - Update an existing person");
                Console.WriteLine("4 - Return to Main Menu");
                Console.Write("Choice: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    // add new person
                    Person newPerson = new Person();

                    Console.Write("Enter name: ");
                    newPerson.Name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newPerson.Name))
                    {
                        Console.WriteLine("Name cannot be empty.");
                        continue;
                    }

                    Console.Write("Enter age: ");
                    bool validAge = int.TryParse(Console.ReadLine(), out int age);
                    if (!validAge || age < 0 || age > 130)
                    {
                        Console.WriteLine("Invalid age. Pretty sure it needs to be between 0 and 130.");
                        continue;
                    }
                    newPerson.Age = age;

                    Console.Write("Enter address: ");
                    newPerson.Address = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newPerson.Address))
                    {
                        Console.WriteLine("Address cannot be empty.");
                        continue;
                    }

                    people.Add(newPerson);
                    Console.WriteLine("You've successfully birthed a new record.");
                }
                else if (choice == "2")
                {
                    // view everyone
                    if (people.Count == 0)
                    {
                        Console.WriteLine("No records found.");
                    }
                    else
                    {
                        Console.WriteLine("\n-- Stored Personal Records --");
                        foreach (Person p in people)
                        {
                            Console.WriteLine($"Name: {p.Name}");
                            Console.WriteLine($"Age: {p.Age}");
                            Console.WriteLine($"Address: {p.Address}");
                            Console.WriteLine("_--_,_--__--_,_--__--_,_--__--_,_--_");
                        }
                    }
                }
                else if (choice == "3")
                {
                    // modify record
                    if (people.Count == 0)
                    {
                        Console.WriteLine("No records to update.");
                        continue;
                    }

                    Console.WriteLine("\nSelect a record to update:");
                    for (int i = 0; i < people.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {people[i].Name}");
                    }
                    Console.WriteLine($"{people.Count + 1} - Cancel");

                    Console.Write("Choice: ");
                    bool validIndex = int.TryParse(Console.ReadLine(), out int index);

                    if (!validIndex || index < 1 || index > people.Count + 1)
                    {
                        Console.WriteLine("Invalid choice.");
                        continue;
                    }

                    if (index == people.Count + 1)
                    {
                        Console.WriteLine("Update Cancelled.");
                        continue;
                    }

                    Person person = people[index - 1];

                    Console.WriteLine("Leave any field blank to keep current value.");

                    Console.Write($"Update name (current: {person.Name}): ");
                    string newName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newName))
                    {
                        person.Name = newName;
                    }

                    Console.Write($"Update age (current: {person.Age}): ");
                    string ageInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(ageInput))
                    {
                        bool ageValid = int.TryParse(ageInput, out int newAge);
                        if (ageValid && newAge >= 0 && newAge <= 130)
                        {
                            person.Age = newAge;
                        }
                        else
                        {
                            Console.WriteLine("Invalid age. Existing value remains unchanged.");
                        }
                    }

                    Console.Write($"Update address (current: {person.Address}): ");
                    string newAddress = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newAddress))
                    {
                        person.Address = newAddress;
                    }

                    Console.WriteLine("Record updated.");
                }
                else if (choice =="4")
                {
                    return; // back to main menu
                }
            }
        }
    }

    public class Person
    {
        public string Name;
        public int Age;
        public string Address;
    }
}