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
        /// Position calculations will be done relative to this element.
        /// </summary>
        public UIElement Parent { get; set; }

        /// <summary>
        /// Determines the depth of the object.
        /// </summary>
        public float Depth { get; set; }

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
                drawable.Transform.localPosition.Z = -(Depth + 1);
            }

            //Check for hover and click

        }

        /// <summary>
        /// Scales and positions the element appropriately.
        /// </summary>
        internal void PositionAndScale(float elementScaleX, float elementScaleY, bool scale=true)
        {
            Vector2 parentPosition = new Vector2(0, 0);
            Vector2 parentSize = new Vector2(Game.EvenWidth, Game.EvenHeight);

            if (Parent != null)
            {
                parentPosition = Parent.pixelPosition;
                parentSize = Parent.pixelSize;
            }

            float pixelPositionX = Position.X * 0.5f * parentSize.X - Pivot.X * 0.5f * elementScaleX + PixelTranslation.X;
            float pixelPositionY = -Position.Y * 0.5f * parentSize.Y + Pivot.Y * 0.5f * elementScaleY - PixelTranslation.Y;
            pixelPosition = new Vector2(pixelPositionX + parentPosition.X, pixelPositionY + parentPosition.Y);

            if(scale)
                pixelSize = new Vector2(elementScaleX, elementScaleY);
        }

        /// <summary>
        /// Executes when the used click on this element
        /// </summary>
        public event EventHandler OnClick;

        /// <summary>
        /// Executes when the user hovers on this element with the mouse cursor.
        /// </summary>
        public event EventHandler OnHover;
    }
}
