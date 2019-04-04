using System;

namespace LudumGL
{
    /// <summary>
    /// Base class for customized components that can be
    /// attached to GameObjects.
    /// </summary>
    abstract class Component
    {
        /// <summary>
        /// The parent GameObject of this Component.
        /// </summary>
        public GameObject Parent { get; }

        /// <summary>
        /// Runs when the component is added to a
        /// GameObject.
        /// </summary>
        public virtual void Start()
        {

        }

        /// <summary>
        /// Runs every frame when this Component is enabled.
        /// </summary>
        public virtual void Update()
        {

        }
    }
}
