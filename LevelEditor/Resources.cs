using System;
using LudumGL;

namespace LevelEditor
{
    class Resources
    {
        #region Definitions
        public static Mesh mesh_origin;
        public static Texture texture_origin;
        #endregion
        public static void Initialize()
        {
            mesh_origin = Mesh.Load("assets/mdl/origin.dae");

            texture_origin = Texture.LoadFromFile("assets/tex/origin.png");
        }
    }
}
