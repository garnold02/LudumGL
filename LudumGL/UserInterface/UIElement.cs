using System;
using OpenTK;

namespace LudumGL.UserInterface
{
    public abstract class UIElement
    {

        internal Drawable drawable;

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
        public Material Material { get => drawable.Material; set => drawable.Material = value; }

        public UIElement()
        {
            drawable = DrawableMesh.Create(Mesh.Rectangle, Shaders.Unlit);
            drawable.CameraIgnore = MatrixIgnoreMode.Translation | MatrixIgnoreMode.Rotation;

            Position = Vector2.Zero;
            Size = Vector2.One;
        }

        /// <summary>
        /// Updates this element. Runs every frame.
        /// </summary>
        public virtual void Update()
        {
            PositionAndScale();
        }

        /// <summary>
        /// Scales and positions the element appropriately.
        /// </summary>
        void PositionAndScale()
        {
            Vector2 realSize = new Vector2(Material.Texture.Width, Material.Texture.Height);

            Vector2 realPosition = Position * new Vector2(1,-1) * new Vector2(Game.window.Width, Game.window.Height);
            realPosition -= Pivot * new Vector2(Material.Texture.Width, -Material.Texture.Height);
            realPosition += new Vector2(PixelTranslation.X, -PixelTranslation.Y);
            drawable.Transform.localPosition = new Vector3((int)realPosition.X/2, (int)realPosition.Y/2, -1);

            drawable.Transform.localScale = new Vector3((int)realSize.X, (int)realSize.Y, 1);
        }
    }
}
