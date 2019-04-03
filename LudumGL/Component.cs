using System;

namespace LudumGL
{
    abstract class Component
    {
        public GameObject Parent { get; }

        public virtual void Start()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {

        }
    }
}
