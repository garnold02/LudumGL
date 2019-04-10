using System;
using OpenTK;

using LudumGL.Rendering;

namespace LudumGL.UserInterface
{
    /// <summary>
    /// UI element used for displaying text.
    /// </summary>
    public class UIText : UIElement
    {
        /// <summary>
        /// The string this text element will display.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The font this text element will use.
        /// </summary>
        public Font Font { get; set; }

        public Vector2 TextSize { get; private set; }

        public UIText()
        {
            DrawableText drawableText = new DrawableText();
            drawableText.AddShader(Shaders.Projection);
            drawableText.AddShader(Shaders.Unlit);
            drawableText.Finish();

            drawables.Add(drawableText);
        }

        public override void Update()
        {
            PositionAndScale(TextSize.X, TextSize.Y, false);

            DrawableText drawableText = (DrawableText)Drawable;
            drawableText.Text = Text;
            drawableText.Transform.localPosition = new Vector3(pixelPosition.X, pixelPosition.Y, -1);
            drawableText.Transform.localScale = new Vector3(Font.CharacterWidth * Size.X, Font.CharacterHeight * Size.Y, 1);
            drawableText.Material = Material;
            drawableText.Font = Font;

            TextSize = drawableText.Size;

            base.Update();
        }
    }
}
