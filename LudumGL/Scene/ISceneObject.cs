using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudumGL.Scene
{
    public interface ISceneObject
    {
        /// <summary>
        /// The unique ID of this object.
        /// </summary>
        int Id { get; set; }
    }
}
