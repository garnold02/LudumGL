using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

using LudumGL.Scene;

namespace LevelEditor
{
    class EditorComponent
    {
        public Type realType;
        public Dictionary<string, string> properties;

        public EditorComponent(Type realType)
        {
            this.realType = realType;
            properties = new Dictionary<string, string>();
        }

        public List<string> GetAllPropertyNames()
        {
            List<string> results = new List<string>();
            FieldInfo[] fields = realType.GetFields().Where(field => field.IsDefined(typeof(SceneData))).ToArray();
            PropertyInfo[] properties = realType.GetProperties().Where(field => field.IsDefined(typeof(SceneData))).ToArray();

            foreach (FieldInfo info in fields)
            {
                results.Add(info.Name);
            }
            foreach (PropertyInfo info in properties)
            {
                results.Add(info.Name);
            }

            return results;
        }
    }
}
