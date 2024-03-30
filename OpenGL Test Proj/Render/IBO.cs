using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;

namespace OpenGlTesting
{
    internal class IBO
    {
        public int Id;
        public int IndicesCount{get;}
        
        public IBO(List<uint> data)
        {
            Id = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, Id);
            GL.BufferData(BufferTarget.ElementArrayBuffer, data.Count * sizeof(uint), data.ToArray(), BufferUsageHint.StaticDraw);
            IndicesCount = data.Count;
        }

        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, Id);
        }

        public void Unbind()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }

        public void Delete()
        {
            GL.DeleteBuffer(Id);
        }
    }
}