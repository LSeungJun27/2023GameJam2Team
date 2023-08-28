Shader "Unlit/FireSlime"
{
    Properties
    {
        [HDR] [MainColor] _BaseColor("BaseColor", Color) = (1,1,1,1)
        [HDR] _RimColor("RimColor",Color) = (1,1,1,1)
        [HDR] _OutlineColor("OutlineColor",Color) = (1,1,1,1)
        //[MainTexture] _BaseMap("BaseMap", 2D) = "white" {}
    }

    // Universal Render Pipeline subshader. If URP is installed this will be used.
    SubShader
    {
        Tags { "RenderType"="Opaque" "RenderPipeline"="UniversalRenderPipeline"}

        Pass
        {
            Tags { "LightMode"="UniversalForward" }

            HLSLPROGRAM
            #pragma vertex FireSlimePassVertex
            #pragma fragment FireSlimePassFragment
            
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
            
            //CBUFFER_START(UnityPerMaterial)
            //float4 _BaseMap_ST;
            half4 _BaseColor;
            half4 _RimColor;
            half4 _OutlineColor;
            //CBUFFER_END

            Varyings FireSlimePassVertex(Attributes input)
            {
                Varyings output;
                output.positionHCS = TransformObjectToHClip(input.positionOS.xyz);
                output.uv = input.uv;//TRANSFORM_TEX(input.uv, _BaseMap);
                output.normalWS = TransformObjectToWorldNormal(input.normalOS);
                output.viewDir = GetWorldSpaceViewDir(TransformObjectToWorld(input.positionOS));
                return output;
            }

            half4 FireSlimePassFragment(Varyings input) : SV_Target
            {
                input.normalWS = normalize(input.normalWS);
                input.viewDir = normalize(input.viewDir);
                float rim = 1- dot(input.normalWS,input.viewDir);
                float outline = step(0.4f,rim);
                rim += 0.4f;
                return half4(outline.xxx,1)*_OutlineColor+half4((1-outline)*rim.xxx,1) *_RimColor+half4((1-outline)*(1-rim.xxx),1)*_BaseColor;
            }
            ENDHLSL
        }
    }
}
