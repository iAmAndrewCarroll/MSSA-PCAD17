using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSA_Project.Utility
{
    public class DebugLogger
    {
        public static Label? OutputLabel { get; set; }

        public static void Log(string message)
        {
            var timestamp = DateTime.Now.ToString("HH:mm:ss");
            var formatted = $"[{timestamp}] {message}";

            Console.WriteLine(formatted); // Output window

            if (OutputLabel != null)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    OutputLabel.Text += formatted + Environment.NewLine;
                });
            }
        }

        public static void Clear()
        {
            if (OutputLabel != null)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    OutputLabel.Text = "";
                });
            }
        }
    }
}
