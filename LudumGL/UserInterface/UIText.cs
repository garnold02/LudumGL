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
        /// The string this Text element will display.
        /// </summary>
        public string Text { get; set; }

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
            PositionAndScale();

            DrawableText drawableText = (DrawableText)Drawable;
            drawableText.Text = Text;
            drawableText.Transform.localPosition = new Vector3(0, 0, -1);
            drawableText.Transform.localScale = new Vector3(pixelSize.X, pixelSize.Y, 1);
            drawableText.Material = Material;

            base.Update();
        }
    }
}
