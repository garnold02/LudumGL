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
                gameObject.drawable.transform = gameObject.transform;
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
                if(gameObject.drawable!=null)
                {
                    gameObject.drawable.Render(Game.mainCamera);
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
        public Transform transform=Transform.Identity;

        /// <summary>
        /// The drawable of this GameObject. Contains the shaders, texture, and mesh
        /// neccessary for drawing.
        /// </summary>
        public Drawable drawable;

        public GameObject()
        {
            components = new List<Component>();
            transform = Transform.Identity;
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
