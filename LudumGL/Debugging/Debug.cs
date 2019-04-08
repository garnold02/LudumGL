using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudumGL.Debugging
{
    public class Debug
    {
        static List<IDebugObject> debugObjects=new List<IDebugObject>();
        static List<IDebugObject> debugObjectsAdd=new List<IDebugObject>();
        static List<IDebugObject> debugObjectsRemove=new List<IDebugObject>();

        internal static void Update()
        {
            if (!Enabled) return;
            foreach (IDebugObject debugObject in debugObjects)
            {
                debugObject.Update();
            }

            debugObjects.AddRange(debugObjectsAdd);
            foreach (IDebugObject debugObject in debugObjectsRemove)
            {
                debugObjects.Remove(debugObject);
            }

            debugObjectsAdd.Clear();
            debugObjectsRemove.Clear();
        }

        internal static void Render()
        {
            if (!Enabled) return;
            foreach (IDebugObject debugObject in debugObjects)
            {
                debugObject.Render();
            }
        }

        /// <summary>
        /// If set to false, the engine will ignore every debug tool.
        /// </summary>
        public static bool Enabled { get; set; }

        /// <summary>
        /// Adds a debug object to the system.
        /// </summary>
        /// <param name="obj"></param>
        public static void AddDebugObject(IDebugObject obj)
        {
            if (!Enabled) return;
            debugObjectsAdd.Add(obj);
        }

        /// <summary>
        /// Removes a debug object from the system.
        /// </summary>
        /// <param name="obj"></param>
        public static void RemoveDebugObject(IDebugObject obj)
        {
            if (!Enabled) return;
            debugObjectsRemove.Add(obj);
        }
    }
}
