using System;
using OpenTK;

namespace LudumGL
{
    /// <summary>
    /// Ray used for raycasting.
    /// </summary>
    public class Ray
    {
        /// <summary>
        /// The origin of this ray.
        /// </summary>
        public Vector3 Origin { get; set; } = Vector3.Zero;

        /// <summary>
        /// The direction of this ray.
        /// </summary>
        public Vector3 Direction { get; set; } = new Vector3(0, 0, 1);

        /// <summary>
        /// The length of this ray.
        /// </summary>
        public float Length { get; set; } = float.PositiveInfinity;
    }
}
