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
        IBO Ibo;
        ShaderProgram Shaders;
        Texture Texture;
        List<Vector3> vertices = new List<Vector3>
        {
            new Vector3(-0.5f, 0.5f, 0f),
            new Vector3(0.5f, 0.5f, 0f),
            new Vector3(0.5f, -0.5f, 0f),
            //new Vector3(-0.5f, -0.5f, 0f)
        };

        List<uint> indices = new List<uint>
        {
            0, 1, 2,
            //2, 3, 0
        };

        List<Vector2> texCoords = new List<Vector2>()
        {
            new Vector2(0f, 1f),
            new Vector2(1f, 1f),
            new Vector2(1f, 0f),
            new Vector2(0f, 0f),
            
            new Vector2(0f, 1f),
            new Vector2(1f, 1f),
            new Vector2(1f, 0f),
            new Vector2(0f, 0f),

            new Vector2(0f, 1f),
            new Vector2(1f, 1f),
            new Vector2(1f, 0f),
            new Vector2(0f, 0f),

            new Vector2(0f, 1f),
            new Vector2(1f, 1f),
            new Vector2(1f, 0f),
            new Vector2(0f, 0f),

            new Vector2(0f, 1f),
            new Vector2(1f, 1f),
            new Vector2(1f, 0f),
            new Vector2(0f, 0f),

            new Vector2(0f, 1f),
            new Vector2(1f, 1f),
            new Vector2(1f, 0f),
            new Vector2(0f, 0f),
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
            VBO uvVBO = new VBO(texCoords);
            
            Vao.LinkToVao(1, 2, uvVBO);
            Vao.LinkToVao(0, 3, vbo);
            Ibo = new IBO(indices);
            Shaders = new ShaderProgram("Shaders/Default.vert", "Shaders/Default.frag");

            Texture = new Texture("gold.jpg");
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
            GL.ClearColor(0f, 0.4f, 0.7f, 1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            Shaders.Bind();
            Vao.Bind();
            Ibo.Bind();
            Texture.Bind();

            GL.DrawElements(PrimitiveType.Triangles, indices.Count, DrawElementsType.UnsignedInt, 0);
        
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

            Vao.Dispose();
            Ibo.Delete();
            Shaders.Dispose();
        }
    }
}