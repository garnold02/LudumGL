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