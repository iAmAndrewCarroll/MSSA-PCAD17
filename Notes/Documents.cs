using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod1Demo1
{
	internal class Document()
	{
		private int i;

		public Document()
		{
			this.i = 100; // a default initialization
			this.i
		}

		public Document(string name)
		{
			this.name = name;
		}

		public int I
		{
			get { return i; }
		}
		private string? name;
		public string Name
		{
			get { return this.name; }
		}
	}
}
