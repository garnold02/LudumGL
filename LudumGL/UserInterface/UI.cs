using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;
using LudumGL.Rendering;

namespace LudumGL.UserInterface
{
    /// <summary>
    /// User interface.
    /// </summary>
    public class UI
    {
        internal static List<UIElement> elements = new List<UIElement>();
        internal static List<UIElement> elementsAdd = new List<UIElement>();
        internal static List<UIElement> elementsRemove = new List<UIElement>();

        internal static void Update()
        {
            foreach (UIElement element in elements)
            {
                element.Update();
            }
            elements.AddRange(elementsAdd);
            foreach (UIElement element in elementsRemove)
            {
                elements.Remove(element);
            }

            elementsAdd.Clear();
            elementsRemove.Clear();
        }

        internal static void Render()
        {
            GL.Clear(ClearBufferMask.DepthBufferBit);
            foreach (UIElement element in elements)
            {
                foreach (Drawable drawable in element.drawables)
                {
                    drawable.Render(Camera.UI);
                }
            }
        }

        /// <summary>
        /// Adds a UI element to the UI.
        /// </summary>
        /// <param name="element"></param>
        public static void AddElement(UIElement element)
        {
            elementsAdd.Add(element);
        }

        /// <summary>
        /// Removes a UI element from the UI.
        /// </summary>
        /// <param name="element"></param>
        public static void RemoveElement(UIElement element)
        {
            elementsRemove.Add(element);
        }
    }
}
