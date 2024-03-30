using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;

namespace OpenGlTesting
{
    internal class VBO
    {
        public int Id;
        
        public VBO(List<Vector3> vertData)
        {
            Id = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, Id);
            GL.BufferData(BufferTarget.ArrayBuffer, vertData.Count * Vector3.SizeInBytes, vertData.ToArray(), BufferUsageHint.StaticDraw);
        }

        public VBO(List<Vector2> texData)
        {
            Id = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, Id);
            GL.BufferData(BufferTarget.ArrayBuffer, texData.Count * Vector2.SizeInBytes, texData.ToArray(), BufferUsageHint.StaticDraw);
        }
        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, Id);
        }

        public void Unbind()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }    

        public void Delete()    
        {
            GL.DeleteBuffer(Id);
        }

    }
}