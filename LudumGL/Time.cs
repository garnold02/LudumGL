using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudumGL
{
    /// <summary>
    /// Class for dealing with time.
    /// </summary>
    public class Time
    {
        /// <summary>
        /// Gets the time spent in the last frame, in seconds.
        /// </summary>
        public static float DeltaTime { get => (float)Game.window.UpdateTime + (float)Game.window.RenderTime; }

        /// <summary>
        /// Gets the elapsed time since the start of the game, in seconds.
        /// </summary>
        public static float Elapsed { get => Game.elapsedTime; }
    }
}
