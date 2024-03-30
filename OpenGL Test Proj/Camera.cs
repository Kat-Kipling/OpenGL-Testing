using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace OpenGlTesting
{
    internal class Camera
    {
        public Camera()
        {
            
        }

        public Matrix4 GetProjectionMatrix()
        {

        }

        private void UpdateVectors()
        {

        }

        public void InputController(KeyboardState keybIn, MouseState mouseIn, FrameEventArgs eventArgs)
        {

        }

        public void Update(KeyboardState keybIn, MouseState mouseIn, FrameEventArgs eventArgs)
        {
            InputController(keybIn, mouseIn, eventArgs);
        }


    }
}