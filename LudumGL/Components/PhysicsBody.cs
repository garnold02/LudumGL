using System;
using OpenTK;
using BEPUphysics.Entities;
using LudumGL.Scene;

namespace LudumGL.Components
{
    /// <summary>
    /// Rigid body implementation.
    /// </summary>
    public class PhysicsBody : Component
    {

        Collider collider;
        Entity entity;

        /// <summary>
        /// The mass of the body.
        /// </summary>
        [SceneData]
        public float Mass { get; set; } = 1;

        /// <summary>
        /// How much the object slows down over time.
        /// </summary>
        [SceneData]
        public float Drag { get; set; } = 0;

        public override void Start()
        {
            collider = Parent.GetComponent<Collider>();
            entity = new Entity(collider.shape, Mass)
            {
                Position = Physics.VectorT2B(Parent.Transform.Position),
                Orientation = Physics.QuaternionT2B(Parent.Transform.localRotation)
            };
            Physics.AddEntity(entity, this);

            base.Start();
        }
        public override void Update()
        {
            //Update propertis
            if (entity.Mass != Mass) entity.Mass = Mass;
            if (entity.LinearDamping != Drag) entity.LinearDamping = Drag;

            if(Mass>0)
            {
                //Dynamic
                Parent.Transform.localPosition = Physics.VectorB2T(entity.Position);
                Parent.Transform.localRotation = Physics.QuaternionB2T(entity.Orientation);
                entity.Gravity =  Physics.VectorT2B(Physics.Gravity);
            }
            else
            {
                //Kinematic
                BEPUutilities.Vector3 transformPosition = Physics.VectorT2B(Parent.Transform.Position);
                BEPUutilities.Quaternion transformOrientation = Physics.QuaternionT2B(Parent.Transform.Rotation);
                if (transformPosition != entity.Position)
                    entity.Position = transformPosition;
                if (transformOrientation != entity.Orientation)
                    entity.Orientation = transformOrientation;
            }
            base.Update();
        }

        /// <summary>
        /// Applies force to the PhysicsBody.
        /// </summary>
        /// <param name="force"></param>
        public void AddForce(Vector3 force)
        {
            BEPUutilities.Vector3 vec = Physics.VectorT2B(force);
            BEPUutilities.Vector3 pos = entity.Position;
            entity.ApplyImpulse(pos, vec);

        }

        /// <summary>
        /// Behaves similarly to AddForce. Use this if the force is intended
        /// to be applied constantly.
        /// </summary>
        /// <param name="force"></param>
        public void AddConstantForce(Vector3 force)
        {
            BEPUutilities.Vector3 vec = Physics.VectorT2B(force);
            BEPUutilities.Vector3 pos = entity.Position;
            entity.ApplyLinearImpulse(ref vec);

        }

        /// <summary>
        /// Applies torque to the PhysicsBody.
        /// </summary>
        /// <param name="force"></param>
        public void AddTorque(Vector3 torque)
        {
            BEPUutilities.Vector3 vec = Physics.VectorT2B(torque);
            entity.ApplyAngularImpulse(ref vec);
        }
    }
}
