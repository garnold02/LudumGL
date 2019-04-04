using System;
using OpenTK;


namespace LudumGL
{
    /// <summary>
    /// Base class for a game loop.
    /// </summary>
    public abstract class GameLoop
    {
        /// <summary>
        /// Runs at start
        /// </summary>
        public abstract void Start();

        /// <summary>
        /// Runs every frame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public abstract void Update(object sender, FrameEventArgs e);

        /// <summary>
        /// Runs every frame; use for rendering Drawable objects.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public abstract void Render(object sender, FrameEventArgs e);
    }
}
