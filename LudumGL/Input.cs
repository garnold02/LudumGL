using System;
using System.Windows.Forms;
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
        static MouseState mouseState;

        /// <summary>
        /// Relative mouse movement.
        /// </summary>
        public static Vector2 MouseDelta { get; private set; }

        /// <summary>
        /// Mouse position in window coordinates.
        /// </summary>
        public static Vector2 MousePosition { get; private set; }
        private static Vector2 mousePositionLast;

        /// <summary>
        /// Gets or sets the sensitivity of the mouse.
        /// </summary>
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
            mouseState = Mouse.GetState();
            MousePosition = new Vector2(mouseState.X, mouseState.Y);
            MouseDelta = (mousePositionLast - MousePosition) * MouseSensitivity;
            mousePositionLast = MousePosition;
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

        /// <summary>
        /// Returns true if the requested mouse button is pressed.
        /// </summary>
        /// <param name="button"></param>
        /// <returns></returns>
        public static bool GetButton(MouseButton button)
        {
            return mouseState.IsButtonDown(button);
        }

        /// <summary>
        /// Returns true if the requested mouse button is pressed on this frame.
        /// </summary>
        /// <param name="button"></param>
        /// <returns></returns>
        public static bool GetButtonDown(MouseButton button)
        {
            MouseState currentState = Mouse.GetState();
            return (currentState.IsButtonDown(button) != mouseState.IsButtonDown(button) && currentState.IsButtonDown(button));
        }
    }
}
