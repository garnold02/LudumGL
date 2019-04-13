using System;

namespace LudumGL.Scene
{
    public interface ISceneResource
    {
        int Id { get; set; }
        string Path { get; }
    }
}
