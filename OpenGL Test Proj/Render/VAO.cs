using OpenTK.Graphics.OpenGL4;

namespace OpenGlTesting
{
    internal class VAO : IDisposable
    {
        public int Id;
        public int VertexCount{get;}
        public VAO()
        {
            Id = GL.GenVertexArray();
            GL.BindVertexArray(Id);
        }

        public void LinkVbo(int location, int size, VBO vbo)
        {
            Bind();
            vbo.Bind();
            GL.VertexAttribPointer(location, size, VertexAttribPointerType.Float, false, 0, 0);
            GL.EnableVertexAttribArray(location);
            Unbind();
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