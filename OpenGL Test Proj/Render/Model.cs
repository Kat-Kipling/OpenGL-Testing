using OpenTK.Graphics.OpenGL;

namespace OpenGlTesting
{
    internal class Model
    {
        public VAO Vao{get;}
        public IBO Ibo{get;}
        public int VertexCount{get;}

        public Model(VAO vao, IBO ibo, int vertexCount)
        {
            Vao = vao;
            Ibo = ibo;
            VertexCount = vertexCount;
        }
    }
}