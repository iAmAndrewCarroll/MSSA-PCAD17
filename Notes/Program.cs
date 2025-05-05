using System.IO;

namespace Mod1Demo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Document obj = new Document("abc");
            Console.WriteLine(obj.Name + " " + obj.I);
            Console.ReadKey();
            // Test ob = new Test();


        }



        // static 1:1
        // instance 1:many
        static int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        static int Add(int num1, int num2, int num3)
        {
            return num1 + num2 + num3;
        }
    }
}