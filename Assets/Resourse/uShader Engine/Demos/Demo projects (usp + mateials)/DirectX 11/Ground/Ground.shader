Shader "uSE\Ground Tess" { 
	Properties { 
		[Header (Tessellation config)]_TessMultiplier_("Polygons multiplier", float) = 60
		_Displacement_("Displacement", float) = 0.03
		[Header (Textures and Bumpmaps)]_Main("Main", 2D) = "white" {}
		_Ramp("Ramp", 2D) = "white" {}
		_Normal("Normal", 2D) = "white" {}
		_AO("AO", 2D) = "white" {}
		_DispMap("DispMap", 2D) = "white" {}
		[Header (Colors)]_Maintint("Main tint", Color) = (1,1,1,1)
		_Metallic("Metallic", Color) = (1,1,1,1)
		[Header (Variables)]_Scale("Scale", float) = 10
		_Brighness("Brighness", float) = 0.6
		_AOpower("AO power", float) = 0.4
	}
	SubShader {
		LOD 300
		Tags {
			"Queue" = "Geometry"
			"RenderType" = "Opaque"
		}

		Cull Off
		ColorMask   RGBA

		CGPROGRAM 
		#pragma surface surf Standard vertex:vert tessellate:tess 
		#include "UnityCG.cginc"
		#include "Tessellation.cginc"

		sampler2D _Main;
		sampler2D _Ramp;
		sampler2D _Normal;
		sampler2D _AO;
		sampler2D _DispMap;
		float4 _Maintint;
		float4 _Metallic;
		float _Scale;
		float _Brighness;
		float _AOpower;
		float _TessMultiplier_;
		float _Displacement_;
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
			float2 uv_Main;
			float2 uv_Ramp;
			float2 uv_Normal;
			float2 uv_AO;
			float3 viewDir;
			float3 worldPos;
			float3 worldRefl;
			float3 worldNormal;
			float4 screenPos;
			float4 color : COLOR;

			INTERNAL_DATA
		};

		float4 tess (appdata v0, appdata v1, appdata v2) {
			float minDist = 10.0;
			float maxDist = 25.0;
			return UnityDistanceBasedTess(v0.vertex, v1.vertex, v2.vertex, minDist, maxDist, _TessMultiplier_);

		}

		void vert (inout appdata v){
			float disp = (tex2Dlod(_DispMap, float4(v.texcoord.x, v.texcoord.y, 1.0f, 0) * _Scale)).r * _Displacement_;
			v.vertex.xyz += v.normal * disp;
		}

		void surf (Input IN, inout SurfaceOutputStandard o) {
			o.Albedo = lerp(_Maintint.rgb * tex2D(_Main, IN.uv_Main * _Scale).rgb * _Brighness, _Maintint.rgb * tex2D(_Main, IN.uv_Main * _Scale).rgb * _Brighness * tex2D(_AO, IN.uv_Main * _Scale).rgb, _AOpower);
			o.Normal = UnpackNormal(tex2D(_Normal, IN.uv_Main * _Scale));
			o.Metallic = (_Metallic).x;
			o.Smoothness = _Metallic.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
