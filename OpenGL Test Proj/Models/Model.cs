using OpenTK.Graphics.OpenGL;

namespace OpenGlTesting
{
    internal class Model
    {
        public VAO Vao{get;}
        public IBO Ibo{get;}
        public Texture? Texture{get; set;}
        public int VertexCount{get;}

        public Model(VAO vao, IBO ibo, int vertexCount)
        {
            Vao = vao;
            Ibo = ibo;
            VertexCount = vertexCount;
        }

        public Model(VAO vao, IBO ibo, Texture texture, int vertexCount)
        {
            Vao = vao;
            Ibo = ibo;
            Texture = texture;
            VertexCount = vertexCount;
        }
    }
}