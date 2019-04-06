using System;
using OpenTK;
using BEPUphysics;

namespace LudumGL
{
    /// <summary>
    /// Everything related to physics.
    /// </summary>
    class Physics
    {
        internal static Space space;
        internal static void Initialize()
        {
            space = new Space();
        }
        internal static void Update(float delta)
        {
            space.Update(delta);
        }

        internal static Vector3 VectorB2T(BEPUutilities.Vector3 vector)
        {
            return new Vector3(vector.X, vector.Y, vector.Z);
        }

        internal static BEPUutilities.Vector3 VectorT2B(Vector3 vector)
        {
            return new BEPUutilities.Vector3(vector.X, vector.Y, vector.Z);
        }

        internal static Quaternion QuaternionB2T(BEPUutilities.Quaternion quaternion)
        {
            return new Quaternion(quaternion.X, quaternion.Y, quaternion.Z, quaternion.W);
        }

        internal static BEPUutilities.Quaternion QuaternionT2B(Quaternion quaternion)
        {
            return new BEPUutilities.Quaternion(quaternion.X, quaternion.Y, quaternion.Z, quaternion.W);
        }
    }
}
