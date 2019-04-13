using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;

using LudumGL.Components;
using LudumGL.Rendering;
using System.Collections;

namespace LudumGL.Scene
{
    /// <summary>
    /// Class for loading scenes.
    /// </summary>
    public class SceneManager
    {
        static List<ISceneResource> sceneResources;
        static List<ISceneObject> sceneObjects;

        /// <summary>
        /// Saves all scene object to a scene file.
        /// </summary>
        public static void Save(string path)
        {
            Collect();

            string result = "";

            //Serialize resources
            foreach (ISceneResource sceneResource in sceneResources)
            {
                string serialized = SerializeResource(sceneResource);
                result += serialized;
            }

            //Serialize objects
            foreach (ISceneObject sceneObject in sceneObjects)
            {
                string serialized = SerializeObject(sceneObject);
                result += serialized;
            }
            File.WriteAllText(path, result);
        }

        /// <summary>
        /// Loads a scene file.
        /// </summary>
        /// <param name="path"></param>
        public static void Load(string path)
        {
            sceneResources = new List<ISceneResource>();
            sceneObjects = new List<ISceneObject>();

            string[] raw = File.ReadAllLines(path);

            string[] res = raw.Where(line => line[0] == 'r').ToArray();
            string[] objs = raw.Where(line => line[0] == 'o').ToArray();

            for (int i = 0; i < res.Length; i++)
            {
                string[] tokens = res[i].Split(' ');

                Type resType = Type.GetType(tokens[2]);

                if (resType == typeof(Mesh))
                {
                    Mesh mesh = Mesh.Load(tokens[3]);
                    sceneResources.Add(mesh);
                }
                else
                if (resType == typeof(Texture))
                {
                    Texture texture = Texture.LoadFromFile(tokens[3], (TextureFilteringMode)Enum.Parse(typeof(TextureFilteringMode), tokens[4]));
                    sceneResources.Add(texture);
                }
                else
                if (resType == typeof(Shader))
                {
                    Shader shader = new Shader(tokens[3], (ShaderType)Enum.Parse(typeof(ShaderType), tokens[4]));
                    sceneResources.Add(shader);
                }
            }

            for (int i = 0; i < objs.Length; i++)
            {
                string[] tokens = objs[i].Split(' ');

                Type objType = Type.GetType(tokens[2]);
                object obj = Activator.CreateInstance(objType);
                sceneObjects.Add((ISceneObject)obj);
            }

            //Interpret file
            ISceneObject currentSceneObject = null;
            for (int i = 0; i < raw.Length; i++)
            {
                string[] tokens = raw[i].Split(' ');

                switch (tokens[0])
                {
                    default:
                        break;

                    //Set object
                    case "o":
                        {
                            int id = int.Parse(tokens[1]);
                            currentSceneObject = sceneObjects[id];
                        }
                        break;

                    //Set field
                    case "f":
                        {
                            if (tokens[1] != "e")
                            {
                                FieldInfo field = currentSceneObject.GetType().GetField(tokens[1], BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                                object value = GetFieldOrPropertyValue(tokens);
                                field.SetValue(currentSceneObject, value);
                            }
                            else
                            {
                                FieldInfo field = currentSceneObject.GetType().GetField(tokens[2], BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                                IList list = (IList)field.GetValue(currentSceneObject);
                                object value = GetFieldOrPropertyValue(tokens, true);
                                list.Add(value);
                                field.SetValue(currentSceneObject, list);
                            }
                        }
                        break;

                    //Set property
                    case "p":
                        {
                            if (tokens[1] != "e")
                            {
                                PropertyInfo property = currentSceneObject.GetType().GetProperty(tokens[1], BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                                object value = GetFieldOrPropertyValue(tokens);
                                property.SetValue(currentSceneObject, value);
                            }
                            else
                            {
                                PropertyInfo property = currentSceneObject.GetType().GetProperty(tokens[2], BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                                IList list = (IList)property.GetValue(currentSceneObject);
                                object value = GetFieldOrPropertyValue(tokens, true);
                                list.Add(value);
                                property.SetValue(currentSceneObject, list);
                            }
                        }
                        break;
                }
            }

            //Finalize
            foreach (ISceneObject obj in sceneObjects)
            {
                if (obj is GameObject gameObject)
                {
                    foreach (Component component in gameObject.components)
                    {
                        component.Start();
                    }
                    GameObject.Add(gameObject);
                }
                if(obj is Drawable drawable)
                {
                    foreach (Shader shader in drawable.usedShaders)
                    {
                        drawable.AddShaderAfterLoad(shader);
                    }
                    drawable.Finish();
                }
            }
            

            object GetFieldOrPropertyValue(string[] tokens, bool element = false)
            {
                object value = null;
                int idAdd = 0;
                if (element) idAdd = 1;
                switch (tokens[2 + idAdd][0])
                {
                    default:
                        {
                            value = ScenePropertyConverter.FromSceneProperty(tokens[2 + idAdd]);
                        }
                        break;
                    case 'o':
                        {
                            int id = int.Parse(tokens[2 + idAdd].Substring(1));
                            value = sceneObjects[id];
                        }
                        break;
                    case 'r':
                        {
                            int id = int.Parse(tokens[2 + idAdd].Substring(1));
                            value = sceneResources[id];
                        }
                        break;
                }
                return value;
            }
        }
        static ISceneResource GetResource(string idString)
        {
            int id = int.Parse(idString.Substring(1));
            return sceneResources[id];
        }

        /// <summary>
        /// Collects all relevant objects and resources from the scene.
        /// </summary>
        static void Collect()
        {
            sceneResources = new List<ISceneResource>();
            sceneObjects = new List<ISceneObject>();

            foreach (GameObject gameObject in GameObject.gameObjects)
            {
                sceneObjects.Add(gameObject);
                AddAllObjectsAndResources(gameObject);
            }
            //Remove duplicates
            sceneResources = sceneResources.Distinct().ToList();
            sceneObjects = sceneObjects.Distinct().ToList();

            //Set IDs
            for (int i = 0; i < sceneResources.Count; i++)
            {
                sceneResources[i].Id = i;
            }
            for (int i = 0; i < sceneObjects.Count; i++)
            {
                sceneObjects[i].Id = i;
            }
        }

        /// <summary>
        /// Serializes a scene object.
        /// </summary>
        /// <param name="obj"></param>
        public static string SerializeObject(ISceneObject obj)
        {
            string result = "";
            Type objType = obj.GetType();

            result += "o " + obj.Id + " " + objType.FullName + "\n";

            FieldInfo[] fields = objType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Where(f => f.IsDefined(typeof(SceneData), false)).ToArray();
            PropertyInfo[] properties = objType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Where(p => p.IsDefined(typeof(SceneData), false)).ToArray();
            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType.IsGenericType)
                {
                    IList list = (IList)property.GetValue(obj);
                    foreach (object item in list)
                    {
                        result += "p e " + property.Name + " " + ToString(item) + "\n";
                    }
                    continue;
                }
                result += "p " + property.Name + " " + ToString(property.GetValue(obj)) + "\n";
            }
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType.IsGenericType)
                {
                    IList list = (IList)field.GetValue(obj);
                    foreach (object item in list)
                    {
                        result += "f e " + field.Name + " " + ToString(item) + "\n";
                    }
                    continue;
                }
                result += "f " + field.Name + " " + ToString(field.GetValue(obj)) + "\n";
            }

            return result;
        }

        /// <summary>
        /// Serializes a scene resource.
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public static string SerializeResource(ISceneResource resource)
        {
            string result = "r " + resource.Id + " " + resource.GetType().FullName + " " + resource.Path;
            string parameters = "";
            if (resource is Texture texture)
            {
                parameters += texture.Filtering.ToString();
            }
            else
            if (resource is Shader shader)
            {
                parameters += shader.Type.ToString();
            }

            return result + " " + parameters + "\n";
        }

        /// <summary>
        /// Returns the string representation of an object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        static string ToString(object obj)
        {
            if (obj == null) return "null";
            Type type = obj.GetType();

            if (obj is float f)
                return ScenePropertyConverter.ToSceneProperty(f);
            if (obj is bool b)
                return ScenePropertyConverter.ToSceneProperty(b);
            if (obj is Vector2 vec2)
                return ScenePropertyConverter.ToSceneProperty(vec2);
            if (obj is Vector3 vec3)
                return ScenePropertyConverter.ToSceneProperty(vec3);
            if (obj is Vector4 vec4)
                return ScenePropertyConverter.ToSceneProperty(vec4);
            if (obj is Quaternion quaternion)
                return ScenePropertyConverter.ToSceneProperty(quaternion);
            if (obj is Matrix4 matrix)
                return ScenePropertyConverter.ToSceneProperty(matrix);

            if (obj is ISceneObject sceneObject)
                return "o" + sceneObject.Id;
            if (obj is ISceneResource sceneResource)
                return "r" + sceneResource.Id;

            return obj.ToString();
        }

        static List<ISceneObject> alreadyDefinedObjects = new List<ISceneObject>();
        /// <summary>
        /// Finds all scene objects and resources in the root object recursively.
        /// </summary>
        /// <param name="root"></param>
        static void AddAllObjectsAndResources(ISceneObject root)
        {
            if (alreadyDefinedObjects.Contains(root)) return;
            alreadyDefinedObjects.Add(root);
            Type type = root.GetType();
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Where(field => field.IsDefined(typeof(SceneData), false)).ToArray();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Where(property => property.IsDefined(typeof(SceneData), false)).ToArray();

            //Search all fields
            foreach (FieldInfo info in fields)
            {
                object value = info.GetValue(root);
                AddObjectFromInfo(value);
            }

            //Search all properties
            foreach (PropertyInfo info in properties)
            {
                object value = info.GetValue(root);
                AddObjectFromInfo(value);
            }

            void AddObjectFromInfo(object value)
            {
                //If the value is a scene object
                if (value is ISceneObject sceneObject)
                {
                    sceneObjects.Add(sceneObject);
                    AddAllObjectsAndResources(sceneObject);
                }
                else

                //If the value is a list of scene objects
                if (value is IEnumerable<ISceneObject> objectList)
                {
                    foreach (ISceneObject so in objectList)
                    {
                        sceneObjects.Add(so);
                        AddAllObjectsAndResources(so);
                    }
                }
                else

                //If the value is a scene resource
                if (value is ISceneResource resource)
                {
                    sceneResources.Add(resource);
                }
                else

                //If the value is list of scene resources
                if (value is IEnumerable<ISceneResource> resourceList)
                {
                    foreach (ISceneResource sr in resourceList)
                    {
                        sceneResources.Add(sr);
                    }
                }
            }
        }
    }
}
