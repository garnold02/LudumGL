using System;
using OpenTK;
using OpenTK.Input;

namespace LudumGL
{
    /// <summary>
    /// Input handling.
    /// </summary>
    public static class Input
    {
        static readonly byte[] currentPressedKeys = new byte[Enum.GetNames(typeof(Key)).Length];

        /// <summary>
        /// Relative mouse movement.
        /// </summary>
        public static Vector2 MouseDelta { get; private set; }
        private static Vector2 mousePositionLast;

        public static float MouseSensitivity { get; set; } = 0.1f;

        /// <summary>
        /// Updates KeyPresses and the Mouse.
        /// </summary>
        public static void Update()
        {
            for (int i = 0; i < currentPressedKeys.Length; i++)
            {
                if (currentPressedKeys[i] == 2) currentPressedKeys[i] = 1;
            }
            MouseState mouseState = Mouse.GetState();
            Vector2 currentMousePosition = new Vector2(mouseState.X, mouseState.Y);
            MouseDelta = mousePositionLast - currentMousePosition;
            mousePositionLast = currentMousePosition;

            if (!Game.window.Focused) MouseDelta = new Vector2(0, 0);

        }
        public static void KeyPress(object sender, KeyboardKeyEventArgs e)
        {
            currentPressedKeys[(int)e.Key] = 2;
        }
        public static void KeyRelease(object sender, KeyboardKeyEventArgs e)
        {
            currentPressedKeys[(int)e.Key] = 0;
        }

        /// <summary>
        /// Returns true if the requested key is currently pressed.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool GetKey(Key key)
        {
            if (!Game.window.Focused) return false;
            return currentPressedKeys[(int)key] != 0;
        }
        /// <summary>
        /// Returns true if the requested key is pressed on this frame.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool GetKeyDown(Key key)
        {
            if (!Game.window.Focused) return false;
            if (currentPressedKeys[(int)key] == 1)
            {
                currentPressedKeys[(int)key] = 0;
                return true;
            }
            return false;
        }
    }
}
