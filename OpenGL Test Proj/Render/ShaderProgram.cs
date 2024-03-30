using OpenTK.Graphics.OpenGL4;

namespace OpenGlTesting
{
    internal class ShaderProgram : IDisposable
    {
        public int Id {get;}

        public ShaderProgram(string vertexShaderPath, string fragmentShaderPath)
        {
            Id = GL.CreateProgram();

            int vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, File.ReadAllText(vertexShaderPath));
            GL.CompileShader(vertexShader);

            int fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, File.ReadAllText(fragmentShaderPath));
            GL.CompileShader(fragmentShader);

            if(!string.IsNullOrEmpty(GL.GetShaderInfoLog(vertexShader)))
            {
                throw new Exception(GL.GetShaderInfoLog(vertexShader));
            }
            else if(!string.IsNullOrEmpty(GL.GetShaderInfoLog(fragmentShader)))
            {
                throw new Exception(GL.GetShaderInfoLog(fragmentShader));
            }
            else
            {
                GL.AttachShader(Id, vertexShader);
                GL.AttachShader(Id, fragmentShader);

                GL.LinkProgram(Id);

                GL.DeleteShader(vertexShader);
                GL.DeleteShader(fragmentShader);
            }
        }

        public void Bind()
        {
            GL.UseProgram(Id);
        }

        public void Unbind()
        {
            GL.UseProgram(0);
        }

        public void Dispose()
        {
            GL.DeleteShader(Id);
        }
    }
}