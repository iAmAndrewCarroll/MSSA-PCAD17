using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    internal class Student : IComparable<Student>, IComparer<Student>
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public float GPA { get; set; }
        public int Age { get; set; }

        public int Compare(Student? x, Student? y) // comes from iComparer : 
        {
            //return x.GPA.CompareTo(y.GPA);
            return y.GPA.CompareTo(x.GPA);
        }

        public int CompareTo(Student? other) // comes from iComparable : Sorting names 
        {
            int val = String.Compare(this.Name, other.Name, StringComparison.OrdinalIgnoreCase);
            return val;
        }
    }
}
