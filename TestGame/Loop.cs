using System;
using System.Collections.Generic;
using LudumGL;
using OpenTK;
using OpenTK.Input;

namespace TestGame
{
    class Loop : GameLoop
    {
        static Light light;
        static Camera camera;

        public override void Start()
        {
            light = new Light
            {
                enabled = true,
                type=LightType.Point,
                color = new Vector4(1, 1, 1, 1),
                range = 30,
                position = new Vector3(0, 5, 0),
                rotation = Quaternion.FromEulerAngles(0, 0, 0)
            };
            Game.activeLights[0] = light;
            camera = new Camera();
            camera.Transform.localPosition = new Vector3(0, 0, 0);
            Game.mainCamera = camera;
            Input.MouseSensitivity = 0.1f;

            Mesh sceneMesh = Mesh.Load("assets/mesh/scene.dae");
            Mesh skyMesh = Mesh.Load("assets/mesh/sky.dae");
            Texture sceneTex = Texture.LoadFromFile("assets/tex/scene.png");
            //Texture skyTex = Texture.LoadFromFile("assets/tex/sky.png");

            GameObject cube = new GameObject
            {
                Drawable = Drawable.MakeDrawable(sceneMesh, Shaders.Lit),
                Transform = new Transform() { localPosition = new Vector3(0, -2, 0), localScale=new Vector3(1,1,1)*10 },
            };
            cube.Drawable.Texture = sceneTex;
            GameObject.Add(cube);
        }

        static float t;
        public override void Update(object sender, FrameEventArgs e)
        {
            t += 0.01f;
            if(Input.GetKey(Key.W))
            {
                camera.Transform.localPosition += Game.mainCamera.Transform.Forward * 0.1f;
            }
            if (Input.GetKey(Key.S))
            {
                camera.Transform.localPosition -= Game.mainCamera.Transform.Forward * 0.1f;
            }
            if (Input.GetKey(Key.A))
            {
                camera.Transform.localPosition -= Game.mainCamera.Transform.Right * 0.1f;
            }
            if (Input.GetKey(Key.D))
            {
                camera.Transform.localPosition += Game.mainCamera.Transform.Right * 0.1f;
            }
            if (Input.GetKey(Key.Q))
            {
                camera.Transform.Rotate(0, 0, -2);
            }
            if (Input.GetKey(Key.E))
            {
                camera.Transform.Rotate(0, 0, 2);
            }
            camera.Transform.Rotate(-Input.MouseDelta.Y * Input.MouseSensitivity, -Input.MouseDelta.X * Input.MouseSensitivity, 0);
        }

        public override void Render(object sender, FrameEventArgs e)
        {

        }
    }
}
