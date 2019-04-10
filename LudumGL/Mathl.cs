using System;

namespace LudumGL
{
    /// <summary>
    /// Class containing useful mathematics.
    /// </summary>
    class Mathl
    {
        /// <summary>
        /// Shorthand for 1/3
        /// </summary>
        public const float Third = 0.33333333333333333333f;

        /// <summary>
        /// Shorthand for 1/6
        /// </summary>
        public const float Sixth = 0.16666666666666666666f;

        /// <summary>
        /// Maps a value from one range to another.
        /// </summary>
        /// <param name="value">The original value</param>
        /// <param name="oldMin">Minimum of the original range</param>
        /// <param name="oldMax">Maximum of the original range</param>
        /// <param name="newMin">Minimum of the new range</param>
        /// <param name="newMax">Maximum of the new range</param>
        /// <returns>The new value</returns>
        public static float Map(float value, float oldMin, float oldMax, float newMin, float newMax)
        {
            //First, normalize the value
            float normalizedValue = (value - oldMin) / (oldMax - oldMin);

            //Then, scale up the normalized value
            float scaledValue = normalizedValue * (newMax - newMin);

            //Finally, add the new minimum to the scaled value.
            float finalValue = newMin + scaledValue;

            //Return the final value
            return finalValue;
        }
    }
}
