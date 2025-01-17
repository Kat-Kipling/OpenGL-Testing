﻿using System;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace OpenGlTesting
{
    class Program
    {
        public static void Main(string[] args)
        {
            using(Game game = new Game(2560, 1440))
            {
                game.Run();
            }
        }
    }
}