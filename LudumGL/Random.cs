using s = System;

namespace LudumGL
{
    /// <summary>
    /// Pseudorandom number generator.
    /// </summary>
    public class Random
    {
        /// <summary>
        /// The default C# random number generator.
        /// </summary>
        public static s.Random Generator { get; private set; }

        /// <summary>
        /// Generates a random angle in degrees.
        /// </summary>
        public static float AngleDeg { get => (float)Generator.NextDouble() * 360; }

        /// <summary>
        /// Generates a random angle in radians.
        /// </summary>
        public static float AngleRad { get => (float)(Generator.NextDouble() * s.Math.PI * 2); }

        internal static void Initialize()
        {
            Generator = new s.Random();
        }

        /// <summary>
        /// Sets the seed of the default generator.
        /// </summary>
        /// <param name="seed"></param>
        public static void SetSeed(int seed)
        {
            Generator = new s.Random(seed);
        }
    }
}
