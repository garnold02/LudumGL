using System;
using OpenTK;

using LudumGL.Scene;

namespace LudumGL
{
    /// <summary>
    /// Represents a light in the scene.
    /// </summary>
    public class Light : ISceneObject
    {
        public int Id { get; set; }

        /// <summary>
        /// Returns the translation matrix of the light.
        /// </summary>
        public Matrix4 Translation { get => Matrix4.CreateTranslation(position); }

        /// <summary>
        /// Returns the rotation matrix of the light.
        /// </summary>
        public Matrix4 Rotation { get => Matrix4.CreateFromQuaternion(rotation); }

        [SceneData]
        public bool enabled;

        /// <summary>
        /// The type of the light.
        /// </summary>
        [SceneData]
        public LightType type;

        /// <summary>
        /// The position of the light.
        /// </summary>
        [SceneData]
        public Vector3 position;

        /// <summary>
        /// The rotation of the light.
        /// </summary>
        [SceneData]
        public Quaternion rotation;

        /// <summary>
        /// The color of the light. Alpha is intensity.
        /// </summary>
        [SceneData]
        public Vector4 color;

        /// <summary>
        /// The range of the light. Only relevant if
        /// LightType is PointLight.
        /// </summary>
        [SceneData]
        public float range;
    }
    public enum LightType
    {
        Point,
        Directional
    }
}
