using System;
using System.Collections.Generic;
using LudumGL;
using LudumGL.Rendering;
using LudumGL.Components;
using LudumGL.UserInterface;
using LudumGL.Debugging;
using OpenTK;
using OpenTK.Input;

namespace TestGame
{
    class Loop : GameLoop
    {
        static Light light;
        static ScalablePanel panel;
        public override void Start()
        {
            //Game.MouseLocked = true;
            Debug.Enabled = true;

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
            FlyingCamera flyingCamera = new FlyingCamera(0, 5, -5);
            Debug.AddDebugObject(flyingCamera);

            flyingCamera.Camera.Transform.localPosition = new Vector3(0, 5, 10);

            Camera skyCam = new Camera()
            {
                FarClip = 100,
                Depth = -1,
            };
            skyCam.Transform.Parent = flyingCamera.Camera.Transform;
            Game.mainCamera = flyingCamera.Camera;
            Input.MouseSensitivity = 0.1f;

            Mesh cubeMesh = Mesh.Load("assets/mesh/cube.dae");
            Texture floorTexture = Texture.LoadFromFile("assets/tex/grass.png", TextureFilteringMode.Nearest);
            Texture crateTexture = Texture.LoadFromFile("assets/tex/crate.png", TextureFilteringMode.Nearest);
            float num = 100;
            for (int i = 0; i < num; i++)
            {

                GameObject fallingCube = new GameObject()
                {
                    Drawable = DrawableMesh.Create(cubeMesh, Shaders.Lit),
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
                Drawable = DrawableMesh.Create(Mesh.Load("assets/mesh/cube.dae"), Shaders.Lit),
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
                Drawable = DrawableMesh.Create(Mesh.Load("assets/mesh/sky.dae"), Shaders.Unlit),
                Transform = new Transform() { localScale = Vector3.One, localPosition=new Vector3(0,0,0) },
                CameraOverride=skyCam
            };
            sky.Transform.Rotate(-90, 0, 0);
            sky.Drawable.Material.Texture = Texture.LoadFromFile("assets/tex/sky.png", TextureFilteringMode.Nearest);
            sky.Drawable.CameraIgnore = MatrixIgnoreMode.Translation;
            GameObject.Add(sky);

            Texture crosshairTex= Texture.LoadFromFile("assets/tex/crosshair.png");
            Panel crosshair = new Panel();
            crosshair.Material.Texture = crosshairTex;
            UI.AddElement(crosshair);

            Texture panelTex = Texture.LoadFromFile("assets/tex/panel.png");

            panel = new ScalablePanel
            {
                Position = new Vector2(-1, -1),
                Pivot = new Vector2(-1, -1),
                PixelTranslation = new Vector2(8, 8),
                Size=new Vector2(10,5)
            };
            panel.Material.Texture = panelTex;

            UIText text = new UIText()
            {
                Text = "hello, world!"
            };
            text.Material.Texture = panelTex;

            UI.AddElement(panel);
            UI.AddElement(text);
        }

        static float t;
        public override void Update(object sender, FrameEventArgs e)
        {
            if (Input.GetKeyDown(Key.Home)) Game.MouseLocked = !Game.MouseLocked;
            if (Input.GetKeyDown(Key.Escape)) Game.Exit();
            if (Input.GetButton(MouseButton.Left))
            {
                if (Physics.Raycast(Game.mainCamera.ForwardRay, out RaycastData data))
                {
                    if (data.body != null)
                    {
                        data.body.AddForce((Game.mainCamera.Transform.Position-data.body.Parent.Transform.Position).Normalized()*1f);
                    }
                }
            }

            panel.Size = new Vector2(1,0.5f) * (float)(Math.Sin(t)+2)*4;
            t += 0.05f;
        }

        public override void Render(object sender, FrameEventArgs e)
        {

        }
    }
}
