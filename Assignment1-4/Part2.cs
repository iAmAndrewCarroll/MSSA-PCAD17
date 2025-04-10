using System;
using Assignment_Tools; // gives access to shared utilities for clean input and formatting

namespace Assignment1_4
{
    public class Part2
    {
        public static void Run()
        {
            Console.WriteLine("\n-- Strength & Conditioning: Trainee Intake Form --");

            // all input is validated using reusable methods from Utilities.cs

            string firstName = Utilities.ReadNonEmptyString("Enter Trainee First Name: ");
            string lastName = Utilities.ReadNonEmptyString("Enter Trainee Last Name: ");
            int uid = Utilities.ReadInt("Enter Trainee UID (numeric ID): ");
            string goal = Utilities.ReadNonEmptyString("Enter Primary Goal (Fat Loss, Muscle Gain, Powerlifting): ");

            double startWeight = Utilities.ReadPositiveDouble("Enter Starting Weight (lbs): ");
            double currentWeight = Utilities.ReadPositiveDouble("Enter Current Weight (lbs): ");

            double dbIncline = Utilities.ReadPositiveDouble("Dumbbell Incline Bench Press (lbs): ");
            double squat = Utilities.ReadPositiveDouble("Back Squat (lbs): ");
            double deadlift = Utilities.ReadPositiveDouble("Deadlift (lbs): ");

            // instantiate trainee object and assign values via properties
            Trainee trainee = new Trainee
            {
                FirstName = firstName,
                LastName = lastName,
                UID = uid,
                Goal = goal,
                StartingWeight = startWeight,
                CurrentWeight = currentWeight,
                DumbbellIncline = dbIncline,
                Squat = squat,
                Deadlift = deadlift
            };

            Console.WriteLine("\n-- Trainee Summary --");
            Console.WriteLine($"Name: {trainee.FirstName} {trainee.LastName}");
            Console.WriteLine($"UID: {trainee.UID}");
            Console.WriteLine($"Goal: {trainee.Goal}");
            Console.WriteLine($"Start Weight: {trainee.StartingWeight} lbs");
            Console.WriteLine($"Current Weight: {trainee.CurrentWeight} lbs");
            Console.WriteLine($"Progress {trainee.Progress:F1} lbs {(trainee.Progress >= 0 ? "gained" : "lost")}");
            Console.WriteLine();
            Console.WriteLine("-- Lifting Metrics --");
            Console.WriteLine($"Incline DB Press: {trainee.DumbbellIncline} lbs");
            Console.WriteLine($"Back Squat:         {trainee.Squat} lbs");
            Console.WriteLine($"Deadlift:           {trainee.Deadlift} lbs");

            Utilities.Pause(); // keeps the console open until user presses ENTER
            Console.Clear(); // only clears after user presses ENTER
        }
    }

    public class Trainee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UID { get; set; }
        public string Goal { get; set; }

        public double StartingWeight { get; set; }
        public double CurrentWeight { get; set; }

        public double DumbbellIncline { get; set; }
        public double Squat { get; set; }
        public double Deadlift { get; set; }

        // Read-only calculated property
        public double Progress
        {
            get { return CurrentWeight - StartingWeight; }
        }
    }
}