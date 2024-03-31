using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace OpenGlTesting
{
    internal class FileLoader
    {
        public static Model LoadModelFromObj(string filename, ModelLoader loader)
        {
            string? line;
            List<Vector3> vertices = new List<Vector3>();
            List<Vector3> normals = new List<Vector3>();
            List<Vector2> textCoords = new List<Vector2>();
            List<uint> indices = new List<uint>();
            
            try
            {
                StreamReader file = new StreamReader("Resources/" + filename + ".obj");
                List<Vector3> tempNormals = new List<Vector3>();
                List<Vector2> tempTexCords = new List<Vector2>();

                line = file.ReadLine();

                while(line != null)
                {
                    string[] lineParts = line.Split(' '); // First item will be the key (i.e. v, vt, f etc), further items will be the values for that data

                    if(line.StartsWith("v ")) // v = vertex position
                    {
                        Vector3 vertix = new Vector3(float.Parse(lineParts[1]), float.Parse(lineParts[2]), float.Parse(lineParts[3]));
                        vertices.Add(vertix);
                    }
                    else if(line.StartsWith("vt ")) // vt = texture coords
                    {
                        Vector2 texCoord = new Vector2(float.Parse(lineParts[1]), float.Parse(lineParts[2]));
                        tempTexCords.Add(texCoord);
                    }
                    else if(line.StartsWith("vt ")) // vn = normals
                    {
                        Vector3 normal = new Vector3(float.Parse(lineParts[1]), float.Parse(lineParts[2]), float.Parse(lineParts[3]));
                        tempNormals.Add(normal);

                    }
                    else if(line.StartsWith("f ")) // f = face
                    {
                        /*
                        .obj files have a section for every triangle (face) in a model.
                        This section is split into 3 sets of 3 values, seperated by a forward slash (/)
                        Every set of values (i.e., 20/10/40) stores
                            - The index of the vertex position for this vertex (20th vertex position)
                            - The index for texture coordinate (10th texture coordinate)
                            - The index for the normal (40th normal)
                        By storing 3 of these sets, we represent a single triangle.
                        Indexed from 1, while lists are indexed from 0. So we have to -1 to these values for our case.
                        */
                        for(int i = 1; i <= 3; i++)
                        {
                            string[] vertexData = lineParts[i].Split("/");
                            uint vertexPos = uint.Parse(vertexData[0]) - 1;
                            int texPos = int.Parse(vertexData[1]) - 1;
                            int normalPos = int.Parse(vertexData[2]) - 1;

                            indices.Add(vertexPos);
                            textCoords.Add(tempTexCords[texPos]);
                            normals.Add(tempNormals[normalPos]);
                        }
                    }
                    line = file.ReadLine();
                }

                file.Close();
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("File not found. Please check file name exists.\n" + e);
            }
            return loader.LoadToVao(vertices, indices);
        }
    }
}