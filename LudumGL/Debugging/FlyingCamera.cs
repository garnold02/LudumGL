using System;
using OpenTK;
using OpenTK.Input;

namespace LudumGL.Debugging
{
    public class FlyingCamera : IDebugObject
    {
        public Camera Camera { get; } = new Camera() { FarClip=1000f};
        public float Speed { get; set; } = 0.5f;

        public float RotationSpeed { get; set; } = 2f;

        public FlyingCamera()
        {

        }

        public FlyingCamera(Vector3 position)
        {
            Camera.Transform.localPosition = position;
        }

        public FlyingCamera(float x, float y, float z)
        {
            Camera.Transform.localPosition = new Vector3(x, y, z);
        }

        public void Update()
        {
            if (Input.GetKey(Key.W))
            {
                Camera.Transform.localPosition += Game.mainCamera.Transform.Forward * Speed;
            }
            if (Input.GetKey(Key.S))
            {
                Camera.Transform.localPosition -= Game.mainCamera.Transform.Forward * Speed;
            }
            if (Input.GetKey(Key.A))
            {
                Camera.Transform.localPosition -= Game.mainCamera.Transform.Right * Speed;
            }
            if (Input.GetKey(Key.D))
            {
                Camera.Transform.localPosition += Game.mainCamera.Transform.Right * Speed;
            }
            if (Input.GetKey(Key.Q))
            {
                Camera.Transform.Rotate(0, 0, -RotationSpeed);
            }
            if (Input.GetKey(Key.E))
            {
                Camera.Transform.Rotate(0, 0, RotationSpeed);
            }
            Camera.Transform.Rotate(-Input.MouseDelta.Y, -Input.MouseDelta.X, 0);
        }

        public void Render()
        {

        }
    }
}
