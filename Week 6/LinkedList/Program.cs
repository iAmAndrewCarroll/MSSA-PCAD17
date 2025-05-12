namespace LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region linkedlistclass
            //LinkedList<int> list = new LinkedList<int>();
            //list.AddFirst(23);
            //list.AddLast(40);

            //foreach (int i in list)
            //{
            //    Console.WriteLine(i); // 23, 40
            //}
            //list.AddFirst(12); // 12, 23, 40
            //Console.WriteLine("Updated list: ");
            //foreach (int i in list)
            //{
            //    Console.WriteLine(i);
            //}

            //// 12, 100, 23, 40
            //var temp = list.Find(23); // gets ref of item 23
            //if (temp != null)
            //{
            //    list.AddBefore(temp, 100);
            //}

            //Console.WriteLine("Insert 100: ");
            //foreach (int i in list)
            //{
            //    Console.WriteLine(i);
            //} 
            #endregion

            customList customlist = new customList();
            customlist.AddFirst(1);
            customlist.AddFirst(23);
            customlist.AddFirst(34);
            customlist.Display();
            customlist.AddLast(50);
            customlist.Display();

            int result = customlist.RemoveFirst();
            Console.WriteLine($"Record {result} removed");
            customlist.Display();

            int last = customlist.RemoveLast();
            Console.WriteLine($"Record {last} removed");
            customlist.Display();

            //int val = customlist.RemoveLast();
            //Console.WriteLine($"Record {val} removed");
            //customlist.Display();

            customlist.AddLast(67);
            customlist.AddLast(90);
            customlist.Display();

            int index;
            bool found = customlist.Search(67, out index);
            if (found)
            {
                Console.WriteLine($"The number is found at {index} position.");
            }
            else
            {
                Console.WriteLine("Not found");
            }

            customlist.AddAnywhere(112, 3);
            customlist.Display();

            int val1 = customlist.RemoveAnywhere(3);
            Console.WriteLine($"Data {val1} is removed");
            customlist.Display();

            Console.ReadKey();
        }
    }
}