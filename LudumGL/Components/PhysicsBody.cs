using System;
using OpenTK;
using BEPUphysics.Entities;

namespace LudumGL.Components
{
    /// <summary>
    /// Rigid body implementation.
    /// </summary>
    public class PhysicsBody : Component
    {

        Collider collider;
        Entity entity;

        float internalMass = 1;
        /// <summary>
        /// The mass of the body.
        /// </summary>
        public float Mass { get => internalMass; set { internalMass = value; if (entity != null) entity.Mass = internalMass; } }

        public override void Start()
        {
            collider = Parent.GetComponent<Collider>();
            entity = new Entity(collider.shape, Mass)
            {
                Position = Physics.VectorT2B(Parent.Transform.Position),
                Orientation = Physics.QuaternionT2B(Parent.Transform.localRotation)
            };
            Physics.space.Add(entity);

            base.Start();
        }
        public override void Update()
        {
            Parent.Transform.localPosition = Physics.VectorB2T(entity.Position);
            Parent.Transform.localRotation = Physics.QuaternionB2T(entity.Orientation);
            base.Update();
        }

        public void AddForce(Vector3 force)
        {
            BEPUutilities.Vector3 vec = Physics.VectorT2B(force);
            entity.ApplyLinearImpulse(ref vec);
        }
    }
}
