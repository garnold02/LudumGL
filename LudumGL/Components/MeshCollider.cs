using OpenTK;
using BEPUphysics.BroadPhaseEntries.MobileCollidables;
using BEPUphysics.CollisionShapes;
using BEPUphysics.CollisionShapes.ConvexShapes;
using bepu = BEPUutilities;
using LudumGL.Scene;

namespace LudumGL.Components
{
    public class MeshCollider : Collider
    {
        [SceneData]
        public Mesh Mesh { get; set; }
        public MeshCollider(Mesh mesh) : base()
        {
            Mesh = mesh;
            bepu.Vector3[] vertices = new bepu.Vector3[Mesh.vertices.Length];

            for (int i = 0; i < Mesh.vertices.Length; i++)
            {
                vertices[i] = Physics.VectorT2B(Mesh.vertices[i].Xyz);
            }
            shape = new ConvexHullShape(vertices);
        }

        public override void Update()
        {

            base.Update();
        }
    }
}
