using System;
using LudumGL;
using LudumGL.Components;
using OpenTK;
namespace TestGame
{
    class Mover : Component
    {
        public Vector3 translation = Vector3.Zero;
        public Vector3 rotation = Vector3.Zero;
        public Vector3 scale = Vector3.One;
        public Vector3 force = Vector3.Zero;
        public Vector3 torque = Vector3.Zero;
        public override void Update()
        {
            Parent.Transform.localPosition += translation;
            Parent.Transform.Rotate(rotation);
            Parent.Transform.localScale *= scale;
            Parent.GetComponent<LudumGL.Components.PhysicsBody>().AddForce(force);

            base.Update();
        }
    }
}
