using OpenTK;
using BEPUphysics.BroadPhaseEntries.MobileCollidables;
using BEPUphysics.CollisionShapes;
using BEPUphysics.CollisionShapes.ConvexShapes;
using LudumGL.Scene;

namespace LudumGL.Components
{
    /// <summary>
    /// Simple box collider.
    /// </summary>
    public class BoxCollider : Collider
    {
        [SceneData]
        public Vector3 Size { get; set; } = Vector3.One;

        public BoxCollider() : base()
        {
            shape = new BoxShape(Size.X, Size.Y, Size.Z);
        }

        public override void Update()
        {
            BoxShape box = (BoxShape)shape;
            Vector3 boxSize = new Vector3(box.Width, box.Height, box.Length);
            if(boxSize!=Size*Parent.Transform.localScale)
            {
                box.Width = Size.X * Parent.Transform.localScale.X;
                box.Height = Size.Y * Parent.Transform.localScale.Y;
                box.Length = Size.Z * Parent.Transform.localScale.Z;
            }
            base.Update();
        }
    }
}
