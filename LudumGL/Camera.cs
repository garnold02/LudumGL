using System;
using OpenTK;

namespace LudumGL
{
    public class Camera
    {
        public Transform Transform { get; set; } = Transform.Identity;
        public float FieldOfView { get; set; } = 60;
        public float NearClip { get; set; } = 0.1f;
        public float FarClip { get; set; } = 100f;

        public Matrix4 Projection { get => Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(FieldOfView), Game.AspectRatio, NearClip, FarClip); }
    }
}
