using System;
using System.IO;
using OpenTK.Graphics.OpenGL;

namespace LudumGL
{
    /// <summary>
    /// Object containing a shader's source code
    /// and its type.
    /// </summary>
    public class Shader
    {
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
        /// <param name="from">The raw source or path of the file</param>
        /// <param name="raw">If enabled, the "from" parameter is handled as source code</param>
        /// <param name="type">The type of this shader</param>
        public Shader(string from, bool raw, ShaderType type)
        {
            Type = type;
            if(raw)
            {
                Code = from;
            }
            else
            {
                Code = File.ReadAllText(from);
            }
        }
    }
}
