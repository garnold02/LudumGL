#pragma warning disable 0649
using System;
using OpenTK;
using LudumGL.Components;

namespace LudumGL
{
    /// <summary>
    /// Structure containing data returned by the
    /// Physics.Raycast method.
    /// </summary>
    public struct RaycastData
    {
        public Vector3 position;
        public Vector3 normal;
        public PhysicsBody body;
    }
}
