using System;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace OpenGlTesting
{
    internal class Game : GameWindow
    {
        private static int SCREENWIDTH;
        private static int SCREENHEIGHT;
        public Game(int width, int height) : base(GameWindowSettings.Default, NativeWindowSettings.Default)
        {
            this.CenterWindow(new Vector2i(width, height));
            SCREENWIDTH = width;
            SCREENHEIGHT = height;
        }
    }
}