using System;
using System.Collections.Generic;
using LudumGL;
using OpenTK;
using OpenTK.Input;

namespace TestGame
{
    class Loop : GameLoop
    {
        static Drawable drawable;

        public override void Start()
        {
            drawable = new Drawable
            {
                mesh = Mesh.Load("assets/mesh/monkey.dae"),
                transform = new Transform() { position = new Vector3(0, 0, 0) }
            };
            drawable.AddShaderRaw(Shaders.Projection, OpenTK.Graphics.OpenGL.ShaderType.VertexShader);
            drawable.AddShaderRaw(Shaders.Lit, OpenTK.Graphics.OpenGL.ShaderType.FragmentShader);
            drawable.Finish();

            Light light1 = new Light
            {
                enabled = true,
                color = new Vector4(1, 0.8f, 1, 2),
                range = 10,
                position = new Vector3(0, 0, 5),
                rotation = Quaternion.FromEulerAngles(0, 0, 0)
            };
            Light light2 = new Light
            {
                enabled = true,
                color = new Vector4(0, 1, 0, 5),
                range = 10,
                position = new Vector3(0, 0, -5),
                rotation = Quaternion.FromEulerAngles(0, 0, 0)
            };

            Game.activeLights[0] = light1;
            //Game.activeLights[1] = light2;
            Game.mainCamera = new Camera();
            Game.mainCamera.Transform.position = new Vector3(0, 0, -5);
            Input.MouseSensitivity = 0.1f;
        }

        public override void Update(object sender, FrameEventArgs e)
        {
            //drawable.rotation *= Matrix4.CreateFromQuaternion(Quaternion.FromEulerAngles(0, 0.01f, 0));
            if(Input.GetKey(Key.W))
            {
                Game.mainCamera.Transform.position += Game.mainCamera.Transform.Forward * 0.1f;
            }
            if (Input.GetKey(Key.S))
            {
                Game.mainCamera.Transform.position -= Game.mainCamera.Transform.Forward * 0.1f;
            }
            if (Input.GetKey(Key.A))
            {
                Game.mainCamera.Transform.position -= Game.mainCamera.Transform.Right * 0.1f;
            }
            if (Input.GetKey(Key.D))
            {
                Game.mainCamera.Transform.position += Game.mainCamera.Transform.Right * 0.1f;
            }
            if (Input.GetKey(Key.Q))
            {
                Game.mainCamera.Transform.Rotate(0, 0, -2);
            }
            if (Input.GetKey(Key.E))
            {
                Game.mainCamera.Transform.Rotate(0, 0, 2);
            }
            Game.mainCamera.Transform.Rotate(-Input.MouseDelta.Y * Input.MouseSensitivity, -Input.MouseDelta.X * Input.MouseSensitivity, 0);
        }

        public override void Render(object sender, FrameEventArgs e)
        {
            drawable.Render(Game.mainCamera);
        }
    }
}
