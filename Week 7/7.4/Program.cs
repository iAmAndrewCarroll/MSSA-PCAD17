using System;
using System.Collections.Generic;
using System.Threading;

/*
 * Assigment 7.4 - Parking System
 * 
 * restate the problem :
 * design a class ParkingSystem to manage a parking lot with fixed capacity for 3 types of cars
 * types : big, medium, small
 * 
 * Given number of slots for each on initialization
 * 
 * cars arrive one at a time --> each incoming car via addCar(int carType);
 * free space == car's type --> park and return true parked on level "random assigned between a - g" in "random number gen between 1 & 175" space in Mercer Street Garage.
 * car type != free space --> return false "no space for "car type name" in Mercer Street Garage.
 * 
 * verbal logic step through :
 * ParkingSystem( parking values)
 * add car n -> true if parking slots are available for car type 
 * 
 * build the parking garage with random levels a-g, random parking spaces generated between 65 - 101 in Mercer Street Garage
 * spaces divided into large, medium, compact spaces where there should be more compact > medium > large spaces
 * entry request based on size =? space? --> each entry size space--
 * 
 * Construct initial counts
 * add Car (int carType) : is slot for type > 0?
 * --> yes ? decrement parking --> return true
 * --> no --> return false
 * 
 * 
 * Remember the flowerbed problem from week 6:
 * checking if we could plant without violating contstraints
 * instead of adjency rules we are now dealing iwth resource limits
 * 
 * same core pattern : check a rule --> mutate state --> return boolean and console message
 * 
 * Pseudocode :
 * 
 * ParkingSystem Class
 * Initialize Dictionary int int slots
 * Dictionary int string typeNames
 * 
 * Random Generator
 * character array levels of parking garage
 * 
 * Construct ParkingSystem int big, int med, int small
 * initialize slots: 1 big, 2 medium, 3 small
 * 
 * typeNames: 1 big, 2 medium, 3 small
 * 
 * initialize randomGen
 * 
 * bool addCar int carType
 * if slots for car type > 0
 *  decrement slots carType
 *  level = random letter a - g from levels array
 *  space = random number from 65 to 101
 *  
 *  print : parked on level, space in Mercer Street Garage
 *  return true
 * else
 *  name = typeNames carType
 *  print : no space for [name] car in Mercer Street Garage."
 *  return false
 * 
 * 
 * 
 * 
 */

namespace _7._4
{
    public class ParkingSystem
    {
        private Dictionary<int, int> slots;
        private Dictionary<int, string> typeNames;
        private Random randomGen;
        private char[] levels = { 'A', 'B', 'C', 'D', 'E', 'F', 'G' };
        private Queue<string> recentMessages = new Queue<string>();

        public ParkingSystem(int totalCapacity)
        {
            int big = (int)(totalCapacity * .2);
            int medium = (int)(totalCapacity * .3);
            int small = totalCapacity - big - medium;

            slots = new Dictionary<int, int>();
            slots.Add(1, big);
            slots.Add(2, medium);
            slots.Add(3, small);

            typeNames = new Dictionary<int, string>();
            typeNames.Add(1, "SUV");
            typeNames.Add(2, "Sedan");
            typeNames.Add(3, "Compact");

            randomGen = new Random();
        }

        public bool addCar(int carType)
        {
            if (slots[carType] > 0)
            {
                slots[carType]--;

                char level = levels[randomGen.Next(levels.Length)];
                int space = randomGen.Next(1, 102);
                string label = $"{level}-{space:D3}";
                string msg = $"{typeNames[carType]} parked in {label} at Mercer Street Garage.";
                EnqueueMessage(msg);
                return true;
            }
            else
            {
                string msg = $"No space for {typeNames[carType]} in Mercer Street Garage.";
                EnqueueMessage(msg);
                return false;
            }
        }

        private void EnqueueMessage(string msg)
        {
            if (recentMessages.Count == 3)
            {
                recentMessages.Dequeue();
            }
            recentMessages.Enqueue(msg);
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("7.4 - Mercer Street Parking Garage");
            Console.WriteLine("-----------------------------------");
            foreach (string message in recentMessages)
            {
                Console.WriteLine(message);
            }
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();
            Console.WriteLine("Remaining Parking Spaces:");

            foreach (var pair in slots)
            {
                Console.WriteLine($"{typeNames[pair.Key]}: {pair.Value}");
            }
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();
            Console.WriteLine("Press ESC to exit.");
        }

        public bool IsFull()
        {
            return slots[1] == 0 && slots[2] == 0 && slots[3] == 0;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            ParkingSystem garage = new ParkingSystem(33);
            Random rng = new Random();

            while (true)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Exiting...");
                    break;
                }

                if (garage.IsFull())
                {
                    garage.Display();
                    Console.WriteLine("Garage is full. Simulation ended.");
                    break;
                }

                int carType = rng.Next(1, 4);
                garage.addCar(carType);
                garage.Display();
                Thread.Sleep(800);
            }
        }
    }
}