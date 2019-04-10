using System;
using System.Collections.Generic;
using OpenTK;

using LudumGL.Rendering;

namespace LudumGL.UserInterface
{
    /// <summary>
    /// A simple UI panel.
    /// </summary>
    public class Panel : UIElement
    {
        public Panel() : base()
        {
            drawables.Add(DrawableMesh.Create(Mesh.Rectangle, Shaders.Unlit));
        }

        public override void Update()
        {
            PositionAndScale(Material.Texture.Width, Material.Texture.Height);

            Drawable.Transform.localPosition = new Vector3((int)pixelPosition.X, (int)pixelPosition.Y, -1);
            Drawable.Transform.localScale = new Vector3((int)pixelSize.X, (int)pixelSize.Y, 1);

            base.Update();
        }
    }
}
