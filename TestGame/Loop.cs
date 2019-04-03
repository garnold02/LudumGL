using System;
using System.Collections.Generic;
using LudumGL;
using OpenTK;

namespace TestGame
{
    class Loop : GameLoop
    {
        static Drawable drawable;

        public override void Start()
        {
            drawable = new Drawable
            {
                mesh = Mesh.Load("assets/mesh/cube.dae"),
                translation = Matrix4.CreateTranslation(0, 0, -5),
                rotation = Matrix4.CreateRotationY(45),
                scale = Matrix4.CreateScale(1, 1, 1),
                projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(60), Game.AspectRatio, 0.1f, 100f)
            };
            drawable.AddShaderRaw(Shaders.Projection, OpenTK.Graphics.OpenGL.ShaderType.VertexShader);
            drawable.AddShaderRaw(Shaders.Lit, OpenTK.Graphics.OpenGL.ShaderType.FragmentShader);
            drawable.Finish();

            Light l = new Light
            {
                enabled = true,
                color = new Vector4(1, 1, 1, 1),
                range = 10,
                position = new Vector3(0, 0, 0),
                rotation = Quaternion.FromEulerAngles(0, 0, 0)
            };

            Game.activeLights[0] = l;
        }

        public override void Update(object sender, FrameEventArgs e)
        {
            drawable.rotation *= Matrix4.CreateFromQuaternion(Quaternion.FromEulerAngles(0, 0.01f, 0));
        }

        public override void Render(object sender, FrameEventArgs e)
        {
            drawable.Render();
        }
    }
}
