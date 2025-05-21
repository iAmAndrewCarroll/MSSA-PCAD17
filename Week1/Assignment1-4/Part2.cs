using System;                             // provides access to core C# types like Console, string, int
using Toolbox;                            // gives access to reusable methods like ReadDouble, ReadInt, etc.

namespace Assignment1_4                   // keeps this part grouped with related assignment logic
{
    // This file demonstrates basic object-oriented programming (OOP):
    // - We define a Trainee "class" as a blueprint
    // - We create an instance (object) of that class
    // - We store and access trainee data through public properties
    public class Part2
    {
        public static void Run()          // Run() is the entry point for Part2 — called from the main menu in Program.cs
        {
            Console.WriteLine("\n-- Strength & Conditioning: Trainee Intake Form --");

            // collect trainee input using shared utility methods that validate input types
            string firstName = Utilities.ReadNonEmptyString("Enter Trainee First Name: ");
            string lastName = Utilities.ReadNonEmptyString("Enter Trainee Last Name: ");
            int uid = Utilities.ReadInt("Enter Trainee UID (numeric ID): ");
            string goal = Utilities.ReadNonEmptyString("Enter Primary Goal (Fat Loss, Muscle Gain, Powerlifting): ");

            double startWeight = Utilities.ReadPositiveDouble("Enter Starting Weight (lbs): ");
            double currentWeight = Utilities.ReadPositiveDouble("Enter Current Weight (lbs): ");

            double dbIncline = Utilities.ReadPositiveDouble("Dumbbell Incline Bench Press (lbs): ");
            double squat = Utilities.ReadPositiveDouble("Back Squat (lbs): ");
            double deadlift = Utilities.ReadPositiveDouble("Deadlift (lbs): ");

            // Create a new Trainee object and assign values to its properties using object initializer syntax
            // "Trainee" is the class (like a blueprint); "trainee" is the object (an instance of the class)
            // Each property in the object is assigned a value collected from user input
            Trainee trainee = new Trainee
            {
                FirstName = firstName,               // assign to public property
                LastName = lastName,
                UID = uid,
                Goal = goal,
                StartingWeight = startWeight,
                CurrentWeight = currentWeight,
                DumbbellIncline = dbIncline,
                Squat = squat,
                Deadlift = deadlift
            };

            // Display the trainee's profile information
            Console.WriteLine("\n-- Trainee Summary --");
            Console.WriteLine($"Name: {trainee.FirstName} {trainee.LastName}");
            Console.WriteLine($"UID: {trainee.UID}");
            Console.WriteLine($"Goal: {trainee.Goal}");
            Console.WriteLine($"Start Weight: {trainee.StartingWeight} lbs");
            Console.WriteLine($"Current Weight: {trainee.CurrentWeight} lbs");
            Console.WriteLine($"Progress {trainee.Progress:F1} lbs {(trainee.Progress >= 0 ? "gained" : "lost")}");

            // Display the trainee's strength metrics
            Console.WriteLine();
            Console.WriteLine("-- Lifting Metrics --");
            Console.WriteLine($"Incline DB Press: {trainee.DumbbellIncline} lbs");
            Console.WriteLine($"Back Squat:         {trainee.Squat} lbs");
            Console.WriteLine($"Deadlift:           {trainee.Deadlift} lbs");

            Utilities.Pause();          // waits for ENTER before continuing
            Console.Clear();            // clears the screen after pause
        }
    }

    // This class defines a Trainee as a set of related data and behaviors
    // It uses public properties so data can be read and written from other classes
    public class Trainee
    {
        // Each of these is a public property — this allows access from outside this class
        // { get; set; } is shorthand for defining automatic getter and setter methods
        // - get allows reading the value
        // - set allows assigning a new value
        public string FirstName { get; set; }         // string property for trainee's first name
        public string LastName { get; set; }          // string property for trainee's last name
        public int UID { get; set; }                  // unique identifier for this trainee
        public string Goal { get; set; }              // training goal like "Fat Loss" or "Muscle Gain"

        public double StartingWeight { get; set; }    // initial bodyweight in pounds
        public double CurrentWeight { get; set; }     // most recent bodyweight check-in

        public double DumbbellIncline { get; set; }   // dumbbell incline bench press weight
        public double Squat { get; set; }             // squat 1-rep max
        public double Deadlift { get; set; }          // deadlift 1-rep max

        // This is a computed property — it has no backing variable
        // Every time you access it, it recalculates current - starting weight
        public double Progress
        {
            get { return CurrentWeight - StartingWeight; }  // positive = gained weight; negative = lost weight
        }
    }
}
