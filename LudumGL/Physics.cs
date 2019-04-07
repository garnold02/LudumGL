using System;
using System.Collections.Generic;
using OpenTK;
using BEPUphysics;
using BEPUphysics.Entities;
using BEPUphysics.BroadPhaseEntries.MobileCollidables;
using LudumGL.Components;

namespace LudumGL
{
    /// <summary>
    /// Everything related to physics.
    /// </summary>
    public class Physics
    {
        internal static Space space;
        internal static Dictionary<Entity, PhysicsBody> entityBodies;

        /// <summary>
        /// Gravity affects all PhysicsBodies in the scene.
        /// </summary>
        public static Vector3 Gravity { get; set; } = new Vector3(0, -10, 0);

        internal static void Initialize()
        {
            space = new Space();
            entityBodies = new Dictionary<Entity, PhysicsBody>();
        }

        internal static void AddEntity(Entity entity, PhysicsBody body)
        {
            if (entityBodies.ContainsKey(entity)) return;
            space.Add(entity);
            entityBodies.Add(entity, body);
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

        /// <summary>
        /// Casts a ray in the world and returns
        /// data about the first object it hits.
        /// </summary>
        /// <param name="ray"></param>
        public static bool Raycast(Ray ray)
        {
            BEPUutilities.Ray bepuRay;
            bepuRay.Position = VectorT2B(ray.Origin);
            bepuRay.Direction = VectorT2B(ray.Direction);
            return space.RayCast(bepuRay, ray.Length, out RayCastResult result);
        }

        public static bool Raycast(Ray ray, out RaycastData data)
        {
            BEPUutilities.Ray bepuRay;
            bepuRay.Position = VectorT2B(ray.Origin);
            bepuRay.Direction = VectorT2B(ray.Direction);
            bool hit = space.RayCast(bepuRay, ray.Length, out RayCastResult result);

            Entity resultEntity = null;
            if(result.HitObject is EntityCollidable)
                resultEntity = ((EntityCollidable)result.HitObject).Entity;
            PhysicsBody resultBody = null;
            if(resultEntity!=null)
            {
                if (entityBodies.ContainsKey(resultEntity))
                    resultBody = entityBodies[resultEntity];
            }

            data = new RaycastData
            {
                position = VectorB2T(result.HitData.Location),
                normal = VectorB2T(result.HitData.Normal),
                body = resultBody
            };
            return hit;
        }
    }
}
