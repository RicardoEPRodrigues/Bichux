Shader "Unlit/GradientShader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "red" {}
		_Texture2("Texture2",2D) = "black"{}
		_ColorForeground("ColorForeground", Color) = (0, 0, 0, 1)
		_ColorBackground("ColorBackground", Color) = (1, 0, 0, 1)
		_Mult("Mult",Float) = 1.0
		_Sum("Sum", Float) = 1.0

	}
		SubShader
		{
			Tags { "RenderType" = "Opaque" }
			LOD 100

			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				// make fog work
				#pragma multi_compile_fog

				#include "UnityCG.cginc"

				uniform float4 _ColorBackground;
				uniform float4 _ColorForeground;

				uniform Float _Mult;
				uniform Float _Sum;

				struct appdata
				{
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
					float3 normal : NORMAL;
				};
				

				struct v2f
				{
					float2 uv : TEXCOORD0;
					UNITY_FOG_COORDS(1)
					float4 vertex : SV_POSITION;
					float3 normal : NORMAL;
				};

				sampler2D _MainTex;
				float4 _MainTex_ST;
				sampler2D _Texture2;
				float4 _Texture2_ST;

				v2f vert(appdata v)
				{
					v2f o;
					o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
					o.uv = v.uv;//TRANSFORM_TEX(v.uv, _MainTex);
					o.normal = mul(UNITY_MATRIX_MV, v.normal);
					UNITY_TRANSFER_FOG(o,o.vertex);
					return o;
				}

				float4 frag(v2f i) : SV_Target
				{
					// sample the texture
					//float4 col = tex2D(_MainTex, i.uv);
					// apply fog
					//UNITY_APPLY_FOG(i.fogCoord, col);
					//float4 col2 = tex2D(_Texture2, i.uv);
					//col = lerp(col, col2, 0.9);

					float distfromcenter = distance(float2(0.5f, 0.5f), i.uv);
					float4 rColor = lerp(_ColorBackground, _ColorForeground, saturate(log(distfromcenter*_Mult+_Sum)));
					return rColor;
					//return result;
				}
				ENDCG
			}
		}
}
