using System;
using System.Collections.Generic;

namespace LudumGL
{
    /// <summary>
    /// GameObject implementation.
    /// </summary>
    public class GameObject
    {
        #region Static
        internal static List<GameObject> gameObjects = new List<GameObject>();
        internal static List<GameObject> gameObjectsAdd = new List<GameObject>();
        internal static List<GameObject> gameObjectsRemove = new List<GameObject>();

        internal static void Update()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Drawable.transform = gameObject.Transform;
                gameObject.UpdateComponents();
            }

            gameObjects.AddRange(gameObjectsAdd);
            foreach (GameObject gameObject in gameObjectsRemove)
            {
                gameObjects.Remove(gameObject);
            }

            gameObjectsAdd.Clear();
            gameObjectsRemove.Clear();
        }
        internal static void Render()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                if(gameObject.Drawable!=null)
                {
                    Camera camera = Game.mainCamera;
                    if (gameObject.CameraOverride != null) camera = gameObject.CameraOverride;
                    gameObject.Drawable.Render(camera);
                }
            }
        }
        /// <summary>
        /// Adds a GameObject to the system.
        /// </summary>
        /// <param name="gameObject"></param>
        public static void Add(GameObject gameObject)
        {
            gameObjectsAdd.Add(gameObject);
        }

        /// <summary>
        /// Destroys a GameObject.
        /// </summary>
        /// <param name="gameObject"></param>
        public static void Destroy(GameObject gameObject)
        {
            gameObjectsRemove.Add(gameObject);
        }
        #endregion

        bool internalEnabled;
        readonly List<Component> components;

        /// <summary>
        /// Determines whether the GameObject is
        /// enabled or not.
        /// </summary>
        public bool Enabled
        {
            get => internalEnabled;
            set
            {
                internalEnabled = value;
                if(internalEnabled)
                {
                    foreach (Component component in components)
                    {
                        component.OnParentEnable();
                    }
                }
                else
                {
                    foreach (Component component in components)
                    {
                        component.OnParentDisable();
                    }
                }
            }
        }

        /// <summary>
        /// The transform of this GameObject.
        /// </summary>
        public Transform Transform { get; set; } = Transform.Identity;

        /// <summary>
        /// The drawable of this GameObject. Contains the shaders, texture, and mesh
        /// neccessary for drawing.
        /// </summary>
        public Drawable Drawable { get; set; }

        /// <summary>
        /// If this property is set, it will override
        /// the default camera and the GameObject will be
        /// rendered from this one instead.
        /// </summary>
        public Camera CameraOverride { get; set; }

        public GameObject()
        {
            components = new List<Component>();
            Transform = Transform.Identity;
        }

        /// <summary>
        /// Adds a Component to the GameObject and calls its
        /// start function.
        /// </summary>
        /// <param name="component"></param>
        public void AddComponent(Component component)
        {
            components.Add(component);
            component.Parent = this;
            component.Start();
        }

        /// <summary>
        /// Finds a component.
        /// </summary>
        /// <typeparam name="T">The type of the component</typeparam>
        /// <param name="num">In case of multiple components, use this to
        /// determine which component to return</param>
        /// <returns></returns>
        public T GetComponent<T>(int num=0)
        {
            foreach (Component component in components)
            {
                object comp = component;
                if (comp is T)
                    return (T)comp;
            }

            return default(T);
        }

        /// <summary>
        /// Updates all components of this GameObject.
        /// </summary>
        internal void UpdateComponents()
        {
            foreach (Component component in components)
            {
                if (component.Enabled)
                    component.Update();
            }
        }
    }
}
