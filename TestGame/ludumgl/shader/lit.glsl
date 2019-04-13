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

uniform vec4 albedo;
uniform sampler2D tex0;
uniform vec2 tiling;
uniform bool useTex;

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
        if(light.type==1) {
            rangeMod=1;
            lightDirection=(light.rotation*vec4(0,0,1,0)).xyz;
        }
        float diffuse=clamp(dot(lightDirection,normalRot),0,1);

        vec4 lightColor=light.color*diffuse*rangeMod*light.color.w;
        combinedLightColor+=lightColor;
    }
    vec4 textureCol=texture(tex0, uv.xy*tiling);
    if(!useTex) textureCol=vec4(1,1,1,1);
    FragColor=textureCol * albedo * vec4(ambient + combinedLightColor.xyz, 1.0);
}