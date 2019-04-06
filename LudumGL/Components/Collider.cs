using System;
using BEPUphysics.BroadPhaseEntries.MobileCollidables;
using BEPUphysics.CollisionShapes;
using BEPUphysics.CollisionShapes.ConvexShapes;

namespace LudumGL.Components
{
    /// <summary>
    /// Base class for all types of colliders.
    /// </summary>
    public abstract class Collider : Component
    {
        internal EntityShape shape;
        public Collider()
        {

        }
    }
}
