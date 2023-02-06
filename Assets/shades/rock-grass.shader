Shader "Tuturial/MaskShader3"
{
    Properties
    {
        _MainTexture("Main Texture", 2D) = "white" {}
        _OverlayTexture("Overlay texture", 2D) = "black" {}
        _Direction("Coveragw Direction", Vector) = (0,1,0)
        _Intensity("Intensity", Range(0, 1)) = 1
    }

    SubShader
    {
        Pass
        {
            CGPROGRAM

            #pragma vertex vertexFunc
            #pragma fragment fragmentFunc

            #include "UnityCG.cginc"

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 normal: NORMAL;
                float2 uv_Main : TEXCOORD0;
                float2 uv_Overlay : TEXCOORD1;
            };

            sampler2D _MainTexture;
            float4 _MainTexture_ST;
            sampler2D _OverlayTexture;
            float4 _OverlayTexture_ST;

            v2f vertexFunc(appdata_full v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv_Main = TRANSFORM_TEX(v.texcoord, _MainTexture);
                o.uv_Overlay = TRANSFORM_TEX(v.texcoord, _OverlayTexture);
                o.normal = mul(unity_ObjectToWorld, v.normal);

                return o;
            }

            float3 _Direction;
            fixed _Intensity;

            fixed4 fragmentFunc(v2f i) : SV_Target
            {
                fixed dir = dot(normalize(i.normal), _Direction);

                if(dir < 1 - _Intensity)
                {
                    dir = 0;
                }

                fixed4 tex1 = tex2D(_MainTexture, i.uv_Main);
                fixed4 tex2 = tex2D(_OverlayTexture, i.uv_Overlay);

                return lerp(tex1, tex2, dir);
            }

            ENDCG
        }
    }
}
