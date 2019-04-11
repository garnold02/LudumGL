using System;
using OpenTK;

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

        /// <summary>
        /// Checks if two rectangles are overlapping.
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="width1"></param>
        /// <param name="height1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="width2"></param>
        /// <param name="height2"></param>
        /// <returns></returns>
        public static bool Overlap(float x1, float y1, float width1, float height1, float x2, float y2, float width2, float height2)
        {
            return (x1 + width1 > x2 && x1 < x2 + width2 && y1 + height1 > y2 && y1 < y2 + height2);
        }

        /// <summary>
        /// Checks if two rectangles are overlapping.
        /// </summary>
        /// <param name="rectangle1"></param>
        /// <param name="rectangle2"></param>
        /// <returns></returns>
        public static bool Overlap(Vector4 rectangle1, Vector4 rectangle2)
        {
            return Overlap(rectangle1.X, rectangle1.Y, rectangle1.Z, rectangle1.W, rectangle2.X, rectangle2.Y, rectangle2.Z, rectangle2.W);
        }
    }
}
