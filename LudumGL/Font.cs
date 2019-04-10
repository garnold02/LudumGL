using OpenTK;
using System;

namespace LudumGL
{
    /// <summary>
    /// Class representing an ASCII bitmap font.
    /// </summary>
    public class Font
    {
        #region Static
        /// <summary>
        /// Loads a font from a bitmap file.
        /// </summary>
        /// <param name="path">The path of the bitmap</param>
        /// <param name="charactersHorizontal">Specifies how many characters wide the bitmap is horizontally</param>
        /// <param name="charactersVertical">Specifies how many characters wide the bitmap is vertically</param>
        /// <returns></returns>
        public static Font Load(string path, int charactersHorizontal, int charactersVertical, TextureFilteringMode textureFiltering = TextureFilteringMode.Nearest)
        {
            Font font = new Font()
            {
                Bitmap = Texture.LoadFromFile(path, textureFiltering),
                SizeInCharacters = new Vector2(charactersHorizontal, charactersVertical)
            };

            return font;
        }
        #endregion

        /// <summary>
        /// The source of this font.
        /// </summary>
        public Texture Bitmap { get; set; }

        /// <summary>
        /// Returns the size of the font bitmap in characters.
        /// </summary>
        public Vector2 SizeInCharacters { get; internal set; }

        /// <summary>
        /// Gets the width of one character.
        /// </summary>
        public int CharacterWidth { get => (int)(Bitmap.Width / SizeInCharacters.X); }

        /// <summary>
        /// Gets the height of one character.
        /// </summary>
        public int CharacterHeight { get => (int)(Bitmap.Height / SizeInCharacters.Y); }

        public Vector4 GetCharacterBox(char character)
        {
            character -= ' ';

            int x = character % (int)SizeInCharacters.X;
            int y = (int)(SizeInCharacters.Y - 1) - ((character - x) / (int)SizeInCharacters.X);

            return new Vector4(x / SizeInCharacters.X, y / SizeInCharacters.Y, CharacterWidth / (float)Bitmap.Width, CharacterHeight / (float)Bitmap.Height);
        }
    }
}
