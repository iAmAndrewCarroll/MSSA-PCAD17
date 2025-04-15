using Assignment_Tools;  // access toolbox

namespace Assignment2_1
{
    // contains the logic for demoing OOP: inheritance and polymorphism
    public class Part1
    {
        // Run() is the main method called from Program.cs when user selects this module option
        public static void Run()
        {
            Console.Clear(); // clears the console window for clean output
            Console.WriteLine("-- Assignment 2.1: OOP Weightlifting Hierarchy Demo --");
            Console.WriteLine("This demonstrates:");
            Console.WriteLine("  - Inheritance (base class: Exercise");
            Console.WriteLine("  - Method overriding (Describe method)");
            Console.WriteLine("  - Constructors setting default values\n");

            // This array demonstrates runtime polymorphism.
            // Although the array is typed as Exercise[], each object maintains its true identity
            // and will call its own overridden Describe() method.
            // These are instances of derived classes (BenchPress, Deadlift, Squat)
            // stored in a base class array
            // This is POLYMORPHISM - treating child types as the parent type
            // Polymorphism: one method call (e.g. Describe()) behaves differently
            // depending on the object's actual type
            Exercise[] lifts = new Exercise[]
            {
                new BenchPress(), // push lift
                new Deadlift(), // pull lift
                new Squat(), // leg lift
            };

            // loop through each lift and call its Describe() method
            foreach (var lift in lifts)
            {
                // Even though 'lift' is typed as Exercise, the overridden Describe() method
                // from the actual object (BenchPress, Deadlift, etc.) is what gets executed
                // — this is runtime polymorphism
                lift.Describe(); // calls the correct overriden Describe() for each object


                // give the user a chance to read the output before moving to the next item
                Utilities.Pause(); // waits for user input
            }
        }
    }

    // base class: defines common structure for all exercises (the 'template')
    public class Exercise
    {
        // Private fields store the actual data - not directly accessible from outside
        private string _name;
        private string _primaryMuscleGroup;

        // property for Name - allows safe read/write with optional validation
        public string Name
        {
            get { return _name; }
            set
            {
                // validate before saving: uses Utilities.IsValidString() to reject blank values
                if (Utilities.IsValidString(value, "Name"))
                    _name = value;
            }
        }

        // Property for PrimaryMuscleGroup - also validated via Utilities
        public string PrimaryMuscleGroup
        {
            get { return _primaryMuscleGroup; }
            set
            {
                if (Utilities.IsValidString(value, "Primary Muscle Group"))
                    _primaryMuscleGroup = value;
            }
        }

        // Virtual method that child classes can override to give more specific output
        public virtual void Describe()
        {
            Console.WriteLine($"Exercise: {Name} - Targets: {PrimaryMuscleGroup}");
        }
    }

    // Child Class 1 - Bench Press (inherits from Exercise)
    public class BenchPress : Exercise
    {
        // Constructor sets the name and primary muscle group by calling the base class properties
        public BenchPress()
        {
            Name = "Barbell Bench Press";
            PrimaryMuscleGroup = "Chest, Shoulders, Triceps";
        }

        // Override Describe to give a more specific message
        public override void Describe()
        {
            Console.WriteLine($"{Name} - A push lift that primarily targets the {PrimaryMuscleGroup}.");
        }
    }

    // Child Class 2 - Deadlift (inherits from Exercise)
    public class Deadlift : Exercise
    {
        public Deadlift()
        {
            Name = "Barbell Deadlift";
            PrimaryMuscleGroup = "Posterior Chain (Glutes, Hamstrings, Back)";
        }

        public override void Describe()
        {
            Console.WriteLine($"{Name} - A pull lift that works the {PrimaryMuscleGroup}.");
        }
    }

    // Child Class 3 - Squat (inherits from Exercise)
    public class Squat : Exercise
    {
        public Squat()
        {
            Name = "Back Squat";
            PrimaryMuscleGroup = "Quads, Glutes, Core";
        }

        public override void Describe()
        {
            Console.WriteLine($"{Name} - A foundational lower body lift activating the {PrimaryMuscleGroup}.");
        }
    }
}