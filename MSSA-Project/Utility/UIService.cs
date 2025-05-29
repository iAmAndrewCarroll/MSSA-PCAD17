using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSA_Project.Utility
{
    public static class UIService
    {
        public static void DisplayError(Label targetLabel, string message)
        {
            targetLabel.Text = message;
            targetLabel.TextColor = Colors.OrangeRed;
            targetLabel.IsVisible = true;
        }

        public static async void FadeOut(Label label, int delayMs = 2500, uint fadeDuration = 400)
        {
            await Task.Delay(delayMs); 

            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                await label.FadeTo(0, fadeDuration);
                label.IsVisible = false;
                label.Opacity = 1; 
            });
        }
    }
}
