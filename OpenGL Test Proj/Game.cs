using System;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace OpenGlTesting
{
    internal class Game : GameWindow
    {
        int ScreenWidth;
        int ScreenHeight;
        VAO Vao;
        List<Vector3> vertices = new List<Vector3>
        {
            new Vector3(0f, 0.5f, 0f),
            new Vector3(-0.5f, -0.5f, 0f),
            new Vector3(0.5f, 0.5f, 0f)
        };

        List<uint> indices = new List<uint>
        {
            0, 1, 2
        };

        public Game(int width, int height) : base(GameWindowSettings.Default, NativeWindowSettings.Default)
        {
            this.CenterWindow(new Vector2i(width, height));
            ScreenWidth = width;
            ScreenHeight = height;
        }

        // Called on launch
        protected override void OnLoad()
        {
            base.OnLoad();
            Vao = new VAO();
            VBO vbo = new VBO(vertices);
            Vao.LinkToVao(0, 3, vbo);
            IBO ibo = new IBO(indices);
        }

        // On window size change
        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, e.Width, e.Height);
            this.ScreenWidth = e.Width;
            this.ScreenHeight = e.Height;
        }

        // On frame rendered - for shaders etc
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.ClearColor(1.0f, 0.4f, 0.7f, 1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            Context.SwapBuffers(); // Swap draw window to display window

            base.OnRenderFrame(args);
        }

        // On frame update - logic for game
        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
        }

        // Called on close
        protected override void OnUnload()
        {
            base.OnUnload();
        }
    }
}