using System;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace OpenGlTesting
{
    internal class Game : GameWindow
    {
        int ScreenWidth;
        int ScreenHeight;
        Camera Camera;
        ShaderProgram Shaders;
        float yRot = 0.0f;

        EntityLoader loader = new EntityLoader();
        Renderer renderer = new Renderer();
        Model cube;
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

            cube = ModelLoader.LoadModelFromObj("pp", loader);
            Shaders = new ShaderProgram("Shaders/Default.vert", "Shaders/Default.frag");

            Camera = new Camera(ScreenWidth, ScreenHeight, Vector3.Zero);
            CursorState = CursorState.Grabbed;
            GL.Enable(EnableCap.DepthTest);
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
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 model = Matrix4.Identity;
            Matrix4 view = Camera.GetViewMatrix();
            Matrix4 projection = Camera.GetProjectionMatrix();

            model = Matrix4.CreateRotationY(yRot);
            yRot += 0.001f;
            
            Matrix4 translation = Matrix4.CreateTranslation(0f, 0f, -3f);

            model *= translation;

            int modelLocation = GL.GetUniformLocation(Shaders.Id, "model");
            int viewLocation = GL.GetUniformLocation(Shaders.Id, "view");
            int projectionLocation = GL.GetUniformLocation(Shaders.Id, "projection");

            GL.UniformMatrix4(modelLocation, true, ref model);
            GL.UniformMatrix4(viewLocation, true, ref view);
            GL.UniformMatrix4(projectionLocation, true, ref projection);

            renderer.RenderModel(cube);
            Shaders.Bind();
        
            Context.SwapBuffers(); // Swap draw window to display window


            base.OnRenderFrame(args);
        }

        // On frame update - logic for game
        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            MouseState mouse = MouseState;
            KeyboardState keybIn = KeyboardState;
            base.OnUpdateFrame(args);
            Camera.Update(keybIn, mouse, args);
        }

        // Called on close
        protected override void OnUnload()
        {
            base.OnUnload();
            loader.Dispose();
            Shaders.Dispose();
        }
    }
}