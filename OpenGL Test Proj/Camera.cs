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
        private float pitch;
        private float yaw = -90.0f;
        private bool firstMove = true;
        public Vector2 lastPos {get; set;}
        
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
            if(pitch > 89.0f)
            {
                pitch = 89.0f;
            }
            if(pitch < -89.0f)
            {
                pitch = -89.0f;
            }

            // Trigonometry :(
            front.X = MathF.Cos(MathHelper.DegreesToRadians(pitch)) * MathF.Cos(MathHelper.DegreesToRadians(yaw));
            front.Y = MathF.Sin(MathHelper.DegreesToRadians(pitch));
            front.Z = MathF.Cos(MathHelper.DegreesToRadians(pitch)) * MathF.Sin(MathHelper.DegreesToRadians(yaw));

            front = Vector3.Normalize(front);
            right = Vector3.Normalize(Vector3.Cross(front, Vector3.UnitY));
            up = Vector3.Normalize(Vector3.Cross(right, front));
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

            if(firstMove)
            {
                lastPos = new Vector2(mouseIn.X, mouseIn.Y);
                firstMove = false;
            }
            else
            {
                var deltaX = mouseIn.X - lastPos.X;
                var deltaY = mouseIn.Y - lastPos.Y;
                lastPos = new Vector2(mouseIn.X, mouseIn.Y);

                yaw += deltaX * SENSITIVITY * (float)eventArgs.Time;
                pitch -= deltaY * SENSITIVITY * (float)eventArgs.Time;
            }
            UpdateVectors();
        }

        public void Update(KeyboardState keybIn, MouseState mouseIn, FrameEventArgs eventArgs)
        {
            InputController(keybIn, mouseIn, eventArgs);
        }


    }
}