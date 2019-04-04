#pragma warning disable CS0649
using System;
using OpenTK;

namespace LudumGL
{
    /// <summary>
    /// Represents a linear transformation.
    /// </summary>
    public class Transform
    {
        /// <summary>
        /// Returns the identity transformation.
        /// </summary>
        public static Transform Identity { get => new Transform() { position = new Vector3(0, 0, 0), rotation = Quaternion.Identity, scale = new Vector3(1, 1, 1) }; }

        /// <summary>
        /// Returns the translation matrix of this Transform.
        /// </summary>
        public Matrix4 TranslationMatrix { get => Matrix4.CreateTranslation(position); }

        /// <summary>
        /// Returns the rotation matrix of this transform.
        /// </summary>
        public Matrix4 RotationMatrix { get => Matrix4.CreateFromQuaternion(rotation); }

        /// <summary>
        /// Returns the scale matrix of this transform.
        /// </summary>
        public Matrix4 ScaleMatrix { get => Matrix4.CreateScale(scale); }

        /// <summary>
        /// Returns the product of the rotation, scale, and translation matrices.
        /// Represents the whole transformation.
        /// </summary>
        public Matrix4 Matrix { get => RotationMatrix * ScaleMatrix * TranslationMatrix; }

        /// <summary>
        /// The local right vector.
        /// </summary>
        public Vector3 Right { get => (RotationMatrix * new Vector4(-1, 0, 0, 0)).Xyz; }

        /// <summary>
        /// The local up vector.
        /// </summary>
        public Vector3 Up { get => (RotationMatrix * new Vector4(0, 1, 0, 0)).Xyz; }

        /// <summary>
        /// The local forward vector.
        /// </summary>
        public Vector3 Forward { get => (RotationMatrix * new Vector4(0, 0, 1, 0)).Xyz; }

        /// <summary>
        /// The position component of this Transform.
        /// </summary>
        public Vector3 position=new Vector3(0,0,0);

        /// <summary>
        /// The rotation component of this Transform.
        /// </summary>
        public Quaternion rotation=Quaternion.Identity;

        /// <summary>
        /// The scale component of this Transform.
        /// </summary>
        public Vector3 scale=new Vector3(1,1,1);

        /// <summary>
        /// Rotates the Transform relative to itself.
        /// </summary>
        /// <param name="rotation"></param>
        public void Rotate(Quaternion rotation)
        {
            this.rotation = rotation * this.rotation;
        }

        /// <summary>
        /// Rotates the Transform relative to itself.
        /// </summary>
        /// <param name="rotation"></param>
        public void Rotate(Vector3 rotation)
        {
            this.rotation = Quaternion.FromEulerAngles(MathHelper.DegreesToRadians(rotation.X), MathHelper.DegreesToRadians(rotation.Y), MathHelper.DegreesToRadians(rotation.Z)) * this.rotation;
        }

        /// <summary>
        /// Rotates the Transform relative to itself.
        /// </summary>
        /// <param name="rotation"></param>
        public void Rotate(float x, float y, float z)
        {
            rotation = Quaternion.FromEulerAngles(MathHelper.DegreesToRadians(x), MathHelper.DegreesToRadians(y), MathHelper.DegreesToRadians(z)) * rotation;
        }
        
    }
}
