Shader "Dynamic surface" { 
	Properties { 
		_Tex0("Texture", 2D) = "white" {}
	}
	SubShader {
		Tags {
			"Queue" = "Geometry"
			"RenderType" = "Opaque"
		}

		CGPROGRAM 
		#pragma surface surf Lambert vertex:vert 
		#include "UnityCG.cginc"

		sampler2D _Tex0;

		struct appdata{
			float4 vertex    : POSITION;  // The vertex position in model space.
			float3 normal    : NORMAL;    // The vertex normal in model space.
			float4 texcoord  : TEXCOORD0; // The first UV coordinate.
			float4 texcoord1 : TEXCOORD1; // The second UV coordinate.
			float4 texcoord2 : TEXCOORD2; // The third UV coordinate.
			float4 tangent   : TANGENT;   // The tangent vector in Model Space (used for normal mapping).
			float4 color     : COLOR;     // Per-vertex color.
		};

		struct Input{
			float2 uv_Tex0;
			float3 viewDir;
			float3 worldPos;
			float3 worldRefl;
			float3 worldNormal;
			float4 screenPos;
			float4 color : COLOR;

			INTERNAL_DATA
		};

		void vert (inout appdata_full v, out Input data){
			UNITY_INITIALIZE_OUTPUT(Input,data);
		}

		void surf (Input IN, inout SurfaceOutput o) {
			o.Albedo = tex2D(_Tex0, float2((IN.uv_Tex0 + (_Time).x).x, (IN.uv_Tex0 + (_Time).x).y * 100)).rgb;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
