# Assignment 2.1-a – Exercise Class with Properties and Enums

## Overview

This example demonstrates how to model a flexible, reusable exercise inventory system using 
a single class (`Exercise`) with well-defined properties and enum-based categories.

It is designed to meet the requirements of the "class with properties" model as demonstrated in 
MSSA (e.g., Pet examples) while reinforcing real-world programming best practices for modeling scalable data.

Whereas `Part1.cs` uses inheritance to create hardcoded movement types (BenchPress, Deadlift, Squat), 
this version treats exercises as individual objects, using properties to describe and differentiate each one.

---

## Key Concepts Demonstrated

- Property-based class design
    - `Name`, `Category`, `Equipment`, and `TargetMuscle` are all public properties
    - `Name` and `TargetMuscle` are validated using `Utilities.IsValidString()`

- Enums for structured, safe values
    - `LiftCategory` enum defines controlled categories like Push, Pull, and Legs
    - `EquipmentType` enum defines valid equipment options

- Object initialization syntax
    - Exercises are created using object initializers like:

        new Exercise
        {
            Name = "Deadlift",
            Category = LiftCategory.Pull,
            Equipment = EquipmentType.Barbell,
            TargetMuscle = "Posterior Chain"
        };

- Looping over an object array
    - Exercises are stored in an array and iterated using a `foreach` loop

- Single method output
    - The `Describe()` method prints all property values in a consistent, readable format

---

## Comparison to the Pet Example

In MSSA, your instructor likely showed something like:

    public class Pet
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
    }

    Pet dog = new Pet { Name = "Rex", Species = "Dog", Age = 4 };
    Pet cat = new Pet { Name = "Whiskers", Species = "Cat", Age = 2 };

This teaches:
- How to define a class with properties
- How to create multiple objects using the same class
- How to assign different values to each object

Your `Exercise` example in `Part1_a.cs` follows the same model, but uses enums and validation
for a more robust implementation:

    Exercise bench = new Exercise
    {
        Name = "Barbell Bench Press",
        Category = LiftCategory.Push,
        Equipment = EquipmentType.Barbell,
        TargetMuscle = "Chest, Shoulders, Triceps"
    };

    Exercise deadlift = new Exercise
    {
        Name = "Deadlift",
        Category = LiftCategory.Pull,
        Equipment = EquipmentType.Barbell,
        TargetMuscle = "Posterior Chain"
    };

---

## Why `Part1.cs` Is Different

`Part1.cs` demonstrates **OOP inheritance**, not property-driven data modeling.

It uses:
- A base class: `Exercise`
- Subclasses: `BenchPress`, `Deadlift`, `Squat`
- Hardcoded data inside constructors
- Method overriding via `Describe()`

This is great for:
- Showing how inheritance works
- Demonstrating polymorphism and behavior overriding

But it is not good for:
- Creating large, varied sets of exercises
- Allowing user- or AI-generated exercise data
- Flexible editing or importing from a database

---

## Summary Table

| Feature                  | Part1.cs (OOP)                 | Part1_a.cs (Properties)       |
|--------------------------|--------------------------------|-------------------------------|
| Class Structure          | Inheritance tree               | Single class with properties  |
| Object Creation          | `new BenchPress()`             | `new Exercise { ... }`        |
| Flexibility              | Low (hardcoded behavior)       | High (data-driven)            |
| Polymorphism             | Yes (via override)             | No (single Describe method)   |
| Use Case                 | Demonstrate OOP design         | Model data for real apps      |
| Ideal for App Dev        | No                             | Yes                           |

---

## Final Takeaway

If you're building a system where behaviors differ (like `Bird.Fly()` vs `Dog.Bark()`), 
inheritance (`Part1.cs`) makes sense.

But if you're building a system where the *data* changes — like an exercise library, 
product catalog, or user-driven form — you want a flexible, property-based model like `Part1_a.cs`.

This version is better suited for:
- Real-world applications
- AI-generated content
- Inventory or database integration
- Custom user input

---

## Key Learning Breakthrough (How It Finally Clicked)

This understanding emerged through comparison and reflection:

> “So Part1.cs is exercise types:
> Push : Exercise  
> Pull : Exercise  
> Legs : Exercise  
>
> But it drills down again to another subclass:  
> Bench Press : Push  
> Deadlift : Pull  
> Squat : Legs  
>
> Where Bench Press has hardcoded built-in class values that cannot be changed (and so do the other movements). 
So it is less flexible overall.”

This helped reveal that:
- `Part1.cs` is a good demonstration of inheritance and polymorphism,
- But **each movement is tightly coupled to its class**, which limits flexibility, especially for 
user-defined or AI-generated content.

The realization continued:

> “So if I want to build an actual exercise coaching app I would want to do it like an 'Exercise Inventory System':
>
> Exercise -> new Exercise { ... }
>
> It’s repetitive, but once created, the exercise can be called and leveraged just like in Part1.cs.”

That’s the architectural leap — understanding that **data-first modeling using properties** 
(as in `Part1_a.cs`) allows you to:
- Store movements
- Query and reuse them
- Pass them into AI systems or generators
- Save/load them from databases
- Dynamically evolve your app

While OOP inheritance teaches structure, **property-based modeling builds apps**.

---

============================================================
Assignment 2.1 – Part 3: Abstract Class Shape Area Calculator
============================================================

This file demonstrates how to use an abstract base class to enforce structure and behavior
across multiple derived classes.

Key Concepts:
-------------
- Instantiation is the process of creating a real object from a class.  
    - Classes are blueprints that define structure and behavior
    - Instantiation is when you actually build something from the blueprint
- An abstract class (Shape) cannot be instantiated directly.
  It acts as a blueprint, defining shared properties (Id, Name, Color) and requiring that all
  derived classes implement their own version of the abstract method CalculateArea().

- Circle and Square both inherit from Shape.
  They provide their own logic for how to calculate area based on their specific dimensions.

- The user selects a shape and enters the required values at runtime — no hardcoded values.
  The program then displays the shape's information and the calculated area.

This approach demonstrates inheritance, encapsulation, method overriding,
and polymorphism (a Shape variable calling the correct child method).
