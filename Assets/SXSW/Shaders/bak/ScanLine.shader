// Shader created with Shader Forge v1.33 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.33;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:1,x:33430,y:32397,varname:node_1,prsc:2|normal-4935-OUT,emission-166-OUT,voffset-140-OUT;n:type:ShaderForge.SFN_Subtract,id:18,x:32114,y:32340,varname:node_18,prsc:2|A-22-OUT,B-19-OUT;n:type:ShaderForge.SFN_Vector1,id:19,x:31935,y:32422,varname:node_19,prsc:2,v1:1;n:type:ShaderForge.SFN_Abs,id:21,x:32286,y:32340,varname:node_21,prsc:2|IN-18-OUT;n:type:ShaderForge.SFN_Frac,id:22,x:31935,y:32288,varname:node_22,prsc:2|IN-24-OUT;n:type:ShaderForge.SFN_Panner,id:23,x:31597,y:32288,varname:node_23,prsc:2,spu:0.25,spv:0|UVIN-5169-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:24,x:31764,y:32288,varname:node_24,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-23-UVOUT;n:type:ShaderForge.SFN_Multiply,id:25,x:32461,y:32390,cmnt:Triangle Wave,varname:node_25,prsc:2|A-21-OUT,B-26-OUT;n:type:ShaderForge.SFN_Vector1,id:26,x:32286,y:32476,varname:node_26,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Power,id:133,x:32665,y:32453,cmnt:Panning gradient,varname:node_133,prsc:2|VAL-25-OUT,EXP-8547-OUT;n:type:ShaderForge.SFN_NormalVector,id:139,x:32892,y:32957,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:140,x:33119,y:32787,varname:node_140,prsc:2|A-1924-OUT,B-142-OUT,C-139-OUT;n:type:ShaderForge.SFN_ValueProperty,id:142,x:32892,y:32789,ptovrint:False,ptlb:Bulge Scale,ptin:_BulgeScale,varname:_BulgeScale,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.01;n:type:ShaderForge.SFN_Lerp,id:149,x:33119,y:32115,varname:node_149,prsc:2|A-151-RGB,B-8608-OUT,T-133-OUT;n:type:ShaderForge.SFN_Lerp,id:150,x:32892,y:32285,varname:node_150,prsc:2|A-267-RGB,B-265-OUT,T-133-OUT;n:type:ShaderForge.SFN_Tex2d,id:151,x:32892,y:31949,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:_Diffuse,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b66bceaf0cc0ace4e9bdc92f14bba709,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:166,x:33119,y:32619,cmnt:Glow,varname:node_166,prsc:2|A-168-RGB,B-8677-OUT,C-1924-OUT;n:type:ShaderForge.SFN_Color,id:168,x:32892,y:32453,ptovrint:False,ptlb:Glow Color,ptin:_GlowColor,varname:_GlowColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Vector3,id:265,x:32665,y:32301,varname:node_265,prsc:2,v1:0,v2:0,v3:1;n:type:ShaderForge.SFN_Tex2d,id:267,x:32665,y:32133,ptovrint:False,ptlb:Normals,ptin:_Normals,varname:_Normals,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:bbab0a6f7bae9cf42bf057d8ee2755f6,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Vector1,id:4921,x:33119,y:32283,varname:node_4921,prsc:2,v1:0;n:type:ShaderForge.SFN_Normalize,id:4935,x:33119,y:32451,varname:node_4935,prsc:2|IN-150-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8547,x:32461,y:32537,ptovrint:False,ptlb:Bulge Shape,ptin:_BulgeShape,varname:_BulgeShape,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Vector1,id:8608,x:32892,y:32117,varname:node_8608,prsc:2,v1:0.5;n:type:ShaderForge.SFN_ValueProperty,id:8677,x:32892,y:32621,ptovrint:False,ptlb:Glow Intensity,ptin:_GlowIntensity,varname:_GlowIntensity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1.2;n:type:ShaderForge.SFN_TexCoord,id:5169,x:31434,y:32288,varname:node_5169,prsc:2,uv:0;n:type:ShaderForge.SFN_Relay,id:1924,x:32892,y:32697,varname:node_1924,prsc:2|IN-133-OUT;proporder:151-267-168-142-8547-8677;pass:END;sub:END;*/

Shader "SHIPS/Shaders/ScanLine" {
    Properties {
        _Diffuse ("Diffuse", 2D) = "white" {}
        _Normals ("Normals", 2D) = "bump" {}
        _GlowColor ("Glow Color", Color) = (1,1,1,1)
        _BulgeScale ("Bulge Scale", Float ) = 0.01
        _BulgeShape ("Bulge Shape", Float ) = 1
        _GlowIntensity ("Glow Intensity", Float ) = 1.2
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _BulgeScale;
            uniform float4 _GlowColor;
            uniform sampler2D _Normals; uniform float4 _Normals_ST;
            uniform float _BulgeShape;
            uniform float _GlowIntensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float3 tangentDir : TEXCOORD2;
                float3 bitangentDir : TEXCOORD3;
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 node_7849 = _Time + _TimeEditor;
                float node_133 = pow((abs((frac((o.uv0+node_7849.g*float2(0.25,0)).r)-1.0))*0.5),_BulgeShape); // Panning gradient
                float node_1924 = node_133;
                v.vertex.xyz += (node_1924*_BulgeScale*v.normal);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 _Normals_var = UnpackNormal(tex2D(_Normals,TRANSFORM_TEX(i.uv0, _Normals)));
                float4 node_7849 = _Time + _TimeEditor;
                float node_133 = pow((abs((frac((i.uv0+node_7849.g*float2(0.25,0)).r)-1.0))*0.5),_BulgeShape); // Panning gradient
                float3 normalLocal = normalize(lerp(_Normals_var.rgb,float3(0,0,1),node_133));
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
////// Lighting:
////// Emissive:
                float node_1924 = node_133;
                float3 emissive = (_GlowColor.rgb*_GlowIntensity*node_1924);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _BulgeScale;
            uniform float _BulgeShape;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_9996 = _Time + _TimeEditor;
                float node_133 = pow((abs((frac((o.uv0+node_9996.g*float2(0.25,0)).r)-1.0))*0.5),_BulgeShape); // Panning gradient
                float node_1924 = node_133;
                v.vertex.xyz += (node_1924*_BulgeScale*v.normal);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #include "UnityCG.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _BulgeScale;
            uniform float4 _GlowColor;
            uniform float _BulgeShape;
            uniform float _GlowIntensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_5422 = _Time + _TimeEditor;
                float node_133 = pow((abs((frac((o.uv0+node_5422.g*float2(0.25,0)).r)-1.0))*0.5),_BulgeShape); // Panning gradient
                float node_1924 = node_133;
                v.vertex.xyz += (node_1924*_BulgeScale*v.normal);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 node_5422 = _Time + _TimeEditor;
                float node_133 = pow((abs((frac((i.uv0+node_5422.g*float2(0.25,0)).r)-1.0))*0.5),_BulgeShape); // Panning gradient
                float node_1924 = node_133;
                o.Emission = (_GlowColor.rgb*_GlowIntensity*node_1924);
                
                float3 diffColor = float3(0,0,0);
                o.Albedo = diffColor;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
