using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revision
{
    internal class SwapData<T>
    {
        public void Swap(ref T num1, ref T num2)
        {
            T temp;
            temp = num1;
            num1 = num2;
            num2 = temp;
        }
    }

    class CustomList<T> : IEnumerable<T>
    {
        T[] arr;
        public CustomList(int size)
        {
            arr = new T[size];
        }

        public void Add(T data)
        {

        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
