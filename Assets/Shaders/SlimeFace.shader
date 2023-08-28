Shader "Unlit/SlimeFace"
{
      Properties
    {
        [MainTexture] _BaseMap("BaseMap", 2D) = "white" {}
    }

    // Universal Render Pipeline subshader. If URP is installed this will be used.
    SubShader
    {
        Tags { "RenderType"="AlphaTest" "RenderPipeline"="UniversalRenderPipeline"}
        
        //Blend SrcAlpha OneMinusSrcAlpha
        
        
        Pass
        {
            Tags { "LightMode"="UniversalForward" }
            
            
            HLSLPROGRAM
            #pragma vertex WaterSlimePassVertex
            #pragma fragment WaterSlimePassFragment
            
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS   : POSITION;
                float2 uv           : TEXCOORD0;
                float3 normalOS : NORMAL;
            };

            struct Varyings
            {
                float2 uv           : TEXCOORD0;
                float4 positionHCS  : SV_POSITION;
                //float3 normalWS : TEXCOORD1;
            };

            TEXTURE2D(_BaseMap);
            SAMPLER(sampler_BaseMap);
            
            CBUFFER_START(UnityPerMaterial)
            float4 _BaseMap_ST;
            CBUFFER_END

            float2 GradientNoiseDir(float2 p)
            {
                p = p % 289;
                float x = (34 * p.x + 1) * p.x % 289 + p.y;
                x = (34 * x + 1) * x % 289;
                x = frac(x / 41) * 2 - 1;
                return normalize(float2(x - floor(x + 0.5), abs(x) - 0.5));
            }

            float GradientNoise(float2 p)
            {
                float2 ip = floor(p);
                float2 fp = frac(p);
                float d00 = dot(GradientNoiseDir(ip), fp);
                float d01 = dot(GradientNoiseDir(ip + float2(0, 1)), fp - float2(0, 1));
                float d10 = dot(GradientNoiseDir(ip + float2(1, 0)), fp - float2(1, 0));
                float d11 = dot(GradientNoiseDir(ip + float2(1, 1)), fp - float2(1, 1));
                fp = fp * fp * fp * (fp * (fp * 6 - 15) + 10);
                return lerp(lerp(d00, d01, fp.y), lerp(d10, d11, fp.y), fp.x)+0.5f;
            }
            
            Varyings WaterSlimePassVertex(Attributes input)
            {
                Varyings output;
                float positionDistortion = min(0,-0.04+0.05f*GradientNoise(input.uv+_Time*1.25))+0.0025f;
                output.positionHCS = TransformObjectToHClip(input.positionOS.xyz+input.normalOS*positionDistortion);
                output.uv = TRANSFORM_TEX(input.uv, _BaseMap);

                return output;
            }

            half4 WaterSlimePassFragment(Varyings input) : SV_Target
            {
                half4 main = SAMPLE_TEXTURE2D(_BaseMap,sampler_BaseMap,input.uv);
                clip(main.a-0.9875f);
                return main;
            }
            ENDHLSL
        }
    }
}
