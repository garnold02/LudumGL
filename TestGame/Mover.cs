using System;
using LudumGL;
using OpenTK;
namespace TestGame
{
    class Mover : Component
    {
        public Vector3 translation = Vector3.Zero;
        public Vector3 rotation = Vector3.Zero;
        public Vector3 force = Vector3.Zero;
        public override void Update()
        {
            Parent.Transform.localPosition += translation;
            Parent.Transform.Rotate(rotation);
            Parent.GetComponent<LudumGL.Components.PhysicsBody>().AddForce(force);

            base.Update();
        }
    }
}
