using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;

using LudumGL.Scene;

namespace LudumGL
{
    /// <summary>
    /// 2D texture.
    /// </summary>
    public class Texture : ISceneResource
    {
        #region Static
        public static Texture LoadFromFile(string path, TextureFilteringMode filteringMode = TextureFilteringMode.Nearest)
        {
            Bitmap bitmap = new Bitmap(path);

            Texture texture = new Texture()
            {
                Width = bitmap.Width,
                Height = bitmap.Height,
                Path = path,
                Filtering = filteringMode
            };
            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            bitmap.UnlockBits(data);

            texture.glTexture = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, texture.glTexture);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)filteringMode);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)filteringMode);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmap.Width, bitmap.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            GL.BindTexture(TextureTarget.Texture2D, 0);
            return texture;
        }
        #endregion

        public int Id { get; set; }
        public string Path { get; private set; }

        /// <summary>
        /// OpenGL texture.
        /// </summary>
        internal int glTexture;

        public int Width { get; private set; }
        public int Height { get; private set; }
        public TextureFilteringMode Filtering { get; private set; }
    }

    public enum TextureFilteringMode
    {
        Nearest = 9728,
        Linear = 9729,
    }
}
