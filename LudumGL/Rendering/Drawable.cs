using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace LudumGL.Rendering
{
    /// <summary>
    /// All drawable things inherit from this class.
    /// </summary>
    public abstract class Drawable
    {
        internal int program;
        internal List<int> shaders;
        internal Dictionary<string, int> uniforms;

        /// <summary>
        /// The material of this object.
        /// </summary>
        public Material Material { get; set; } = Material.Default;

        /// <summary>
        /// The transform of this object.
        /// </summary>
        public Transform Transform { get; set; } = Transform.Identity;

        /// <summary>
        /// Specifies which matrices of the used camera should be ignored.
        /// Useful for rendering skyboxes.
        /// </summary>
        public MatrixIgnoreMode CameraIgnore { get; set; } = MatrixIgnoreMode.None;

        public Drawable()
        {
            shaders = new List<int>();
            uniforms = new Dictionary<string, int>();

            program = GL.CreateProgram();
        }

        /// <summary>
        /// Attaches a shader to this object.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="type"></param>
        public void AddShader(Shader shader)
        {
            int glShader = GL.CreateShader(shader.Type);
            GL.ShaderSource(glShader, shader.Code);
            GL.CompileShader(glShader);
            shaders.Add(glShader);
            string log = GL.GetShaderInfoLog(glShader);
            if (log.Length > 0) Console.WriteLine("Shader: {0}", log);
        }

        /// <summary>
        /// Finalizes this object. Always call before
        /// trying to draw the object.
        /// </summary>
        public virtual void Finish()
        {
            int i = 0;
            foreach (int shader in shaders)
            {
                GL.AttachShader(program, shader);
                i++;
            }
            GL.LinkProgram(program);
            foreach (int shader in shaders)
            {
                GL.DetachShader(program, shader);
            }
            shaders.Clear();
        }

        public abstract void Render(Camera camera);

        #region UniformSetters
        /// <summary>
        /// Pass a float to the shader as a uniform property.
        /// </summary>
        /// <param name="name">Property name</param>
        /// <param name="value"></param>
        public void SetFloat(string name, float value)
        {
            if (!uniforms.ContainsKey(name))
            {
                int uniform = GL.GetUniformLocation(program, name);
                uniforms.Add(name, uniform);

            }
            int location = uniforms[name];
            GL.Uniform1(location, value);
        }

        /// <summary>
        /// Pass a 2D vector to the shader as a uniform property.
        /// </summary>
        /// <param name="name">Property name</param>
        /// <param name="value"></param>
        public void SetVector2(string name, Vector2 value)
        {
            if (!uniforms.ContainsKey(name))
            {
                int uniform = GL.GetUniformLocation(program, name);
                uniforms.Add(name, uniform);
            }
            int location = uniforms[name];
            GL.Uniform2(location, ref value);
        }

        /// <summary>
        /// Pass a 3D vector to the shader as a uniform property.
        /// </summary>
        /// <param name="name">Property name</param>
        /// <param name="value"></param>
        public void SetVector3(string name, Vector3 value)
        {
            if (!uniforms.ContainsKey(name))
            {
                int uniform = GL.GetUniformLocation(program, name);
                uniforms.Add(name, uniform);
            }
            int location = uniforms[name];
            GL.Uniform3(location, ref value);
        }

        /// <summary>
        /// Pass a 4D vector to the shader as a uniform property.
        /// </summary>
        /// <param name="name">Property name</param>
        /// <param name="value"></param>
        public void SetVector4(string name, Vector4 value)
        {
            if (!uniforms.ContainsKey(name))
            {
                int uniform = GL.GetUniformLocation(program, name);
                uniforms.Add(name, uniform);
            }
            int location = uniforms[name];
            GL.Uniform4(location, ref value);
        }

        /// <summary>
        /// Pass a 4x4 Matrix to the shader as a uniform property.
        /// </summary>
        /// <param name="name">Property name</param>
        /// <param name="value"></param>
        public void SetMatrix4(string name, Matrix4 value)
        {
            if (!uniforms.ContainsKey(name))
            {
                int uniform = GL.GetUniformLocation(program, name);
                uniforms.Add(name, uniform);
            }
            int location = uniforms[name];
            GL.UniformMatrix4(location, false, ref value);
        }
        #endregion
    }

    /// <summary>
    /// Specifies which camera matrices the renderer
    /// should ignore.
    /// </summary>
    public enum MatrixIgnoreMode
    {
        None = 0b0000,
        Translation = 0b1000,
        Rotation = 0b0100,
        Scale = 0b0010,
        Projection = 0b0001
    }
}
