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
        internal Vector2 pixelSize;
        internal Vector2 pixelPosition;
        bool isHovering;
        bool isHoveringOld;

        internal Drawable Drawable { get => drawables[0]; }

        /// <summary>
        /// Position calculations will be done relative to this element.
        /// </summary>
        public UIElement Parent { get; set; }

        /// <summary>
        /// Determines the depth of the object.
        /// </summary>
        public float Depth { get; set; }

        /// <summary>
        /// The position of this element in window coordinates.
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
        /// The size of this element.
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
                drawable.Transform.localPosition.Z = -(Depth + 10);
            }

            //Check for hover and click
            Vector2 screenPosition = new Vector2(pixelPosition.X + Game.EvenWidth / 2, Game.EvenHeight - (pixelPosition.Y + Game.EvenHeight / 2)) + (Pivot / 2) * pixelSize;

            if (Mathl.Overlap(Input.MousePosition.X, Input.MousePosition.Y, 1, 1, screenPosition.X, screenPosition.Y, pixelSize.X, pixelSize.Y)) {
                isHovering = true;
                OnHover?.Invoke(this, new EventArgs());
                if (Input.GetButtonDown(OpenTK.Input.MouseButton.Left))
                    OnClick?.Invoke(this, new EventArgs());

                if (!isHoveringOld)
                    OnMouseEnter?.Invoke(this, new EventArgs());
            }
            else
            {
                isHovering = false;
                if (isHoveringOld)
                    OnMouseLeave?.Invoke(this, new EventArgs());
            }
            isHoveringOld = isHovering;

            OnUpdate?.Invoke(this, new EventArgs());
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
        /// Executes every frame.
        /// </summary>
        public event EventHandler OnUpdate;

        /// <summary>
        /// Executes when the uses clicks on this element.
        /// </summary>
        public event EventHandler OnClick;

        /// <summary>
        /// Executes when the user hovers on this element with the mouse cursor.
        /// </summary>
        public event EventHandler OnHover;

        /// <summary>
        /// Executes on the frame when the user starts hovering on this element with the mouse cursor.
        /// </summary>
        public event EventHandler OnMouseEnter;

        /// <summary>
        /// Executes on the frame when the user stops hovering on this element with the mouse cursor.
        /// </summary>
        public event EventHandler OnMouseLeave;
    }
}
