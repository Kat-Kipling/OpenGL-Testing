using System;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace OpenGlTesting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Default settings
            GameWindowSettings gws = GameWindowSettings.Default;
            NativeWindowSettings nws = NativeWindowSettings.Default;

            // Changing properties as needed for Game Window
            gws.UpdateFrequency = 144;

            // Changing properties as needed for Native Window
            nws.APIVersion = Version.Parse("4.1"); // 4.1 as aimed for recent hardware on any platform.
            nws.ClientSize = new Vector2i(1920, 1080);
            nws.Title = "Testing OpenGL";

            // Running window
            GameWindow MainWindow = new GameWindow(gws, nws);

            int i = 0;
            // Runs every frame
            MainWindow.UpdateFrame += (FrameEventArgs args)  =>
            {
                Console.WriteLine($"{i}");
                i++;
            };

            MainWindow.Run();
        }
    }
}