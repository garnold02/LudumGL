using System;
using OpenTK;


namespace LudumGL
{
    public abstract class GameLoop
    {
        public abstract void Start();
        public abstract void Update(object sender, FrameEventArgs e);
        public abstract void Render(object sender, FrameEventArgs e);
    }
}
