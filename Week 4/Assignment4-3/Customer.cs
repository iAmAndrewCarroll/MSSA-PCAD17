using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_3
{

    public class Customer
    {
        public int custID { get; set; }
        public string lastName { get; set; }
        public int kwhUsed { get; set; }

        public override string ToString() => $"ID: {lastName} - {custID} - {kwhUsed} kHh";
    }
}
