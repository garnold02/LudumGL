using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudumGL.Debugging
{
    /// <summary>
    /// Interface describing a debugging tool.
    /// </summary>
    public interface IDebugObject
    {
        void Update();
        void Render();
    }
}
