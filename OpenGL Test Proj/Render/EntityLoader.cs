using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace OpenGlTesting
{
    internal class EntityLoader : IDisposable
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