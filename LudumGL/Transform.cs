#pragma warning disable CS0649
using System;
using OpenTK;
using LudumGL.Scene;

namespace LudumGL
{
    /// <summary>
    /// Represents a linear transformation.
    /// </summary>
    public class Transform : ISceneObject
    {
        public int Id { get; set; }

        /// <summary>
        /// Returns the identity transformation.
        /// </summary>
        public static Transform Identity { get => new Transform() { localPosition = new Vector3(0, 0, 0), localRotation = Quaternion.Identity, localScale = new Vector3(1, 1, 1) }; }

        [SceneData]
        public Transform Parent { get; set; } = null;

        /// <summary>
        /// Returns the translation matrix of this Transform.
        /// </summary>
        public Matrix4 TranslationMatrix
        {
            get
            {
                if (Parent == null) return LocalTranslationMatrix;
                Vector4 rotatedLocal =  new Vector4(localPosition) * Parent.RotationMatrix;
                return (Matrix4.CreateTranslation(Parent.ScaleMatrix.ExtractScale() * rotatedLocal.Xyz)) * Parent.TranslationMatrix;
            }
        }

        /// <summary>
        /// Returns the rotation matrix of this transform.
        /// </summary>
        public Matrix4 RotationMatrix
        {
            get
            {
                if (Parent == null) return LocalRotationMatrix;
                return LocalRotationMatrix * Parent.RotationMatrix;
            }
        }

        /// <summary>
        /// Returns the scale matrix of this transform.
        /// </summary>
        public Matrix4 ScaleMatrix
        {
            get
            {
                if (Parent == null) return LocalScaleMatrix;
                return Parent.ScaleMatrix * Matrix4.CreateScale(localScale);
            }
        }

        /// <summary>
        /// Returns the product of the rotation, scale, and translation matrices.
        /// Represents the whole transformation.
        /// </summary>
        public Matrix4 Matrix
        {
            get
            {
                if (Parent == null) return LocalTranslationMatrix;
                return RotationMatrix * ScaleMatrix * TranslationMatrix;
            }
            set
            {
                if (Parent != null) return;
                localPosition = value.ExtractTranslation();
                localRotation = value.ExtractRotation();
                localScale = value.ExtractScale();
            }
        }

        public Vector3 Position { get => TranslationMatrix.ExtractTranslation(); }
        public Quaternion Rotation { get { if (Parent == null) return localRotation; else return localRotation * Parent.Rotation; } }
        public Vector3 Scale { get => ScaleMatrix.ExtractScale(); }


        /// <summary>
        /// Returns the translation matrix of this Transform (local).
        /// </summary>
        public Matrix4 LocalTranslationMatrix { get => Matrix4.CreateTranslation(localPosition); }

        /// <summary>
        /// Returns the rotation matrix of this transform (local).
        /// </summary>
        public Matrix4 LocalRotationMatrix { get => Matrix4.CreateFromQuaternion(localRotation); }

        /// <summary>
        /// Returns the scale matrix of this transform (local).
        /// </summary>
        public Matrix4 LocalScaleMatrix { get => Matrix4.CreateScale(localScale); }

        /// <summary>
        /// Returns the product of the rotation, scale, and translation matrices.
        /// Represents the whole transformation (local).
        /// </summary>
        public Matrix4 LocalMatrix { get => RotationMatrix * ScaleMatrix * TranslationMatrix; }

        /// <summary>
        /// The local right vector.
        /// </summary>
        public Vector3 Right { get => (RotationMatrix * new Vector4(1, 0, 0, 0)).Xyz; }

        /// <summary>
        /// The local up vector.
        /// </summary>
        public Vector3 Up { get => (RotationMatrix * new Vector4(0, 1, 0, 0)).Xyz; }

        /// <summary>
        /// The local forward vector.
        /// </summary>
        public Vector3 Forward { get => (RotationMatrix * new Vector4(0, 0, -1, 0)).Xyz; }

        /// <summary>
        /// The position component of this Transform.
        /// </summary>
        [SceneData]
        public Vector3 localPosition=new Vector3(0,0,0);

        /// <summary>
        /// The rotation component of this Transform.
        /// </summary>
        [SceneData]
        public Quaternion localRotation=Quaternion.Identity;

        /// <summary>
        /// The scale component of this Transform.
        /// </summary>
        [SceneData]
        public Vector3 localScale=new Vector3(1,1,1);

        /// <summary>
        /// Rotates the Transform relative to itself.
        /// </summary>
        /// <param name="rotation"></param>
        public void Rotate(Quaternion rotation)
        {
            this.localRotation = rotation * this.localRotation;
        }

        /// <summary>
        /// Rotates the Transform relative to itself.
        /// </summary>
        /// <param name="rotation"></param>
        public void Rotate(Vector3 rotation)
        {
            this.localRotation = Quaternion.FromEulerAngles(MathHelper.DegreesToRadians(rotation.X), MathHelper.DegreesToRadians(rotation.Y), MathHelper.DegreesToRadians(rotation.Z)) * this.localRotation;
        }

        /// <summary>
        /// Rotates the Transform relative to itself.
        /// </summary>
        /// <param name="rotation"></param>
        public void Rotate(float x, float y, float z)
        {
            localRotation = Quaternion.FromEulerAngles(MathHelper.DegreesToRadians(x), MathHelper.DegreesToRadians(y), MathHelper.DegreesToRadians(z)) * localRotation;
        }
        
    }
}
