using System;
using LudumGL;
using LudumGL.UserInterface;
using LudumGL.Debugging;
using LudumGL.Rendering;
using LudumGL.Components;
using LudumGL.Scene;
using OpenTK;
using OpenTK.Input;

namespace TestGame
{
    class Loop : GameLoop
    {
        #region Static
        static Mesh cubeMesh;
        static readonly Material cubeMaterial = Material.Default;
        #endregion
        public override void Start()
        {
            Initialize();
            SetupLight();
            SetupCamera();
            SetupUI();
            SetupMeshes();
            Physics.Gravity = Vector3.Zero;

            //SceneManager.Load("scenes/test.scene");
        }
        public override void Update(object sender, FrameEventArgs e)
        {
            if (Input.GetKeyDown(Key.Home)) Game.MouseLocked = !Game.MouseLocked;
            if (Input.GetKeyDown(Key.Escape)) Game.Exit();

            if(Input.GetKeyDown(Key.Enter))
            {
                SceneManager.Save("scenes/test.scene");
            }

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
            FlyingCamera flyingCamera = new FlyingCamera(0, 0, 40);
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

            void ToolboxUpdate(object sender, EventArgs e)
            {
                ScalablePanel _sender = (ScalablePanel)sender;
                Vector2 toolboxSize = _sender.ScreenToPixel(new Vector2(1, 0));
                _sender.Size = new Vector2(toolboxSize.X, 6);
            }

            UI.AddElement(toolbox);

            Button spawnCubeButton = new Button(panelTexture, font);
            spawnCubeButton.Body.Parent = toolbox;
            spawnCubeButton.Body.Pivot = -Vector2.One;
            spawnCubeButton.Body.Position = -Vector2.One;
            spawnCubeButton.Body.PixelTranslation = Vector2.One * 8;

            spawnCubeButton.Body.AllowClickRepetition = true;
            spawnCubeButton.Body.OnClick += SpawnCube;
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
            cube.Drawable.Material = cubeMaterial;
            cube.Transform.Rotate(LudumGL.Random.AngleDeg, LudumGL.Random.AngleDeg, LudumGL.Random.AngleDeg);
            BoxCollider collider = new BoxCollider();
            PhysicsBody body = new PhysicsBody();
            cube.AddComponent(collider);
            cube.AddComponent(body);

            GameObject.Add(cube);
        }
    }
}