using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace OpenGlTesting
{
    internal class ModelLoader : IDisposable
    {
        private List<VAO> allVaos = new List<VAO>();
        private List<VBO> allVbos = new List<VBO>();
        private List<IBO> allIbos = new List<IBO>();


        public Model LoadToVao(List<Vector3> vertexPositions, List<uint> indices)
        {
            VAO Vao = new VAO();
            VBO VertexData = new VBO(vertexPositions);

            Vao.LinkVbo(0, 3, VertexData);  // Position 0 is vertex data; size of 3 as there is X, Y and Z coordinates.

            IBO Ibo = new IBO(indices);

            allVaos.Add(Vao);
            allVbos.Add(VertexData);
            allIbos.Add(Ibo);

            return new Model(Vao, Ibo, vertexPositions.Count / 3);
        }

        public Model LoadToVao(List<Vector3> vertexPositions, List<uint> indices, List<Vector2> uv, string filename)
        {
            VAO Vao = new VAO();
            
            VBO VertexData = new VBO(vertexPositions);
            VBO uvCoords = new VBO(uv);

            Vao.LinkVbo(0, 3, VertexData);  // Position 0 is vertex data; size of 3 as there is X, Y and Z coordinates.
            Vao.LinkVbo(1, 2, uvCoords);  // Position 1 is texture data; size of 2 as there is U and V coordinates.

            IBO Ibo = new IBO(indices);

            Texture texture = new Texture(filename);

            allVaos.Add(Vao);
            allVbos.Add(VertexData);
            allIbos.Add(Ibo);

            return new Model(Vao, Ibo, texture, vertexPositions.Count / 3);
        }

        public void Dispose()
        {
            foreach(VBO vbo in allVbos)
            {
                vbo.Dispose();
            }

            foreach(VAO vao in allVaos)
            {
                vao.Dispose();
            }

            foreach(IBO ibo in allIbos)
            {
                ibo.Delete();
            }
        }
    }
}