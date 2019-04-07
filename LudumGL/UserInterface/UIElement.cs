using System;
using OpenTK;

namespace LudumGL.UserInterface
{
    public abstract class UIElement
    {
        /// <summary>
        /// The position of this element in normalized coordinates.
        /// </summary>
        public Vector2 Position { get => drawable.Transform.Position.Xy; set => drawable.Transform.localPosition = new Vector3(value.X, value.Y, -1); }

        /// <summary>
        /// The size of this element in normalized coordinates.
        /// </summary>
        public Vector2 Size { get => drawable.Transform.Scale.Xy / 2; set => drawable.Transform.localScale = new Vector3(value.X * 2, value.Y * 2, 1); }

        public Vector4 Color => drawable.Material.Albedo;

        internal Drawable drawable;

        public UIElement()
        {
            drawable = DrawableMesh.Create(Mesh.Rectangle, Shaders.Unlit);
            drawable.CameraIgnore = MatrixIgnoreMode.Projection;
            Position = Vector2.Zero;
        }

        /// <summary>
        /// Updates this element. Runs every frame.
        /// </summary>
        public virtual void Update()
        {

        }
    }
}
