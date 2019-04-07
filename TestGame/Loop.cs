using System;
using System.Collections.Generic;
using LudumGL;
using LudumGL.Components;
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
            Game.MouseLocked = true;

            Game.AmbientLightColor = Vector3.One * 0.5f;
            light = new Light
            {
                enabled = true,
                type = LightType.Directional,
                color = new Vector4(1, 1, 1, 1),
                range = 80,
                position = new Vector3(0, 30, 5),
                rotation = Quaternion.FromEulerAngles(-45, 0, 0)
            };
            Game.activeLights[0] = light;
            camera = new Camera()
            {
                FarClip = 1000
            };
            camera.Transform.localPosition = new Vector3(0, 5, 10);

            Camera skyCam = new Camera()
            {
                FarClip = 100,
                Depth = -1,
            };
            skyCam.Transform.Parent = camera.Transform;
            Game.mainCamera = camera;
            Input.MouseSensitivity = 0.1f;

            Mesh cubeMesh = Mesh.Load("assets/mesh/cube.dae");
            Texture floorTexture = Texture.LoadFromFile("assets/tex/grass.png", TextureFilteringMode.Nearest);
            Texture crateTexture = Texture.LoadFromFile("assets/tex/crate.png", TextureFilteringMode.Nearest);
            float num = 100;
            for (int i = 0; i < num; i++)
            {

                GameObject fallingCube = new GameObject()
                {
                    Drawable = RenderMesh.MakeRenderMesh(cubeMesh, Shaders.Lit),
                    Transform = new Transform() { localPosition = new Vector3(0, 5+i*2, 0) }
                };
                fallingCube.Transform.Rotate(i*10, i*10, i*10);
                fallingCube.Drawable.Material.Albedo = new Vector4(i/num, 1-(i/num), ((i+num/2f)%num)/num, 1f);
                fallingCube.Drawable.Material.Texture = crateTexture;

                BoxCollider collider = new BoxCollider();
                PhysicsBody physicsBody = new PhysicsBody();
                fallingCube.AddComponent(collider);
                fallingCube.AddComponent(physicsBody);
                GameObject.Add(fallingCube);
            }

            GameObject floor = new GameObject()
            {
                Drawable = RenderMesh.MakeRenderMesh(Mesh.Load("assets/mesh/cube.dae"), Shaders.Lit),
                Transform = new Transform() { localPosition = new Vector3(0, 0, 0), localScale=new Vector3(100,1,100) }
            };
            floor.Drawable.Material.Texture = floorTexture;
            floor.Drawable.Material.Tiling = Vector2.One * 10;
            BoxCollider floorCollider = new BoxCollider();
            PhysicsBody floorBody = new PhysicsBody() { Mass = 0 };
            floor.AddComponent(floorCollider);
            floor.AddComponent(floorBody);
            GameObject.Add(floor);

            GameObject sky = new GameObject()
            {
                Drawable = RenderMesh.MakeRenderMesh(Mesh.Load("assets/mesh/sky.dae"), Shaders.Unlit),
                Transform = new Transform() { localScale = Vector3.One, localPosition=new Vector3(0,0,0) },
                CameraOverride=skyCam
            };
            sky.Transform.Rotate(-90, 0, 0);
            sky.Drawable.Material.Texture = Texture.LoadFromFile("assets/tex/sky.png", TextureFilteringMode.Nearest);
            sky.Drawable.CameraIgnore = MatrixIgnoreMode.Translation;
            GameObject.Add(sky);

            GameObject crosshair = new GameObject()
            {
                Drawable = RenderMesh.MakeRenderMesh(cubeMesh, Shaders.Unlit),
                Transform=new Transform { localPosition=new Vector3(0,0,-1), localScale=Vector3.One*0.01f}
            };
            crosshair.CameraOverride = new Camera() { Depth = 1 };
            GameObject.Add(crosshair);
        }

        public override void Update(object sender, FrameEventArgs e)
        {
            if (Input.GetKeyDown(Key.Home)) Game.MouseLocked = !Game.MouseLocked;
            if (Input.GetKeyDown(Key.Escape)) Game.Exit();
            if (Input.GetKey(Key.W))
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
            camera.Transform.Rotate(-Input.MouseDelta.Y, -Input.MouseDelta.X, 0);

            if(Input.GetButton(MouseButton.Left))
            {
                if (Physics.Raycast(camera.ForwardRay, out RaycastData data))
                {
                    if (data.body != null)
                    {
                        data.body.AddForce((camera.Transform.Position-data.body.Parent.Transform.Position).Normalized()*1f);
                    }
                }
            }
        }

        public override void Render(object sender, FrameEventArgs e)
        {

        }
    }
}
