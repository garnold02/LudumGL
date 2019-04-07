using System;
using OpenTK;
namespace LudumGL
{
    /// <summary>
    /// Material used for rendering.
    /// </summary>
    public class Material
    {
        #region Static
        public static Material Default { get => new Material(); }
        #endregion

        public Texture Texture { get; set; }
        public Vector4 Albedo { get; set; } = new Vector4(1, 1, 1, 1);
        public Vector2 Tiling { get; set; } = new Vector2(1, 1);
    }
}
