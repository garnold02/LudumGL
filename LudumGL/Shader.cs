using System;
using System.IO;
using OpenTK.Graphics.OpenGL;

namespace LudumGL
{
    public class Shader
    {
        public string Code { get; set; }
        public ShaderType Type { get; }
        public Shader(string from, bool raw, ShaderType type)
        {
            Type = type;
            if(raw)
            {
                Code = from;
            }
            else
            {
                Code = File.ReadAllText(from);
            }
        }
    }
}
