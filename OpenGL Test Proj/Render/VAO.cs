using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;

namespace OpenGlTesting
{
    internal class VAO : IDisposable
    {
        public int Id;
        public VAO()
        {
            Id = GL.GenVertexArray();
            GL.BindVertexArray(Id);
        }

        public void LinkToVao(int location, int size, VBO vbo)
        {

        }

        public void Bind()
        {
            GL.BindVertexArray(Id);
        }

        public void Unbind()
        {
            GL.BindVertexArray(0);
        }

        public void Dispose()
        {
            GL.DeleteVertexArray(Id);
        }
    }
}