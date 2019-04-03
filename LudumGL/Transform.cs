#pragma warning disable CS0649
using System;
using OpenTK;

namespace LudumGL
{
    public class Transform
    {
        public static Transform Identity { get => new Transform() { position = new Vector3(0, 0, 0), rotation = Quaternion.Identity, scale = new Vector3(1, 1, 1) }; }

        public Matrix4 TranslationMatrix { get => Matrix4.CreateTranslation(position); }
        public Matrix4 RotationMatrix { get => Matrix4.CreateFromQuaternion(rotation); }
        public Matrix4 ScaleMatrix { get => Matrix4.CreateScale(scale); }
        public Matrix4 Matrix { get => RotationMatrix * ScaleMatrix * TranslationMatrix; }

        public Vector3 Right { get => (RotationMatrix * new Vector4(-1, 0, 0, 0)).Xyz; }
        public Vector3 Up { get => (RotationMatrix * new Vector4(0, 1, 0, 0)).Xyz; }
        public Vector3 Forward { get => (RotationMatrix * new Vector4(0, 0, 1, 0)).Xyz; }

        public Vector3 position=new Vector3(0,0,0);
        public Quaternion rotation=Quaternion.Identity;
        public Vector3 scale=new Vector3(1,1,1);

        public void Rotate(Quaternion rotation)
        {
            this.rotation = rotation * this.rotation;
        }
        public void Rotate(Vector3 rotation)
        {
            this.rotation = Quaternion.FromEulerAngles(MathHelper.DegreesToRadians(rotation.X), MathHelper.DegreesToRadians(rotation.Y), MathHelper.DegreesToRadians(rotation.Z)) * this.rotation;
        }
        public void Rotate(float x, float y, float z)
        {
            rotation = Quaternion.FromEulerAngles(MathHelper.DegreesToRadians(x), MathHelper.DegreesToRadians(y), MathHelper.DegreesToRadians(z)) * rotation;
        }
        
    }
}
