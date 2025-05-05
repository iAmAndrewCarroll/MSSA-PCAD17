// a demonstration on methods and classes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod1Demo1
{	
	// utility class
	static class Conversions
	{
		public static void DegreesToFahren(double num)
		{

		}
		public void Test()
		{

		}
	}

	class Test
	{
		public static void Method1()
		{

		}
		public void Method2()
		{

		}
	}

	// beverage (base class / base template) --> Tea
	internal abstract class A
	{
		public void abstract AbsMethod(); // must be overriden. Abstract has no internals

		public virtual void VirtualMethod() // can be overriden
		{
			Console.WriteLine("in virtual method");
		}
	}

	// system
	// system.object (base class in .NET; 
	sealed class B:A // this is an executable, not a dll
	{
		public override void AbsMethod()
		{
			// write your own logic
		}

        public sealed override void VirtualMethod()
        {
            // base.VirtualMethod();
			// logic
        }
    }

	class C:B
	{
		
	}

	// start class hierarchy with abstract class, you end the hierarchy with 
	// sealed class
}
