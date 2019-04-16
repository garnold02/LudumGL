using System;
using System.Windows.Forms;
using OpenTK;
using LudumGL;
using LudumGL.Rendering;
using LudumGL.Debugging;

namespace LevelEditor
{
    class SceneViewLoop : GameLoop
    {
        static DrawableMesh originDrawable;
        static FlyingCamera camera;
        static Camera gizmoCamera;

        static DrawableMesh gizmoDraw;

        public override void Start()
        {
            Resources.Initialize();
            Initialize();
        }

        public override void Update(object sender, FrameEventArgs e)
        {
            camera.Update();
            gizmoCamera.Transform = camera.Camera.Transform;
        }

        public override void Render(object sender, FrameEventArgs e)
        {
            originDrawable.Render(Game.mainCamera);
            RenderObjectGizmos();
        }

        static void Initialize()
        {
            originDrawable = DrawableMesh.Create(Resources.mesh_origin, Shaders.Unlit);
            originDrawable.Material.Texture = Resources.texture_origin;

            camera = new FlyingCamera()
            {
                NeedsMouseInput = true
            };
            camera.Camera.Transform = new Transform
            {
                localPosition = Vector3.One*2,
                localRotation = Quaternion.FromEulerAngles((float)Math.PI/6f, -(float)Math.PI/4f, 0)
            };
            gizmoCamera = new Camera { Depth = int.MaxValue };

            Game.mainCamera = camera.Camera;

            gizmoDraw = DrawableMesh.Create(Mesh.Load("assets/mdl/gizmo.dae"), Shaders.Unlit);
            gizmoDraw.Material.Albedo = new Vector4(0, 1, 0, 1);
        }

        static void RenderObjectGizmos()
        {
            foreach (GameObject gameObject in Program.sceneObjects)
            {
                gizmoDraw.Transform = gameObject.Transform;
                gizmoDraw.Transform.localScale = Vector3.One * 0.1f;
                gizmoDraw.Render(gizmoCamera);
            }
        }
    }
}
