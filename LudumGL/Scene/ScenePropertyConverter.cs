using System;
using System.Globalization;
using OpenTK;

namespace LudumGL.Scene
{
    class ScenePropertyConverter
    {
        static readonly string SEPARATOR = "/";
        static readonly NumberFormatInfo numberFormatInfo = new NumberFormatInfo { NumberDecimalSeparator = "." };

        #region ConvertTo
        /// <summary>
        /// Returns the string representation of this bool. Used for saving.
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static string ToSceneProperty(bool b)
        {
            return "bool" + SEPARATOR + b.ToString();
        }

        /// <summary>
        /// Returns the string representation of this float. Used for saving.
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static string ToSceneProperty(float f)
        {
            return "vec1" + SEPARATOR + f.ToString(numberFormatInfo);
        }

        /// <summary>
        /// Returns the string representation of this Vector2.
        /// Used for saving.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static string ToSceneProperty(Vector2 vector)
        {
            return "vec2" + SEPARATOR + vector.X.ToString(numberFormatInfo) + SEPARATOR + vector.Y.ToString(numberFormatInfo);
        }

        /// <summary>
        /// Returns the string representation of this Vector3.
        /// Used for saving.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static string ToSceneProperty(Vector3 vector)
        {
            return "vec3" + SEPARATOR + vector.X.ToString(numberFormatInfo) + SEPARATOR + vector.Y.ToString(numberFormatInfo) + SEPARATOR + vector.Z.ToString(numberFormatInfo);
        }

        /// <summary>
        /// Returns the string representation of this Vector4.
        /// Used for saving.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static string ToSceneProperty(Vector4 vector)
        {
            return "vec4" + SEPARATOR + vector.X.ToString(numberFormatInfo) + SEPARATOR + vector.Y.ToString(numberFormatInfo) + SEPARATOR + vector.Z.ToString(numberFormatInfo) + SEPARATOR + vector.W.ToString(numberFormatInfo);
        }

        /// <summary>
        /// Returns the string representation of this Quaternion.
        /// Used for saving.
        /// </summary>
        /// <param name="quaterion"></param>
        /// <returns></returns>
        public static string ToSceneProperty(Quaternion quaterion)
        {
            return "quat" + SEPARATOR + quaterion.X.ToString(numberFormatInfo) + SEPARATOR + quaterion.Y.ToString(numberFormatInfo) + SEPARATOR + quaterion.Z.ToString(numberFormatInfo) + SEPARATOR + quaterion.W.ToString(numberFormatInfo);
        }

        /// <summary>
        /// Returns the string representation of this Matrix4.
        /// Used for saving.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static string ToSceneProperty(Matrix4 matrix)
        {
            string col1 = matrix.M11.ToString(numberFormatInfo) + SEPARATOR + matrix.M12.ToString(numberFormatInfo) + SEPARATOR + matrix.M13.ToString(numberFormatInfo) + SEPARATOR + matrix.M14.ToString(numberFormatInfo);
            string col2 = matrix.M21.ToString(numberFormatInfo) + SEPARATOR + matrix.M22.ToString(numberFormatInfo) + SEPARATOR + matrix.M23.ToString(numberFormatInfo) + SEPARATOR + matrix.M24.ToString(numberFormatInfo);
            string col3 = matrix.M31.ToString(numberFormatInfo) + SEPARATOR + matrix.M32.ToString(numberFormatInfo) + SEPARATOR + matrix.M33.ToString(numberFormatInfo) + SEPARATOR + matrix.M34.ToString(numberFormatInfo);
            string col4 = matrix.M41.ToString(numberFormatInfo) + SEPARATOR + matrix.M42.ToString(numberFormatInfo) + SEPARATOR + matrix.M43.ToString(numberFormatInfo) + SEPARATOR + matrix.M44.ToString(numberFormatInfo);

            return "mat4" + SEPARATOR + col1 + SEPARATOR + col2 + SEPARATOR + col3 + SEPARATOR + col4;
        }
        #endregion

        #region ConvertFrom
        public static object FromSceneProperty(string sceneProperty)
        {
            string[] tokens = sceneProperty.Split('/');
            switch (tokens[0])
            {
                default:
                    return null;

                case "bool":
                    {
                        return BoolFromProperty(tokens);
                    }
                case "vec1":
                    {
                        return Vector1FromProperty(tokens);
                    }
                case "vec2":
                    {
                        return Vector2FromProperty(tokens);
                    }
                case "vec3":
                    {
                        return Vector3FromProperty(tokens);
                    }
                case "vec4":
                    {
                        return Vector4FromProperty(tokens);
                    }
                case "quat":
                    {
                        return QuaternionFromProperty(tokens);
                    }
                case "mat4":
                    {
                        return MatrixFromProperty(tokens);
                    }
            }
        }

        //Bool
        static bool BoolFromProperty(string[] tokens)
        {
            bool x = bool.Parse(tokens[1]);

            return x;
        }

        //Float
        static float Vector1FromProperty(string[] tokens)
        {
            float x = float.Parse(tokens[1], numberFormatInfo);

            return x;
        }

        //Vector2
        static Vector2 Vector2FromProperty(string[] tokens)
        {
            float x = float.Parse(tokens[1], numberFormatInfo);
            float y = float.Parse(tokens[2], numberFormatInfo);

            return new Vector2(x, y);
        }

        //Vector3
        static Vector3 Vector3FromProperty(string[] tokens)
        {
            float x = float.Parse(tokens[1], numberFormatInfo);
            float y = float.Parse(tokens[2], numberFormatInfo);
            float z = float.Parse(tokens[3], numberFormatInfo);

            return new Vector3(x, y, z);
        }

        //Vector4
        static Vector4 Vector4FromProperty(string[] tokens)
        {
            float x = float.Parse(tokens[1], numberFormatInfo);
            float y = float.Parse(tokens[2], numberFormatInfo);
            float z = float.Parse(tokens[3], numberFormatInfo);
            float w = float.Parse(tokens[4], numberFormatInfo);

            return new Vector4(x, y, z, w);
        }

        //Quaternion
        static Quaternion QuaternionFromProperty(string[] tokens)
        {
            float x = float.Parse(tokens[1], numberFormatInfo);
            float y = float.Parse(tokens[2], numberFormatInfo);
            float z = float.Parse(tokens[3], numberFormatInfo);
            float w = float.Parse(tokens[4], numberFormatInfo);

            return new Quaternion(x, y, z, w);
        }

        //Matrix4
        static Matrix4 MatrixFromProperty(string[] tokens)
        {
            float m11 = float.Parse(tokens[0], numberFormatInfo);
            float m12 = float.Parse(tokens[1], numberFormatInfo);
            float m13 = float.Parse(tokens[2], numberFormatInfo);
            float m14 = float.Parse(tokens[3], numberFormatInfo);

            float m21 = float.Parse(tokens[4], numberFormatInfo);
            float m22 = float.Parse(tokens[5], numberFormatInfo);
            float m23 = float.Parse(tokens[6], numberFormatInfo);
            float m24 = float.Parse(tokens[7], numberFormatInfo);

            float m31 = float.Parse(tokens[8], numberFormatInfo);
            float m32 = float.Parse(tokens[9], numberFormatInfo);
            float m33 = float.Parse(tokens[10], numberFormatInfo);
            float m34 = float.Parse(tokens[11], numberFormatInfo);

            float m41 = float.Parse(tokens[12], numberFormatInfo);
            float m42 = float.Parse(tokens[13], numberFormatInfo);
            float m43 = float.Parse(tokens[14], numberFormatInfo);
            float m44 = float.Parse(tokens[15], numberFormatInfo);

            return new Matrix4(m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44);
        }
        #endregion
    }
}
