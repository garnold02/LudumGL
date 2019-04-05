using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;

namespace LudumGL
{
    /// <summary>
    /// 2D texture.
    /// </summary>
    public class Texture
    {
        #region Static
        public static Texture LoadFromFile(string path)
        {

            Bitmap bitmap = new Bitmap(path);
            bitmap.RotateFlip(RotateFlipType.Rotate90FlipY);
            int glTex = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2DArray, glTex);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);

            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
            OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            bitmap.UnlockBits(data);

            Texture texture = new Texture()
            {
                glTexture = glTex,
                Width = bitmap.Width,
                Height = bitmap.Height
            };
            return texture;
        }
        #endregion

        /// <summary>
        /// OpenGL texture.
        /// </summary>
        internal int glTexture;

        public int Width { get; private set; }
        public int Height { get; private set; }
    }
}
