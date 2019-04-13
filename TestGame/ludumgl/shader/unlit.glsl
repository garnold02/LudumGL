#version 440

out vec4 FragColor;

in vec4 localPos;
in vec4 normal;
in vec4 uv;

uniform vec4 albedo;
uniform sampler2D tex0;
uniform vec2 tiling;
uniform bool useTex;

void main() {
    vec4 textureCol=texture(tex0, uv.xy*tiling);
    if(!useTex) textureCol=vec4(1,1,1,1);
    FragColor=textureCol * albedo;
}