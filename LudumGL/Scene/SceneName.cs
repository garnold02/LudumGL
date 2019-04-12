using System;

namespace LudumGL.Scene
{
    /// <summary>
    /// Attribute used to specify the name of a field/property
    /// used in scene saving and loading.
    /// </summary>
    class SceneName : Attribute
    {
        internal string name;
        public SceneName(string name)
        {
            this.name = name;
        }
    }
}
