/*
=======================================================
PART1-a.cs – Object Initialization + Property Assignment
=======================================================

This table explains the step-by-step flow of how an
Exercise object is created, how data moves through
properties, and how private fields are updated safely.

| Step | What Happens                                  | Where it Happens                         |
|------|-----------------------------------------------|------------------------------------------|
| 1    | Exercise object is created                    | `new Exercise { ... }`                   |
| 2    | Name = "Barbell Bench Press" runs             | Public `Name` property setter            |
| 3    | Value is validated                            | `Utilities.IsValidString(value, "Name")` |
| 4    | _name is assigned                             | `_name = value;` inside setter           |
| 5    | Enum fields are directly assigned             | `Category`, `Equipment` (public enums)   |
| 6    | TargetMuscle follows same logic as Name       | `TargetMuscle` setter with validation    |
| 7    | Describe() prints values using property getters| `get => _name`, etc.                     |
| 8    | Pause waits for next object                   | `Utilities.Pause()`                      |
*/

using Assignment_Tools; // Provides access to validation and utility methods

namespace Assignment2_1
{
    public class Part1_a
    {
        // This method is called when the user selects "1-a" from the main Program.cs menu
        // It demonstrates object modeling using enums and properties
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("-- Assignment 2.1-a: Exercise Class Using Enums --");
            Console.WriteLine("This demonstrates:");
            Console.WriteLine("  - Using enums to safely categorize exercise types");
            Console.WriteLine("  - Populating a class using object initializers");
            Console.WriteLine("  - Looping over a typed object array\n");

            // Define an array of Exercise objects — each with typed enum values
            Exercise[] lifts = new Exercise[]
            {
                new Exercise // triggers the default constructor (implicit)
                {
                    Name = "Barbell Bench Press", // assigning a value to Name (move down to 
                    // private string Name)
                    Category = LiftCategory.Push,
                    Equipment = EquipmentType.Barbell,
                    TargetMuscle = "Chest, Shoulders, Triceps"
                },
                new Exercise
                {
                    Name = "Deadlift",
                    Category = LiftCategory.Pull,
                    Equipment = EquipmentType.Barbell,
                    TargetMuscle = "Posterior Chain (Glutes, Hamstrings, Back)"
                },
                new Exercise
                {
                    Name = "Back Squat",
                    Category = LiftCategory.Legs,
                    Equipment = EquipmentType.Barbell,
                    TargetMuscle = "Quads, Glutes, Core"
                }
            };

            // After all object properties have been validated and assigned the loop begins
            foreach (var lift in lifts)
            {
                lift.Describe(); // Descibe is called from below
                Utilities.Pause(); // Wait for user input before continuing
            }
        }
    }

    // Defines a fixed set of categories for exercises
    // Enums = Blueprint Categories while Dynamic Objects allow custom entries
    public enum LiftCategory
    {
        Push,
        Pull,
        Legs
    }

    // Defines valid equipment types as an enum
    public enum EquipmentType
    {
        Barbell,
        Dumbbell,
        Machine,
        Bodyweight
    }

    // The Exercise class represents a single lift with descriptive properties
    public class Exercise
    {
        // The following fields are stored privately and exposed through public properties
        private string _name;
        public string Name // Barbell Bench Press comes down here
        {
            get => _name;
            set
            {
                if (Utilities.IsValidString(value, "Name")) // validation
                    _name = value; // if validation passes then _name is assigned the Name value
            }
        }

        private string _targetMuscle;
        public string TargetMuscle
        {
            get => _targetMuscle;
            set
            {
                if (Utilities.IsValidString(value, "Target Muscle"))
                    _targetMuscle = value;
            }
        }

        // Enums are value types, so no null checks required
        public LiftCategory Category { get; set; }

        public EquipmentType Equipment { get; set; }

        // Prints the information about this lift in a formatted way
        public void Describe()
        {
            Console.WriteLine($"\n{Name}"); // here Name is activating the getter and pulls the private
            // _name field safely and displays all the associated properties of the object
            Console.WriteLine($"  Category       : {Category}");
            Console.WriteLine($"  Equipment Used : {Equipment}");
            Console.WriteLine($"  Target Muscles : {TargetMuscle}\n");
        }
    }
}
