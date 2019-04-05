using System;
using System.IO;
using System.Collections.Generic;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace LudumGL
{
    /// <summary>
    /// Represents an object that can be drawn using
    /// LudumGL's renderer.
    /// </summary>
    public class Drawable
    {
        #region Static
        public static Drawable MakeDrawable(Mesh mesh, params Shader[] shaders)
        {
            Drawable drawable = new Drawable
            {
                mesh = mesh
            };

            drawable.AddShader(Shaders.Projection);
            foreach (Shader shader in shaders)
            {
                drawable.AddShader(shader);
            }

            drawable.Finish();
            return drawable;
        }
        #endregion
        readonly int program;
        List<int> shaders;
        Dictionary<string, int> uniforms;

        /// <summary>
        /// The mesh data that will be drawn
        /// using this object.
        /// </summary>
        public Mesh mesh;

        /// <summary>
        /// The texture of this object. Null means
        /// no texture.
        /// </summary>
        public Texture texture;

        /// <summary>
        /// The transform of this object.
        /// </summary>
        public Transform transform;

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
        public void Finish()
        {
            int i = 0;
            foreach (int shader in shaders)
            {
                GL.AttachShader(program, shader);
                string log = GL.GetShaderInfoLog(shader);
                if (log.Length > 0) Console.WriteLine("Shader{0}: {1}", i, log);
                i++;
            }
            GL.LinkProgram(program);
            foreach (int shader in shaders)
            {
                GL.DetachShader(program, shader);
            }
            shaders.Clear();
            mesh.Refresh();
        }

        /// <summary>
        /// Renders this object from the view of the
        /// specified camera.
        /// </summary>
        /// <param name="camera"></param>
        public void Render(Camera camera)
        {
            if (mesh == null) return;

            GL.BindBuffer(BufferTarget.ArrayBuffer, mesh.vertexBuffer);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 4, VertexAttribPointerType.Float, false, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, mesh.normalBuffer);
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 4, VertexAttribPointerType.Float, false, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, mesh.uvBuffer);
            GL.EnableVertexAttribArray(2);
            GL.VertexAttribPointer(2, 4, VertexAttribPointerType.Float, false, 0, 0);

            GL.UseProgram(program);
            SetMatrix4("translation", transform.TranslationMatrix);
            SetMatrix4("rotation", transform.RotationMatrix);
            SetMatrix4("scale", transform.ScaleMatrix);
            SetMatrix4("projection", (Matrix4.Invert(camera.Transform.TranslationMatrix) * camera.Transform.RotationMatrix) * camera.Projection);
            SetVector3("ambient", Game.AmbientLightColor);
            //Set light data
            for (int i = 0; i < Game.activeLights.Length; i++)
            {
                Light light = Game.activeLights[i];
                if (light == null) continue;
                string name = "lights[" + i + "].";
                SetFloat(name + "enabled", light.enabled ? 1 : 0);
                SetFloat(name + "type", (int)light.type);
                SetMatrix4(name + "translation", light.Translation);
                SetMatrix4(name + "rotation", light.Rotation);
                SetVector4(name + "color", light.color);
                SetFloat(name + "range", light.range);
            }

            //Set texture
            if (texture != null)
                GL.BindTexture(TextureTarget.Texture2D, texture.glTexture);

            GL.DrawElements(PrimitiveType.Triangles, mesh.vertices.Length, DrawElementsType.UnsignedInt, mesh.indices);
        }

        #region UniformSetters
        /// <summary>
        /// Pass a float to the shader as an uniform property.
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
        /// Pass a 2D vector to the shader as an uniform property.
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
        /// Pass a 3D vector to the shader as an uniform property.
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
        /// Pass a 4D vector to the shader as an uniform property.
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
        /// Pass a 4x4 Matrix to the shader as an uniform property.
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
}
