using System;
using System.Collections.Generic;
using OpenTK;
using LudumGL.Rendering;

namespace LudumGL.UserInterface
{
    /// <summary>
    /// All UI elements inherit from this class.
    /// </summary>
    public abstract class UIElement
    {

        internal List<Drawable> drawables;

        internal Drawable Drawable { get => drawables[0]; }

        internal Vector2 pixelSize;
        internal Vector2 pixelPosition;

        /// <summary>
        /// The position of this element in normalized coordinates.
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// How much the element should be displaced, in pixels instead of
        /// screen coordinates.
        /// </summary>
        public Vector2 PixelTranslation { get; set; }

        /// <summary>
        /// The pivot point of this element.
        /// </summary>
        public Vector2 Pivot { get; set; } = Vector2.Zero;

        /// <summary>
        /// The size of this element in normalized coordinates.
        /// </summary>
        public Vector2 Size { get; set; } = Vector2.One;

        /// <summary>
        /// The material of this element.
        /// </summary>
        public Material Material { get; set; } = Material.Default;

        public UIElement()
        {
            drawables = new List<Drawable>();
            Position = Vector2.Zero;
            Size = Vector2.One;
        }

        /// <summary>
        /// Updates this element. Runs every frame.
        /// </summary>
        public virtual void Update()
        {
            foreach (Drawable drawable in drawables)
            {
                drawable.Material = Material;
            }
        }

        /// <summary>
        /// Scales and positions the element appropriately.
        /// </summary>
        internal void PositionAndScale()
        {
            float pixelPositionX = Position.X * 0.5f * Game.EvenWidth - Pivot.X * 0.5f * Material.Texture.Width + PixelTranslation.X;
            float pixelPositionY = -Position.Y * 0.5f * Game.EvenHeight + Pivot.Y * 0.5f * Material.Texture.Height - PixelTranslation.Y;
            pixelPosition = new Vector2(pixelPositionX, pixelPositionY);
            pixelSize = new Vector2(Material.Texture.Width, Material.Texture.Height);
        }
    }
}
