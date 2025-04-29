using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo___iCalculator
{
    internal interface ICalculator
    {
        double Add(double x, double y);
        double Subtract(double x, double y);
        double Multiply(double x, double y);
        double Divide(double x, double y)
        {
            if (y == 0)
                throw new DivideByZeroException("Cannot divide by zero.");
            return x / y;
        }
    }
}

/* Interface is like a sort of contract monitor that requires that AT LEAST a method signature must be present.
"Do you have the specified element?" Yes or No.  It doesn't look at the internal structure of the method.  
In the demo from class the student grade book uses IComparable (a system using internal class) and a CompareTo()
method as examples.  

We also saw the demonstration of the interface calling red squigglies in the Calculator.cs before all the 
methods were created. */

