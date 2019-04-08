using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudumGL.Debugging
{
    public interface IDebugObject
    {
        void Update();
        void Render();
    }
}
