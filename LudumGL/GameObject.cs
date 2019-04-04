using System;


namespace LudumGL
{
    /// <summary>
    /// GameObject implementation.
    /// </summary>
    class GameObject
    {
        /// <summary>
        /// The transform of this GameObject.
        /// </summary>
        public Transform transform;

        public GameObject()
        {
            transform = Transform.Identity;
        }
    }
}
