using System;
using OpenTK;
using LudumGL.Scene;
namespace LudumGL
{
    /// <summary>
    /// Material used for rendering.
    /// </summary>
    public class Material : ISceneObject
    {
        #region Static
        public static Material Default { get => new Material(); }
        #endregion

        public int Id { get; set; }

        [SceneData]
        public Texture Texture { get; set; }

        [SceneData]
        public Vector4 Albedo { get; set; } = new Vector4(1, 1, 1, 1);

        [SceneData]
        public Vector2 Tiling { get; set; } = new Vector2(1, 1);
    }
}
