using System;
using OpenTK;
using a = Assimp;

namespace LudumGL
{
    /// <summary>
    /// Represents a 3D model complete with vertices, indices,
    /// normals, and uvs.
    /// </summary>
    public class Mesh
    {
        /// <summary>
        /// Import a mesh from a model file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Mesh Load(string path)
        {
            Mesh mesh = new Mesh();
            a.AssimpContext context = new a.AssimpContext();
            a.Scene scene = context.ImportFile(path, a.PostProcessSteps.Triangulate);
            a.Mesh aMesh = scene.Meshes[0];

            mesh.vertices = new Vector4[aMesh.VertexCount];
            mesh.normals = new Vector4[aMesh.VertexCount];
            mesh.uvs = new Vector4[aMesh.VertexCount];

            for (int i = 0; i < aMesh.VertexCount; i++)
            {
                a.Vector3D aVertex = aMesh.Vertices[i];
                a.Vector3D aNormal = aMesh.Normals[i];
                a.Vector3D aUv = aMesh.TextureCoordinateChannels[0][i];

                mesh.vertices[i] = new Vector4(aVertex.X, aVertex.Y, aVertex.Z, 1f);
                mesh.normals[i] = new Vector4(aNormal.X, aNormal.Y, aNormal.Z, 0f);
                mesh.uvs[i] = new Vector4(aUv.X, aUv.Y, 0f, 0f);
            }
            mesh.indices = aMesh.GetIndices();

            return mesh;
        }

        /// <summary>
        /// The vertices of this mesh.
        /// </summary>
        public Vector4[] vertices;

        /// <summary>
        /// The normals of this mesh.
        /// </summary>
        public Vector4[] normals;

        /// <summary>
        /// The UV coordinates of this mesh.
        /// </summary>
        public Vector4[] uvs;

        /// <summary>
        /// The indices of this mesh.
        /// </summary>
        public int[] indices;
    }
}
