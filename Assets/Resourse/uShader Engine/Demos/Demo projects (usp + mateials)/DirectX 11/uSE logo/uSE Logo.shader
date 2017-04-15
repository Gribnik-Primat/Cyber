Shader "uSE/uSE Logo" { 
	Properties { 
		_Cutoff_ ("Cutoff", Range(0,1)) = 0
		[Header (Tessellation config)]_TessMultiplier_("Polygons multiplier", float) = 24
		_Displacement_("Displacement", float) = -0.15
		[Header (Textures and Bumpmaps)]_DispMap("DispMap", 2D) = "white" {}
		[Header (CubeMaps)]_Cubmap("Cubmap", CUBE) = "" {}
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
		#pragma surface surf Lambert vertex:vert tessellate:tess 
		#include "UnityCG.cginc"
		#include "Tessellation.cginc"

		float _Cutoff_;
		sampler2D _DispMap;
		samplerCUBE _Cubmap;
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
			float2 uv_DispMap;
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
			float disp = (tex2Dlod(_DispMap, float4((v.texcoord.xy + _Time.y * 0.02).x, (v.texcoord.xy + _Time.y * 0.02).y, 1.0f, 0) * 15)).r * _Displacement_;
			v.vertex.xyz += v.normal * disp;
		}

		void surf (Input IN, inout SurfaceOutput o) {
			o.Emission = pow(texCUBE(_Cubmap, float4(IN.worldRefl, 1.0f)).rgb, 10);
			o.Albedo = float4(0.6397059, 0.1975562, 0.1975562, 1).rgb;
			if(o.Alpha < _Cutoff_) discard;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
