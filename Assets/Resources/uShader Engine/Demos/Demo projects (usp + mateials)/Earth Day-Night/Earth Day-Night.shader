Shader "uSE/Earth Day-Night v2" { 
	Properties { 
		_Cutoff_ ("Cutoff", Range(0,1)) = 0
		[Header (Textures and Bumpmaps)]_Day("Day", 2D) = "white" {}
		_Night("Night", 2D) = "white" {}
		[Header (Variables)]_SmoothnessPower("SmoothnessPower", float) = 0.85
		_EmissionPower("EmissionPower", float) = 0.82
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
		#pragma surface surf StandardSpecular vertex:vert 
		#pragma target 4.0
		#include "UnityCG.cginc"

		float _Cutoff_;
		sampler2D _Day;
		sampler2D _Night;
		float _SmoothnessPower;
		float _EmissionPower;

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
			float2 uv_Day;
			float2 uv_Night;
			float3 viewDir;
			float3 worldPos;
			float3 worldRefl;
			float3 worldNormal;
			float4 screenPos;
			float4 color : COLOR;

			INTERNAL_DATA
		};

		void vert (inout appdata v, out Input data){
			UNITY_INITIALIZE_OUTPUT(Input,data);
		}

		void surf (Input IN, inout SurfaceOutputStandardSpecular o) {
			o.Albedo = (normalize(tex2D(_Day, float2((IN.uv_Day).x + _Time.x, (IN.uv_Day).y)).rgb)) < (normalize(lerp(tex2D(_Day, float2((IN.uv_Day).x + _Time.x, (IN.uv_Day).y)).rgb, tex2D(_Night, float2((IN.uv_Day).x + _Time.x, (IN.uv_Day).y)).rgb, saturate(_SinTime.x)))) ? (tex2D(_Day, float2((IN.uv_Day).x + _Time.x, (IN.uv_Day).y)).rgb) : (lerp(tex2D(_Day, float2((IN.uv_Day).x + _Time.x, (IN.uv_Day).y)).rgb, tex2D(_Night, float2((IN.uv_Day).x + _Time.x, (IN.uv_Day).y)).rgb, saturate(_SinTime.x)));
			o.Smoothness = _SmoothnessPower * normalize(lerp(tex2D(_Day, float2((IN.uv_Day).x + _Time.x, (IN.uv_Day).y)).rgb, tex2D(_Night, float2((IN.uv_Day).x + _Time.x, (IN.uv_Day).y)).rgb, saturate(_SinTime.x)));
			o.Occlusion = normalize(lerp(tex2D(_Day, float2((IN.uv_Day).x + _Time.x, (IN.uv_Day).y)).rgb, tex2D(_Night, float2((IN.uv_Day).x + _Time.x, (IN.uv_Day).y)).rgb, saturate(_SinTime.x)));
			o.Emission = tex2D(_Night, float2((IN.uv_Day).x + _Time.x, (IN.uv_Day).y)).rgb * _EmissionPower;
			if(o.Alpha < _Cutoff_) discard;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
