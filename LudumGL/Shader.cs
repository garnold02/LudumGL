using System;
using System.IO;
using OpenTK.Graphics.OpenGL;

using LudumGL.Scene;

namespace LudumGL
{
    /// <summary>
    /// Object containing a shader's source code
    /// and its type.
    /// </summary>
    public class Shader : ISceneResource
    {
        public int Id { get; set; }
        public string Path { get; private set; }

        /// <summary>
        /// The source code of this shader.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The type of this shader.
        /// </summary>
        public ShaderType Type { get; }

        /// <summary>
        /// Load a shader from source code or external
        /// file.
        /// </summary>
        /// <param name="path">The raw source or path of the file</param>
        /// <param name="raw">If enabled, the "from" parameter is handled as source code</param>
        /// <param name="type">The type of this shader</param>
        public Shader(string path, ShaderType type)
        {
            Type = type;
            Code = File.ReadAllText(path);
            Path = path;
        }
    }
}
