using System;
using System.IO;
using System.Collections.Generic;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace LudumGL.Rendering
{
    /// <summary>
    /// Represents a mesh that can be drawn using
    /// LudumGL's renderer.
    /// </summary>
    public class DrawableMesh : Drawable
    {
        #region Static
        public static DrawableMesh Create(Mesh mesh, params Shader[] shaders)
        {
            DrawableMesh drawable = new DrawableMesh
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


        /// <summary>
        /// The mesh data that will be drawn
        /// using this object.
        /// </summary>
        public Mesh mesh;

        public DrawableMesh() : base()
        {

        }

        public override void Finish()
        {
            base.Finish();
            mesh.Refresh();
        }

        /// <summary>
        /// Renders this object from the view of the
        /// specified camera.
        /// </summary>
        /// <param name="camera"></param>
        public override void Render(Camera camera)
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

            SetMatrix4("translation", Transform.TranslationMatrix);
            SetMatrix4("rotation", Transform.RotationMatrix);
            SetMatrix4("scale", Transform.ScaleMatrix);

            //Set camera matrices
            {
                Matrix4 cameraTranslation = Matrix4.Identity;
                Matrix4 cameraRotation = Matrix4.Identity;
                Matrix4 cameraProjection = Matrix4.Identity;
                if (((int)CameraIgnore & 0b1000) == 0b0000)
                    cameraTranslation = camera.Transform.TranslationMatrix;

                if (((int)CameraIgnore & 0b0100) == 0b0000)
                    cameraRotation = camera.Transform.RotationMatrix;
                if (((int)CameraIgnore & 0b0001) == 0b0000)
                    cameraProjection = camera.Projection;

                SetMatrix4("projection", (Matrix4.Invert(cameraTranslation) * cameraRotation) * cameraProjection);
            }

            SetVector3("ambient", Game.AmbientLightColor);
            SetVector4("albedo", Material.Albedo);

            if(Material.Texture != null)
            {
                GL.BindTexture(TextureTarget.Texture2D, Material.Texture.glTexture);
                GL.ActiveTexture(TextureUnit.Texture0);
                SetFloat("tex0", 0);
                SetVector2("tiling", Material.Tiling);
                SetFloat("useTex", 1);
            }
            else
            {
                SetFloat("useTex", 0);
            }

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

            GL.DrawElements(PrimitiveType.Triangles, mesh.vertices.Length, DrawElementsType.UnsignedInt, mesh.indices);
            GL.BindTexture(TextureTarget.Texture2D, 0);
        }
    }
}
