using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;
using System.Linq;
using LudumGL;
using LudumGL.Components;

namespace LevelEditor
{
    static class Program
    {
        public static List<GameObject> sceneObjects;

        public static List<Type> componentTypes;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Initialize();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Thread sceneViewThread = new Thread(new ThreadStart(SceneViewThread));
            sceneViewThread.Start();

            Game.gameLoop = new SceneViewLoop();
            Game.initialSettigns = new InitialSettings() { Title = "Scene viewer", Width = 640, Height = 480 };
            Application.Run(new ObjectList());
        }

        static void SceneViewThread()
        {
            Game.Start();
            Environment.Exit(Environment.ExitCode);
        }

        static void Initialize()
        {
            sceneObjects = new List<GameObject>();
            componentTypes = new List<Type>();

            Assembly mainAssembly = typeof(Program).Assembly;
            AssemblyName[] assemblies = mainAssembly.GetReferencedAssemblies();
            foreach (AssemblyName name in assemblies)
            {
                Assembly assembly = Assembly.Load(name);
                Type[] types = assembly.GetTypes();
                Type[] components = types.Where(type => type.IsSubclassOf(typeof(Component))).ToArray();
                componentTypes.AddRange(components);
            }
        }

        public static void AddObject(GameObject gameObject)
        {
            sceneObjects.Add(gameObject);
            SceneObjectListChanged?.Invoke(gameObject, new EventArgs());
            ObjectAdded?.Invoke(gameObject, new EventArgs());
        }

        public static void RemoveObject(GameObject gameObject)
        {
            sceneObjects.Remove(gameObject);
            SceneObjectListChanged?.Invoke(gameObject, new EventArgs());
            ObjectRemoved?.Invoke(gameObject, new EventArgs());
        }

        public static event EventHandler SceneObjectListChanged;
        public static event EventHandler ObjectAdded;
        public static event EventHandler ObjectRemoved;
    }
}
