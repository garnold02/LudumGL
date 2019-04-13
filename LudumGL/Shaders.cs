using System;
using OpenTK.Graphics.OpenGL;

namespace LudumGL
{
    /// <summary>
    /// Contains the source codes of default shaders.
    /// </summary>
    public class Shaders
    {
        /// <summary>
        /// Vertex shader. Transform vertices from world space
        /// to screen space. Must be used always.
        /// </summary>
        public static Shader Projection { get; } = new Shader("ludumgl/shader/projection.glsl", ShaderType.VertexShader);

        /// <summary>
        /// Fragment shader. Supports Phong lighting.
        /// </summary>
        public static Shader Lit { get; } = new Shader("ludumgl/shader/lit.glsl", ShaderType.FragmentShader);

        /// <summary>
        /// Simple unlit shader with variable color.
        /// </summary>
        public static Shader Unlit { get; } = new Shader("ludumgl/shader/unlit.glsl", ShaderType.FragmentShader);
    }
}
