using System;
using OpenTK.Graphics.OpenGL;

namespace LudumGL
{
    /// <summary>
    /// Contains the source codes of default shaders.
    /// </summary>
    public class Shaders
    {
        /// <summary>
        /// Vertex shader. Transform vertices from world space
        /// to screen space. Must be used always.
        /// </summary>
        public static Shader Projection { get => new Shader(ProjectionCode, true, ShaderType.VertexShader); }

        /// <summary>
        /// Fragment shader. Supports Phong lighting.
        /// </summary>
        public static Shader Lit { get => new Shader(LitCode, true, ShaderType.FragmentShader); }

        /// <summary>
        /// Simple unlit shader with variable color.
        /// </summary>
        public static Shader Unlit { get => new Shader(UnlitCode, true, ShaderType.FragmentShader); }
        #region Code
        static string ProjectionCode { get; } = @"

#version 440

layout (location=0) in vec4 vertex;
layout (location=1) in vec4 norm;
layout (location=2) in vec4 iuv;

uniform mat4 translation;
uniform mat4 rotation;
uniform mat4 scale;
uniform mat4 projection;

out vec4 localPos;
out vec4 normal;
out vec4 uv;

void main() {
    gl_Position=projection*translation*rotation*scale*vertex;
    localPos=vertex;
    normal=norm;
    uv=iuv;
}

        ";

        static string LitCode { get; } = @"

#version 440

struct Light {
    float enabled;
    float type;
    mat4 translation;
    mat4 rotation;
    vec4 color;
    float range;
};

out vec4 FragColor;

in vec4 localPos;
in vec4 normal;
in vec4 uv;

uniform mat4 translation;
uniform mat4 rotation;
uniform mat4 scale;
uniform mat4 projection;
uniform Light lights[10];
uniform vec3 ambient;

uniform sampler2D tex;

void main() {
    vec4 combinedLightColor=vec4(0,0,0,1);
    vec4 worldPos=translation*rotation*scale*localPos;
    for(int i=0; i<10; i++) {
        Light light=lights[i];
        if(light.enabled==0) continue;
        vec4 lightPos=light.translation*vec4(0,0,0,1);
        vec3 normalRot=(rotation*normal).xyz;
        vec3 lightConnection=lightPos.xyz - worldPos.xyz;
        vec3 lightDirection=normalize(lightConnection);
        float lightDistance=length(lightConnection);

        float rangeMod=1-clamp(lightDistance/light.range,0,1);
        if(light.type==1) rangeMod=1;
        float diffuse=clamp(dot(lightDirection,normalRot),0,1);

        vec4 lightColor=light.color*diffuse*rangeMod*light.color.w;
        combinedLightColor+=lightColor;
    }
    FragColor=texture(tex, uv.xy) * vec4(ambient + combinedLightColor.xyz, 1.0);
}

        ";

        static string UnlitCode { get; } = @"

#version 440

out vec4 FragColor;

in vec4 localPos;
in vec4 normal;
in vec4 uv;

uniform vec4 color;

void main() {
    FragColor=color;
}

        ";
        #endregion
    }
}
