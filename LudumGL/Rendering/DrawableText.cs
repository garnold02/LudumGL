using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace LudumGL.Rendering
{
    /// <summary>
    /// A simple drawable object capable of rendering
    /// text.
    /// </summary>
    public class DrawableText : Drawable
    {
        readonly int uvBuffer;

        /// <summary>
        /// The string this TextRenderer will render.
        /// </summary>
        public string Text { get; set; }

        public DrawableText() : base()
        {
            uvBuffer = GL.GenBuffer();
        }

        public override void Render(Camera camera)
        {
            GL.UseProgram(program);

            //Bind texture
            if (Material.Texture != null)
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

            for (int i = 0; i < Text.Length; i++)
            {
                RenderGlyph(camera, Text[i], new Vector3(Material.Texture.Width * i, 0, 0));
            }

            GL.BindTexture(TextureTarget.Texture2D, 0);
        }

        void RenderGlyph(Camera camera, char character, Vector3 position)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, Mesh.Rectangle.vertexBuffer);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 4, VertexAttribPointerType.Float, false, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, Mesh.Rectangle.normalBuffer);
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 4, VertexAttribPointerType.Float, false, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, uvBuffer);
            GL.BufferData(BufferTarget.ArrayBuffer, Mesh.Rectangle.uvs.Length, Mesh.MapUvArray(Mesh.Rectangle.uvs, 0, 1, 0, 1), BufferUsageHint.DynamicDraw);
            GL.EnableVertexAttribArray(2);
            GL.VertexAttribPointer(2, 4, VertexAttribPointerType.Float, false, 0, 0);

            SetMatrix4("translation", Transform.TranslationMatrix * Matrix4.CreateTranslation(position));
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

            GL.DrawElements(PrimitiveType.Triangles, Mesh.Rectangle.vertices.Length, DrawElementsType.UnsignedInt, Mesh.Rectangle.indices);
        }
    }
}
