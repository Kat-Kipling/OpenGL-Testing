using System.ComponentModel.Design;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace OpenGlTesting
{
    internal class Camera
    {
        private float SPEED = 8f;
        private float SCREENWIDTH;
        private float SCREENHEIGHT;
        private float SENSITIVITY = 80f;

        public Vector3 Position {get; set;}
        Vector3 right = Vector3.UnitX;
        Vector3 up = Vector3.UnitY;
        Vector3 front = -Vector3.UnitZ;
        public Camera(float width, float height, Vector3 position)
        {
            SCREENWIDTH = width;
            SCREENHEIGHT = height;
            Position = position;
        }

        public Matrix4 GetViewMatrix()
        {
            return Matrix4.LookAt(Position, Position+front, up);
        }

        public Matrix4 GetProjectionMatrix()
        {
            return Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), SCREENWIDTH / SCREENHEIGHT, 0.1f, 100.0f);
        }

        private void UpdateVectors()
        {

        }

        public void InputController(KeyboardState keybIn, MouseState mouseIn, FrameEventArgs eventArgs)
        {
            if(keybIn.IsKeyDown(Keys.W))
            {
                Position += front * SPEED * (float)eventArgs.Time;
            }
            if(keybIn.IsKeyDown(Keys.A))
            {
                Position -= right * SPEED * (float)eventArgs.Time;
            }
            if(keybIn.IsKeyDown(Keys.S))
            {
                Position -= front * SPEED * (float)eventArgs.Time;
            }
            if(keybIn.IsKeyDown(Keys.D))
            {
                Position += right * SPEED * (float)eventArgs.Time;
            }
            if(keybIn.IsKeyDown(Keys.Space))
            {
                Position += up * SPEED * (float)eventArgs.Time;
            }
            if(keybIn.IsKeyDown(Keys.LeftControl ))
            {
                Position -= up * SPEED * (float)eventArgs.Time;
            }  
        }

        public void Update(KeyboardState keybIn, MouseState mouseIn, FrameEventArgs eventArgs)
        {
            InputController(keybIn, mouseIn, eventArgs);
        }


    }
}