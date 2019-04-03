using System;
using OpenTK;

namespace LudumGL
{
    public class Light
    {
        public Matrix4 Translation { get => Matrix4.CreateTranslation(position); }
        public Matrix4 Rotation { get => Matrix4.CreateFromQuaternion(rotation); }

        public bool enabled;
        public Vector3 position;
        public Quaternion rotation;
        public Vector4 color;
        public float range;
    }
    enum LightType
    {
        Point,
        Directional
    }
}
