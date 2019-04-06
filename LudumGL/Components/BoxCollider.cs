using OpenTK;
using BEPUphysics.BroadPhaseEntries.MobileCollidables;
using BEPUphysics.CollisionShapes;
using BEPUphysics.CollisionShapes.ConvexShapes;

namespace LudumGL.Components
{
    /// <summary>
    /// Simple box collider.
    /// </summary>
    public class BoxCollider : Collider
    {
        Vector3 internalSize = Vector3.One;
        public Vector3 Size
        {
            get => internalSize;
            set
            {
                internalSize = value;
                shape = new BoxShape(value.X, value.Y, value.Z);
            }
        }

        public BoxCollider() : base()
        {
            shape = new BoxShape(Size.X, Size.Y, Size.Z);
        }
    }
}
