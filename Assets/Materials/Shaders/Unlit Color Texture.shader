Shader "Unlit/Unlit Color Texture"
{
    Properties
    {
        [KeywordEnum(Opaque, Alpha, Cutout)] _RenderingType("Rendering Type", Float) = 0
        
        _MainTex ("Texture", 2D) = "white" {}
        [KeywordEnum(Add, Replace)] _ColorType("Color Type", Float) = 0
        _Color ("Color", Color) = (1,1,1,1)
        _AlphaCutoff ("Alpha Cutoff", Range(0.0, 1.0)) = 0.5
        _RotateSpeed ("Rotate Speed", Range(-20.0, 20.0)) = 0

        [Toggle(BILLBOARD)] _Billboard("Billboard", Float) = 0
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Color;
            float _RenderingType;
            float _AlphaCutoff;
            float _ColorType;
            float _Billboard;
            float _RotateSpeed;

            v2f vert (appdata v)
            {
                v2f o;
                if ((int)_Billboard == 1) {
                    o.vertex = mul(UNITY_MATRIX_P, 
                        mul(UNITY_MATRIX_MV, float4(0.0,0.0,0.0,1.0)) 
                            + float4(v.vertex.x, v.vertex.y, 0.0,0.0));


                    v.uv -= 0.5;
                    float sinX = sin (_RotateSpeed * _Time);
                    float cosX = cos (_RotateSpeed * _Time);
                    float sinY = sin (_RotateSpeed * _Time);
                    float2x2 rotMatrix = float2x2(cosX, -sinX, sinY, cosX);
                    rotMatrix *= 0.5;
                    rotMatrix += 0.5;
                    rotMatrix = rotMatrix * 2 - 1;
                    o.uv.xy = mul (v.uv.xy, rotMatrix);
                    o.uv.xy += 0.5;
                } else {
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                }
                
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                if ((int)_ColorType == 0) {
                    col.rgb *= _Color.rgb;
                } else {
                    col.rgb = _Color.rgb;
                }
                
                switch((int)_RenderingType) {
                    case 0: //opaque
                    col.a = 1;
                    break;
                    case 1: //alpha
                    break;
                    default: //alpha cutout
                    clip(col.a - _AlphaCutoff);
                    break;
                }
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
