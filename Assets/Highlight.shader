Shader "Unlit/Highlight"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        [HDR]
        _Color   ("Color", Color) = (1,1,1,1)
        [HDR]
        _HLColor ("HLColor", Color) = (1,1,1,1)
        _HLPower ("HLPower", float) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 1

        Pass
        {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag


            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 viewDir : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color;
            fixed4 _HLColor;
            half   _HLPower;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                float4x4 modelMatrix = unity_ObjectToWorld;
                o.normalDir = normalize(UnityObjectToWorldNormal(v.normal));
                o.viewDir = normalize(_WorldSpaceCameraPos - mul(modelMatrix, v.vertex).xyz);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv) * _Color;

                half hl = 1.0 - abs(dot(i.viewDir, i.normalDir));
                fixed3 emission = _HLColor.rgb * pow(hl, _HLPower) * _HLPower;
                col.rgb += emission;
                col = fixed4(col.rgb, 1.0);

                return col;
            }
            ENDCG
        }

        // Pass to render object as a shadow caster
		Pass 
		{
			Name "Highlight"
			Tags { "LightMode" = "ShadowCaster" }
	
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_shadowcaster
			#include "UnityCG.cginc"
	
			struct v2f 
			{ 
				V2F_SHADOW_CASTER;
			};
	
			v2f vert( appdata_base v )
			{
				v2f o;
				TRANSFER_SHADOW_CASTER(o)
				return o;
			}
	
			float4 frag( v2f i ) : COLOR
			{
				SHADOW_CASTER_FRAGMENT(i)
			}
			ENDCG
		}
	}
}
