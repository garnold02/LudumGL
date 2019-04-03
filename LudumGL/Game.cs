using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace LudumGL
{
    public class Game
    {
        public static InitialSettings initialSettigns = InitialSettings.Default;
        public static GameLoop gameLoop;
        public static Light[] activeLights;

        public static float AspectRatio { get => window.Width / (float)window.Height; }

        static GameWindow window;

        public static void Start()
        {
            window = new GameWindow(initialSettigns.Width, initialSettigns.Height)
            {
                Title = initialSettigns.Title
            };
            window.UpdateFrame += gameLoop.Update;
            window.UpdateFrame += PostUpdate;
            window.RenderFrame += gameLoop.Render;
            window.RenderFrame += PostRender;

            Initialize();
            gameLoop.Start();

            window.Run(60);
        }

        static void Initialize()
        {
            GL.Enable(EnableCap.DepthTest);
            activeLights = new Light[10];
        }

        static void PostUpdate(object sender, FrameEventArgs e)
        {

        }

        static void PostRender(object sender, FrameEventArgs e)
        {
            window.SwapBuffers();
            GL.ClearColor(0, 0, 0, 1);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }
    }
    public struct InitialSettings
    {
        public static InitialSettings Default
        {
            get
            {
                return new InitialSettings
                {
                    Width = 640,
                    Height = 480,
                    Title = "LudumGL"
                };
            }
        }

        public int Width { get; set; }
        public int Height { get; set; }
        public string Title { get; set; }
    }
}
