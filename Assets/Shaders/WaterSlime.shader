Shader "Unlit/WaterSlime"
{
   Properties
    {
        [HDR] [MainColor] _BaseColor("BaseColor", Color) = (1,1,1,1)
        [HDR] _RimColor("RimColor",Color) = (1,1,1,1)
        _DistortionStrength("DistortionStrength",Float) = 1.0
        //[MainTexture] _BaseMap("BaseMap", 2D) = "white" {}
    }

    // Universal Render Pipeline subshader. If URP is installed this will be used.
    SubShader
    {
        Tags { "RenderType"="Transparent" "RenderPipeline"="UniversalRenderPipeline"}
        

        
        Pass
        {
            Tags { "LightMode"="UniversalForward" }
    
            Blend SrcAlpha OneMinusSrcAlpha
            
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
                float3 normalWS : TEXCOORD1;
                float3 viewDir : TEXCOORD2;
            };

            //TEXTURE2D(_BaseMap);
            //SAMPLER(sampler_BaseMap);
            
            CBUFFER_START(UnityPerMaterial)
            //float4 _BaseMap_ST;
            half4 _BaseColor;
            half4 _RimColor;
            float _DistortionStrength;
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

                float positionDistortion = min(0,-0.04+0.05f*GradientNoise(input.uv+_Time*1.25));
                
                output.positionHCS = TransformObjectToHClip(input.positionOS.xyz+input.normalOS*positionDistortion*_DistortionStrength);
                output.uv = input.uv;//TRANSFORM_TEX(input.uv, _BaseMap);
                output.normalWS = TransformObjectToWorldNormal(input.normalOS);
                output.viewDir = GetWorldSpaceViewDir(TransformObjectToWorld(input.positionOS));
                return output;
            }

            half4 WaterSlimePassFragment(Varyings input) : SV_Target
            {
                input.normalWS = normalize(input.normalWS);
                input.viewDir = normalize(input.viewDir);
                float rim = 1- dot(input.normalWS,input.viewDir);
                rim *= rim;
                return half4(rim.xxx,1) *_RimColor+half4((1-rim.xxx),1)*_BaseColor;
            }
            ENDHLSL
        }
        Pass
        {
            Name "ShadowCaster"
            Tags{"LightMode" = "ShadowCaster"}

            ZWrite On
            ZTest LEqual
            ColorMask 0

            HLSLPROGRAM
            #pragma exclude_renderers gles gles3 glcore
            #pragma target 4.5

            // -------------------------------------
            // Material Keywords
            #pragma shader_feature_local_fragment _ALPHATEST_ON
            #pragma shader_feature_local_fragment _GLOSSINESS_FROM_BASE_ALPHA

            //--------------------------------------
            // GPU Instancing
            #pragma multi_compile_instancing
            #pragma multi_compile _ DOTS_INSTANCING_ON

            // -------------------------------------
            // Universal Pipeline keywords

            // This is used during shadow map generation to differentiate between directional and punctual light shadows, as they use different formulas to apply Normal Bias
            #pragma multi_compile_vertex _ _CASTING_PUNCTUAL_LIGHT_SHADOW

            #pragma vertex ShadowPassVertex
            #pragma fragment ShadowPassFragment

            #include "Packages/com.unity.render-pipelines.universal/Shaders/SimpleLitInput.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/Shaders/ShadowCasterPass.hlsl"
            ENDHLSL
        }
    }
}
