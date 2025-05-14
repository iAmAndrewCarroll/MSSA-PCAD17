namespace InterfaceDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 11, 12, 3 };
            list.Sort();

            Console.WriteLine("Student List Sorted by Name:");
            List<Student> students = new List<Student>();
            students.Add(new Student() { Id = 2, Name = "Jake", GPA = 4.1f, Age = 40 });
            students.Add(new Student() { Id = 3, Name = "Zach", GPA = 3.9f, Age = 35 });
            students.Add(new Student() { Id = 4, Name = "Isaac", GPA = 3.1f, Age = 32 });
            students.Add(new Student() { Id = 5, Name = "Josh", GPA = 2.6f, Age = 30 });
            students.Add(new Student() { Id = 1, Name = "Andrew", GPA = 4.5f, Age = 39 });
            students.Sort();  // icomparable passes single object instance to compare to others for a 1, 0, -1 return
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Id}, {student.Name}, {student.GPA}");
            }

            Console.WriteLine();
            Console.WriteLine("GPA Sorting:");
            students.Sort(new Student()); // icomparer passes two objects to compare against one another for a 1, 0, -1 return
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Id}, {student.Name}, {student.GPA}");
            }

            Console.ReadKey();
        }
    }
}