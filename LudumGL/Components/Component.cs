using System;
using LudumGL.Scene;

namespace LudumGL.Components
{
    /// <summary>
    /// Base class for customized components that can be
    /// attached to GameObjects.
    /// </summary>
    public abstract class Component : ISceneObject
    {
        public int Id { get; set; }

        [SceneData]
        bool internalEnabled = true;

        public bool Enabled
        {
            get => internalEnabled;
            set
            {
                internalEnabled = value;
                if (internalEnabled)
                    OnEnable();
                else
                    OnDisable();
            }
        }
        /// <summary>
        /// The parent GameObject of this Component.
        /// </summary>
        [SceneData]
        public GameObject Parent { get; internal set; }

        /// <summary>
        /// Runs when the component is added to a GameObject.
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

        /// <summary>
        /// Runs once the parent GameObject becomes enabled.
        /// </summary>
        public virtual void OnParentEnable()
        {

        }

        /// <summary>
        /// Runs once the parent GameObject becomes disabled.
        /// </summary>
        public virtual void OnParentDisable()
        {

        }

        /// <summary>
        /// Runs once the component becomes enabled.
        /// </summary>
        public virtual void OnEnable()
        {

        }

        /// <summary>
        /// Runs once the component becomes disabled.
        /// </summary>
        public virtual void OnDisable()
        {

        }
    }
}
