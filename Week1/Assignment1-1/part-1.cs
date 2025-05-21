using System; // access to classes and tools in System namespace
using System.Collections.Generic;  // using List<T> to store person objects. Similar ot Python's list.

namespace Assignment1_1 // similar to python modules and packages, namespaces help me organize code and avoid naming conflicts.
                        // They help organize code into groups like folders or directories in a file system.
                        // I can refer to this code elsewhere by using: Assignment1_1.Part1 (this is similar to a python import statement)
{
    public class Part1 // classes are blueprints for organizing code.
                       // Like a container that groups methods (actions) & variables (data) together
                       // In this case this class holds a single method, 'Run()', which encapsulates this
                       // entire interactive menu system.
    {
        public static void Run() // this method is called by Program.Main() upon user selection.
                                 // It's the entry point for Part1.
                                 // public means this method can be called from other classes (Program.cs)
                                 // static means we don't need to create an object of Part1 to run it.
                                 // Run() is the main method for this portion of the assignment - loops
                                 // until user returns to the main menu.
        {
            List<Person> people = new List<Person>(); // Initializes an empty list to store all the people records
                                                      // Person is a class we define at the bottom
                                                      // Each time we collect name, age and address it is stored as a Person object in this list

            while (true) // this is the main loop that keeps the user inside the Personal Details menu
            {
                Console.WriteLine("\n-- Personal Details Menu --");  // numbered option menu
                Console.WriteLine("1 - Add a new person");
                Console.WriteLine("2 - View all records");
                Console.WriteLine("3 - Update an existing person");
                Console.WriteLine("4 - Return to Main Menu");
                Console.Write("Choice: ");

                string choice = Console.ReadLine(); // choice is a string so we compare it as exactly equal ( == )

                if (choice == "1")
                {
                    // add new person
                    Person newPerson = new Person();

                    Console.Write("Enter name: "); // name is a string and must not be empty
                    newPerson.Name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newPerson.Name))  // checking for empty input
                    {
                        Console.WriteLine("Name cannot be empty.");
                        continue;
                    }

                    Console.Write("Enter age: ");  // age is an int 0 < 130 for validity
                    bool validAge = int.TryParse(Console.ReadLine(), out int age);
                    if (!validAge || age < 0 || age > 130) // verification of 0 - 130 age integer
                    {
                        Console.WriteLine("Invalid age. Pretty sure it needs to be between 0 and 130.");
                        continue;
                    }
                    newPerson.Age = age;

                    Console.Write("Enter address: "); // another string 
                    newPerson.Address = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newPerson.Address)) // verify input exists
                    {
                        Console.WriteLine("Address cannot be empty.");
                        continue;
                    }

                    people.Add(newPerson); // once everything is validated then the new record is created
                    Console.WriteLine("You've successfully birthed a new record.");
                }
                else if (choice == "2")
                {
                    // view everyone
                    if (people.Count == 0) // if records == 0 then there are no records to display
                    {
                        Console.WriteLine("No records found.");
                    }
                    else // if there are records then this loops and displays each records information
                    {
                        Console.WriteLine("\n-- Stored Personal Records --");
                        foreach (Person p in people) // p is the variable value of the list item
                        {
                            Console.WriteLine($"Name: {p.Name}");
                            Console.WriteLine($"Age: {p.Age}");
                            Console.WriteLine($"Address: {p.Address}");
                            Console.WriteLine("_--_,_--__--_,_--__--_,_--__--_,_--_");
                        }
                    }
                }
                else if (choice == "3") // modify record
                {
                    if (people.Count == 0) // returns total number of records
                    {
                        Console.WriteLine("No records to update.");
                        continue;
                    }

                    // creates an indexed menu option of people records
                    Console.WriteLine("\nSelect a record to update:");
                    for (int i = 0; i < people.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {people[i].Name}"); // i+1 corrects zero based indexing
                    }
                    Console.WriteLine($"{people.Count + 1} - Cancel"); // cancel option is total records plus 1

                    Console.Write("Choice: ");
                    bool validIndex = int.TryParse(Console.ReadLine(), out int index); // attempts to convert input to int
                                                                                       // avoids invalid input crashes
                                                                                       // if valid the number is stored in index

                    if (!validIndex || index < 1 || index > people.Count + 1) // rejects anything outside of the menu range
                                                                              // catches failed conversions like letters or blank inputs
                    {
                        Console.WriteLine("Invalid choice.");
                        continue;
                    }

                    if (index == people.Count + 1) // this is the cancel option to exit to the main menu
                    {
                        Console.WriteLine("Update Cancelled.");
                        continue;
                    }

                    Person person = people[index - 1]; // user selection minus 1 because List indexes begin at 0
                                                       // stores a reference to the orginial Person object so any changes made to person
                                                       // will update the actual list entry

                    Console.WriteLine("Leave any field blank to keep current value."); // begins field by field updates

                    Console.Write($"Update name (current: {person.Name}): ");
                    string newName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newName)) // if string is not null or empty then a newName is written
                    {
                        person.Name = newName;
                    }

                    Console.Write($"Update age (current: {person.Age}): ");
                    string ageInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(ageInput)) // again we handle blank input with no changes
                    {
                        bool ageValid = int.TryParse(ageInput, out int newAge); // verify ageInput is a valid integer and writes newAge
                        if (ageValid && newAge >= 0 && newAge <= 130)           // verify age validity between 0 & 130
                        {
                            person.Age = newAge;
                        }
                        else
                        {
                            Console.WriteLine("Invalid age. Existing value remains unchanged."); // handles invalid input gracefully
                        }
                    }

                    Console.Write($"Update address (current: {person.Address}): "); // similar systems as above
                    string newAddress = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newAddress)) // empty input check
                    {
                        person.Address = newAddress; // if valid string update record
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

    public class Person // defines the new Person class that is accessible from other parts of the program within the same namespace
    {
        public string Name; // field (variable belonging to a class), public and is a string type
        public int Age; // public field that is an integer type
        public string Address;
    }
}