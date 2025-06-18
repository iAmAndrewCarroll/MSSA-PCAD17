using _10._3;
using System;
using System.Windows.Forms;

namespace _10._3
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
