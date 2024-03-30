using OpenTK.Graphics.OpenGL4;

namespace OpenGlTesting
{
    internal class Renderer
    {
        public void RenderModel(Model model)
        {
            model.Vao.Bind();
            model.Ibo.Bind();

            GL.DrawElements(PrimitiveType.Triangles, model.Ibo.IndicesCount, DrawElementsType.UnsignedInt, 0);

            model.Vao.Unbind();
            model.Ibo.Unbind();
        }
    }
}