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

        /// <summary>
        /// The font this Text will use.
        /// </summary>
        public Font Font { get; set; }

        /// <summary>
        /// The size of the text in pixels.
        /// </summary>
        public Vector2 Size { get; private set; }

        public DrawableText() : base()
        {
            uvBuffer = GL.GenBuffer();
        }

        public override void Render(Camera camera)
        {
            Vector2 size = Vector2.Zero;
            GL.UseProgram(program);

            //Bind buffers
            GL.BindBuffer(BufferTarget.ArrayBuffer, Mesh.Rectangle.vertexBuffer);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 4, VertexAttribPointerType.Float, false, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, Mesh.Rectangle.normalBuffer);
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 4, VertexAttribPointerType.Float, false, 0, 0);

            SetVector3("ambient", Game.AmbientLightColor);
            SetVector4("albedo", Material.Albedo);

            //Bind texture
            GL.BindTexture(TextureTarget.Texture2D, Font.Bitmap.glTexture);
            GL.ActiveTexture(TextureUnit.Texture0);
            SetFloat("tex0", 0);
            SetVector2("tiling", Vector2.One);
            SetFloat("useTex", 1);

            //Render glyphs
            int xOffset = 0;
            int yOffset = 0;
            for (int i = 0; i < Text.Length; i++)
            {
                if (Text[i] == '\n')
                {
                    //New line
                    if (xOffset > size.X) size.X = xOffset;
                    xOffset = 0;
                    yOffset--;
                    continue;
                }

                RenderGlyph(camera, Text[i], new Vector3(Transform.localScale.X * xOffset + Transform.localScale.X * 0.5f, Transform.localScale.Y * yOffset - Transform.localScale.X * 0.5f, 0));

                xOffset++;
                size.X = xOffset;
                size.Y = yOffset;
            }

            Size = size;
            GL.BindTexture(TextureTarget.Texture2D, 0);
        }

        void RenderGlyph(Camera camera, char character, Vector3 position)
        {
            //Character box
            Vector4 characterBox = Font.GetCharacterBox(character);
            Vector4 uvMap = new Vector4(characterBox.X, characterBox.X + characterBox.Z, characterBox.Y, characterBox.Y + characterBox.W);

            //Set camera matrices
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

            //Bind UV buffer
            GL.BindBuffer(BufferTarget.ArrayBuffer, uvBuffer);
            GL.BufferData(BufferTarget.ArrayBuffer, Vector4.SizeInBytes * Mesh.Rectangle.uvs.Length, Mesh.MapUvArray(Mesh.Rectangle.uvs, uvMap.X, uvMap.Y, uvMap.Z, uvMap.W), BufferUsageHint.DynamicDraw);
            GL.EnableVertexAttribArray(2);
            GL.VertexAttribPointer(2, 4, VertexAttribPointerType.Float, false, 0, 0);

            SetMatrix4("translation", Transform.TranslationMatrix);
            SetMatrix4("rotation", Matrix4.CreateTranslation(position) * Transform.RotationMatrix);
            SetMatrix4("scale", Transform.ScaleMatrix);

            GL.DrawElements(PrimitiveType.Triangles, Mesh.Rectangle.vertices.Length, DrawElementsType.UnsignedInt, Mesh.Rectangle.indices);
        }
    }
}
