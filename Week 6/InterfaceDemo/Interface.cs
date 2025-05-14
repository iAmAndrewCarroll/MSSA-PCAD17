using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    internal class Interface
    {

        class A
        {

        }

        class B : A, IMath, IDisposable
        {
            public int Add(int x, int y)
            {
                return x + y;
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }



        class C : A
        {

        }

        class D : B
        {

        }

        interface IMath
        {
            int Add(int x, int y);
            
        }

    }
}
