using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace _6._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Q customers = new Q(); // custom linked list queue

            Console.WriteLine("Assignment 6.3 : Customers in Queue : Use Linked Lists");
            Console.WriteLine();

            Console.WriteLine("Are there any customers in queue?");
            customers.Display();
            Console.WriteLine();

            Console.WriteLine("Enqueueing Customers:");
            customers.Enqueue(8675309);
            customers.Enqueue(5555555);
            customers.Enqueue(8004567);
            customers.Enqueue(65743892);

            Console.WriteLine("\nCurrent Queue:");
            customers.Display();
            Console.WriteLine($"Front: {customers.GetFront()}");
            Console.WriteLine($"Rear: {customers.GetRear()}");
            Console.WriteLine();

            Console.WriteLine("Dequeuing 3 customers:");
            customers.Dequeue();
            customers.Dequeue();
            customers.Dequeue();
            Console.WriteLine();

            Console.WriteLine("Queue after Dequeues:");
            customers.Display();
            Console.WriteLine($"Front: {customers.GetFront()}");
            Console.WriteLine($"Rear: {customers.GetRear()}");
            Console.WriteLine();

            Console.WriteLine("Final Dequeue:");
            customers.Dequeue();
            Console.WriteLine();
            customers.Display();
            Console.WriteLine($"Front: {customers.GetFront()}");
            Console.WriteLine($"Rear: {customers.GetRear()}");
            Console.WriteLine();




            Console.ReadKey();
        }
    }
}