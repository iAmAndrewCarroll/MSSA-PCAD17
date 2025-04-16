/*
=======================================================================
PART4.cs – Week 2 Challenge: Student Report (Refactored and Scalable)
=======================================================================

This version demonstrates:
- Using a dictionary to store subject/mark pairs
- Using computed properties for total and average
- Encapsulating logic inside the Student class
- Scalable, DRY, and ready for real-world modeling

| Step | What Happens                                | Where It Happens          |
|------|---------------------------------------------|---------------------------|
| 1    | A Student is initialized with full data     | Inside `Run()`            |
| 2    | Student class handles all calculations      | Through properties        |
| 3    | `Run()` just prints values — clean UI logic | Output loop and formatting|
| 4    | Division logic is computed automatically    | Property: `Division`      |
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Assignment_Tools;

namespace Challenge_Labs
{
    public class Part4
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("-- Challenge Lab Part 4: Student Report Card --\n");

            // Step 1: initialize a student with test data
            // the student is built using a constructor and a dictionary of subject marks.
            // moe scalable than separate fields for physics, chem, etc
            Student s = new Student(784, "James", new Dictionary<string, int>
            {
                { "Physics", 70 },
                { "Chemistry", 80 },
                { "Computer Application", 90 }
            });

            // Step 3: Print the formatted report using values from the student
            Console.WriteLine($"Student ID        : {s.StudentID}");
            Console.WriteLine($"Name of Student   : {s.Name}");

            // dynamically print each subject & mark from dictionary
            foreach (var subject in s.Marks)
            {
                Console.WriteLine($"Marks in {subject.Key,-20}: {subject.Value}");
            }

            // computed properties handle the math, this just displays values
            Console.WriteLine($"Total Marks       = {s.Total}");
            Console.WriteLine($"Percentage        = {s.Percentage:F2}"); //F2 formats to 2 decimal places
            Console.WriteLine($"Division          = {s.Division}");

            Utilities.Pause(); // wait for user input before returning
        }

        // student class encapsulates all data and logic
        public class Student
        {
            public int StudentID { get; set; }
            public string Name { get; set; }
            public Dictionary<string, int> Marks { get; set; } // Key = subject name, Value = score

            // constructor accepts everything up front
            public Student(int studentID, string name, Dictionary<string, int> marks)
            {
                StudentID = studentID;
                Name = name;
                Marks = marks;
            }

            // Computed property: sums all marks
            public int Total => Marks.Values.Sum();

            // Computed property: average of all marks (subject scores)
            public double Percentage => Marks.Values.Average(); // handles the actual mathematical division

            // Computed property: determines division based on percentage
            public string Division // Division here means student ranking, not x / y
            {
                get
                {
                    if (Percentage >= 60) return "First";
                    if (Percentage >= 50) return "Second";
                    if (Percentage >= 40) return "Third";
                    return "Fail";
                }
            }
        }
    }
}
