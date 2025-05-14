namespace QueueDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customers = new Queue<string>();

            Console.WriteLine("Original Customer Queue");
            customers.Enqueue("Alex");
            customers.Enqueue("Dave");
            customers.Enqueue("Eileen");
            foreach (var item in customers)
            {
                Console.WriteLine(item + " ");
            }

            Console.WriteLine();
            customers.Dequeue();
            Console.WriteLine("Customer Queue After Dequeue: ");
            foreach (var item in customers)
            {
                Console.WriteLine(item + " ");
            }

            Console.WriteLine();

            Console.WriteLine("Custom Queue Implementation:");
            Console.WriteLine();

            Console.WriteLine("Enqueue 1 - 4");
            Queue myq = new Queue(8);
            myq.Enqueue(1);
            myq.Enqueue(2);
            myq.Enqueue(3);
            myq.Enqueue(4);

            Console.WriteLine();
            myq.Display();
            Console.WriteLine();

            Console.WriteLine("Dequeue first element: 1");
            myq.Dequeue();
            myq.Display();
            Console.WriteLine();

            Console.WriteLine("Dequeue remaining elements: 2, 3, 4");
            myq.Dequeue();
            myq.Dequeue();
            myq.Dequeue();
            Console.WriteLine();
            myq.Display();
            Console.WriteLine();

            Console.WriteLine("Enqueue item: 100");
            myq.Enqueue(100);
            Console.WriteLine();
            myq.Display();

            Console.WriteLine();
            Console.WriteLine("Linked List as a Queue:");
            Console.WriteLine();
            Console.WriteLine("Enqueue 12, 13, 14, 15 to new Linked List Queue:");
            Console.WriteLine();
            Q linkQueue = new Q();
            linkQueue.Enqueue(12);
            linkQueue.Enqueue(13);
            linkQueue.Enqueue(14);
            linkQueue.Enqueue(15);
            Console.WriteLine();
            Console.WriteLine("The fully formed new Linked List Queue:");
            linkQueue.Display();

            Console.WriteLine();
            Console.WriteLine("Dequeue 12, 13, 14:");
            linkQueue.Dequeue();
            linkQueue.Dequeue();
            linkQueue.Dequeue();
            Console.WriteLine();
            linkQueue.Display();

            Console.WriteLine();
            Console.WriteLine("Dequeue 15 should Empty Queue:");
            linkQueue.Dequeue();
            Console.WriteLine();
            linkQueue.Display();


            Console.ReadKey();

        }
    }
}