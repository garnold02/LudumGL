using System;
using OpenTK;

namespace LudumGL
{
    /// <summary>
    /// Represents a camera in 3D space.
    /// </summary>
    public class Camera
    {
        #region Static
        /// <summary>
        /// Returns the origin camera. Its position is (0,0,0)
        /// and is facing forward (-Z).
        /// </summary>
        public static Camera Default { get; } = new Camera();
        #endregion

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


        int internalDepth = 0;
        /// <summary>
        /// Determines when objects seen by this camera will be drawn.
        /// Higher means later.
        /// </summary>
        public int Depth { get => internalDepth; set { internalDepth = value; GameObject.SortByDepth(); } }

        /// <summary>
        /// Returns the projection matrix of this camera.
        /// </summary>
        public Matrix4 Projection { get => Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(FieldOfView), Game.AspectRatio, NearClip, FarClip); }

        public Ray ForwardRay { get => new Ray() { Origin = Transform.Position, Direction = Transform.Forward }; }
    }
}
