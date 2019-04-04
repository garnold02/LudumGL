using System;
using OpenTK;

namespace LudumGL
{
    /// <summary>
    /// Represents a camera in 3D space.
    /// </summary>
    public class Camera
    {
        /// <summary>
        /// The transform of this camera.
        /// </summary>
        public Transform Transform { get; set; } = Transform.Identity;

        /// <summary>
        /// The field of view of this camera.
        /// </summary>
        public float FieldOfView { get; set; } = 60;

        /// <summary>
        /// Distance to the near clip plane of this camera.
        /// </summary>
        public float NearClip { get; set; } = 0.1f;

        /// <summary>
        /// Distance to the far clip plane of this camera.
        /// </summary>
        public float FarClip { get; set; } = 100f;

        /// <summary>
        /// Returns the projection matrix of this camera.
        /// </summary>
        public Matrix4 Projection { get => Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(FieldOfView), Game.AspectRatio, NearClip, FarClip); }
    }
}
