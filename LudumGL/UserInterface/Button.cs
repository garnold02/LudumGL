using System;
using OpenTK;

namespace LudumGL.UserInterface
{
    /// <summary>
    /// Button implementation.
    /// </summary>
    public class Button
    {
        /// <summary>
        /// The body component of the button.
        /// </summary>
        public ScalablePanel Body { get; set; }

        /// <summary>
        /// The text component of the button.
        /// </summary>
        public UIText Text { get; set; }

        /// <summary>
        /// The default color of the button.
        /// </summary>
        public Vector4 Color { get; set; } = Vector4.One;

        /// <summary>
        /// The color of the button when the mouse cursor is over it.
        /// </summary>
        public Vector4 HoverColor { get; set; } = new Vector4(0.8f, 0.8f, 0.8f, 1);

        /// <summary>
        /// The color of the button when it is clicked.
        /// </summary>
        public Vector4 ClickColor { get; set; } = new Vector4(0.5f, 0.5f, 0.5f, 1);

        public Button(Texture texture, Font font)
        {
            Body = new ScalablePanel()
            {
                Size = new Vector2(2.5f, 1)
            };
            Text = new UIText()
            {
                Text = "Button",
                Parent = Body,
                Position = -Vector2.One,
                PixelTranslation = Vector2.One * 8,
                Depth = -1
            };

            Body.Material.Texture = texture;
            Body.Material.Albedo = Color;
            Body.OnMouseEnter += HoverStartBehaviour;
            Body.OnMouseLeave += HoverEndBehaviour;
            Body.OnClick += ClickBehaviour;
            Body.OnClickStop += ClickStopBehaviour;

            Text.Font = font;
            Text.Material.Albedo = new Vector4(0, 0, 0, 1);

            UI.AddElement(Body);
            UI.AddElement(Text);
        }

        void HoverStartBehaviour(object sender, EventArgs e)
        {
            Body.Material.Albedo = HoverColor;
        }
        void HoverEndBehaviour(object sender, EventArgs e)
        {
            Body.Material.Albedo = Color;
        }
        void ClickBehaviour(object sender, EventArgs e)
        {
            Body.Material.Albedo = ClickColor;
        }
        void ClickStopBehaviour(object sender, EventArgs e)
        {
            Body.Material.Albedo = HoverColor;
        }
    }
}
