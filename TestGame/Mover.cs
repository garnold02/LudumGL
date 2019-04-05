using System;
using LudumGL;
using OpenTK;
namespace TestGame
{
    class Mover : Component
    {
        public Vector3 translation = new Vector3(0, 0, 0);
        public Vector3 rotation = new Vector3(0, 0, 0);
        public override void Update()
        {
            Parent.Transform.localPosition += translation;
            Parent.Transform.Rotate(rotation);

            base.Update();
        }
    }
}
