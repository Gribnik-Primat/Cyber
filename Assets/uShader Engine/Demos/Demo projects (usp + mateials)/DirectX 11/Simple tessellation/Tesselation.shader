Shader "Tesselation" { 
	Properties { 
		_Tex0("Main", 2D) = "white" {}
		_Tex1("Normal", 2D) = "white" {}
		_TessMultiplier("Polygons multiplier", float) = 24
		_Displacement("Displacement", float) = 0.07
		_DispMap("Displacment map", 2D) = "white" {}
	}
	SubShader {
		Tags {
			"Queue" = "Geometry"
			"RenderType" = "Opaque"
		}

		CGPROGRAM 
		#pragma surface surf Lambert vertex:vert tessellate:tessDistance 
		#include "UnityCG.cginc"
		#include "Tessellation.cginc"

		sampler2D _Tex0;
		sampler2D _Tex1;
		float _TessMultiplier;
		float _Displacement;
		sampler2D _DispMap;
		uniform float4 _DispMap_ST;

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
			float2 texcoord : TEXCOORD0;
			float2 texcoord1 : TEXCOORD1;
			float2 uv_Tex0;
			float2 uv_Tex1;
			float3 viewDir;
			float3 worldPos;
			float3 worldRefl;
			float3 worldNormal;
			float4 screenPos;
			float4 color : COLOR;

			INTERNAL_DATA
		};

		float4 tessDistance (appdata v0, appdata v1, appdata v2) {
			float minDist = 10.0;
			float maxDist = 25.0;
			return UnityDistanceBasedTess(v0.vertex, v1.vertex, v2.vertex, minDist, maxDist, _TessMultiplier);

		}


		void vert (inout appdata v){
			float disp = tex2Dlod(_DispMap, float4(v.texcoord.xy,0,0) * _DispMap_ST * 1).r * _Displacement;
			v.vertex.xyz += v.normal * disp;
		}

		void surf (Input IN, inout SurfaceOutput o) {
			o.Albedo = tex2D(_Tex0, IN.uv_Tex0 * 1).rgb;
			o.Normal = UnpackNormal(tex2D(_Tex1, IN.uv_Tex1 * 1));
		}
		ENDCG
	}
	FallBack "Diffuse"
}
