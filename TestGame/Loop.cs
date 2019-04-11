using System;
using LudumGL;
using LudumGL.UserInterface;
using LudumGL.Debugging;
using LudumGL.Rendering;
using LudumGL.Components;
using OpenTK;
using OpenTK.Input;

namespace TestGame
{
    class Loop : GameLoop
    {
        #region Static
        static Mesh cubeMesh;
        #endregion
        public override void Start()
        {
            Initialize();
            SetupLight();
            SetupCamera();
            SetupUI();
            SetupMeshes();
            Physics.Gravity = Vector3.Zero;

        }
        public override void Update(object sender, FrameEventArgs e)
        {
            if (Input.GetKeyDown(Key.Home)) Game.MouseLocked = !Game.MouseLocked;
            if (Input.GetKeyDown(Key.Escape)) Game.Exit();

        }

        public override void Render(object sender, FrameEventArgs e)
        {

        }

        static void Initialize()
        {
            //Game.MouseLocked = true;
            Debug.Enabled = true;
        }

        static void SetupLight()
        {
            Game.AmbientLightColor = Vector3.One * 0.5f;
            Light light = new Light
            {
                enabled = true,
                type = LightType.Directional,
                color = new Vector4(1, 1, 1, 1),
                range = 80,
                position = new Vector3(0, 30, 5),
                rotation = Quaternion.FromEulerAngles(-45, 0, 0)
            };
            Game.activeLights[0] = light;
        }

        static void SetupCamera()
        {
            FlyingCamera flyingCamera = new FlyingCamera(0, 0, -5);
            Debug.AddDebugObject(flyingCamera);

            Game.mainCamera = flyingCamera.Camera;
        }

        static void SetupUI()
        {
            Font font = Font.Load("assets/tex/font.png", 10, 10);
            Texture panelTexture = Texture.LoadFromFile("assets/tex/panel.png");

            ScalablePanel toolbox = new ScalablePanel
            {
                Pivot = new Vector2(0, 1),
                Position = new Vector2(0, 1),
                Depth=10
            };
            toolbox.OnUpdate += ToolboxUpdate;
            toolbox.Material.Texture = panelTexture;

            ScalablePanel spawnCubeButton = new ScalablePanel()
            {
                Parent = toolbox,
                Pivot = new Vector2(-1, -1),
                Position = new Vector2(-1, -1),
                Size=new Vector2(3.5f,1),
                PixelTranslation=Vector2.One*8
            };
            spawnCubeButton.Material.Texture = panelTexture;
            spawnCubeButton.Material.Albedo = new Vector4(0.5f, 1, 0.5f, 1);
            spawnCubeButton.OnClick += SpawnCube;

            UIText spawnCubeText = new UIText()
            {
                Font = font,
                Text = "Spawn cube",
                Parent=spawnCubeButton,
                Depth=-1,
                Position=new Vector2(-1,-1),
                PixelTranslation=Vector2.One*8
            };
            spawnCubeText.Material.Albedo = new Vector4(0, 0, 0, 1);

            void ToolboxUpdate(object sender, EventArgs e)
            {
                ScalablePanel _sender = (ScalablePanel)sender;
                Vector2 toolboxSize = _sender.ScreenToPixel(new Vector2(1, 0));
                _sender.Size = new Vector2(toolboxSize.X, 6);
            }

            UI.AddElement(toolbox);
            UI.AddElement(spawnCubeButton);
            UI.AddElement(spawnCubeText);
        }

        static void SetupMeshes()
        {
            cubeMesh = Mesh.Load("assets/mesh/cube.dae");
        }

        static void SpawnCube(object sender, EventArgs e)
        {
            GameObject cube = new GameObject()
            {
                Drawable=DrawableMesh.Create(cubeMesh, Shaders.Lit)
            };
            BoxCollider collider = new BoxCollider();
            PhysicsBody body = new PhysicsBody();
            cube.AddComponent(collider);
            cube.AddComponent(body);

            GameObject.Add(cube);
        }
    }
}