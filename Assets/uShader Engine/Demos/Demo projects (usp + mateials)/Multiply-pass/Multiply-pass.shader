Shader "uSE/Multiply-pass" { 
	Properties { 
		_Cutoff_ ("Cutoff", Range(0,1)) = 0.636
		[Header (Textures and Bumpmaps)]_Main("Main", 2D) = "white" {}
		_Bump("Bump", 2D) = "white" {}
		[Header (Colors)]_MainTint("MainTint", Color) = (0.06617647,0.06617647,0.06617647,1)
		_Metallic("Metallic", Color) = (0.7132353,0.7132353,0.7132353,0.184)
		_Gridcolor("Grid color", Color) = (0.4482759,1,0,1)
		_Grabpassnormal("Grab pass normal", Color) = (1,1,1,1)
		_Emission("Emission", Color) = (0.09558821,0.09558821,0.09558821,1)
		[Header (Variables)]_NormalPower("NormalPower", float) = 3
		_DX("DX", float) = 0.5
		_Thinkness("Thinkness", float) = 0.1
	}
	SubShader {
		LOD 300
		Tags {
			"Queue" = "Geometry"
			"RenderType" = "Opaque"
		}
		Fog {
			Mode Global
			Density 0
			Color (1, 1, 1, 1) 
			Range 0, 300
		}

		GrabPass {
			Name "BASE"
		}
		Cull Back
		ZWrite  On
		ZTest  Less
		ColorMask   RGBA

		CGPROGRAM 
		#pragma surface surf Standard vertex:vert 
		#include "UnityCG.cginc"

		float _Cutoff_;
		sampler2D _Main;
		sampler2D _Bump;
		float4 _MainTint;
		float4 _Metallic;
		float4 _Gridcolor;
		float4 _Grabpassnormal;
		float4 _Emission;
		float _NormalPower;
		float _DX;
		float _Thinkness;

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
			float2 uv_Bump;
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

		void surf (Input IN, inout SurfaceOutputStandard o) {
			o.Albedo = tex2D(_Main, IN.uv_Main).rgb * float3(1.0f, 1.0f, 1.0f);
			o.Normal = UnpackNormal(tex2D(_Bump, IN.uv_Main)) * _NormalPower;
			o.Smoothness = _Metallic.a;
			o.Emission = _MainTint.rgb;
			o.Metallic = (_Metallic).x;
			o.Alpha = tex2D(_Main, IN.uv_Main).a;
			if(o.Alpha < _Cutoff_) discard;
		}
		ENDCG

		LOD 300
		Tags {
			"Queue" = "Geometry"
			"RenderType" = "Opaque"
		}
		Fog {
			Mode Global
			Density 0
			Color (1, 1, 1, 1) 
			Range 0, 300
		}

		GrabPass {
			Name "BASE"
		}
		Cull Back
		ZWrite  On
		ZTest  Less
		ColorMask   RGBA

		CGPROGRAM 
		#pragma surface surf Standard vertex:vert 
		#include "UnityCG.cginc"

		float _Cutoff_;
		sampler2D _Main;
		sampler2D _Bump;
		float4 _MainTint;
		float4 _Metallic;
		float4 _Gridcolor;
		float4 _Grabpassnormal;
		float4 _Emission;
		float _NormalPower;
		float _DX;
		float _Thinkness;

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
			float2 uv_Bump;
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

		void surf (Input IN, inout SurfaceOutputStandard o) {
			o.Albedo = tex2D(_Main, IN.uv_Main).rgb * float3(1.0f, 1.0f, 1.0f);
			o.Normal = UnpackNormal(tex2D(_Bump, IN.uv_Main)) * _NormalPower;
			o.Smoothness = _Metallic.a;
			o.Emission = _MainTint.rgb;
			o.Metallic = (_Metallic).x;
			o.Alpha = tex2D(_Main, IN.uv_Main).a;
			if(o.Alpha < _Cutoff_) discard;
		}
		ENDCG

		LOD 300
		Tags {
			"Queue" = "Geometry"
			"RenderType" = "Opaque"
		}
		Fog {
			Mode Global
			Density 0
			Color (1, 1, 1, 1) 
			Range 0, 300
		}

		GrabPass {
			Name "BASE"
		}
		Cull Back
		ZWrite  On
		ZTest  Greater
		Lighting   Off
		ColorMask   RGBA

		CGPROGRAM 
		#pragma surface surf Standard vertex:vert addshadow 
		#pragma target 4.0
		#include "UnityCG.cginc"

		float _Cutoff_;
		sampler2D _Main;
		sampler2D _Bump;
		float4 _MainTint;
		float4 _Metallic;
		float4 _Gridcolor;
		float4 _Grabpassnormal;
		float4 _Emission;
		float _NormalPower;
		float _DX;
		float _Thinkness;
		sampler2D _GrabTexture : register(s0);
		uniform half4 _GrabTexture_TexelSize;

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
			float2 uv_Bump;
			float3 viewDir;
			float3 worldPos;
			float3 worldRefl;
			float3 worldNormal;
			float4 screenPos;
			float4 color : COLOR;
			float4 proj1;
			float4 position : POSITION;

			INTERNAL_DATA
		};

		void vert (inout appdata v, out Input data){
			UNITY_INITIALIZE_OUTPUT(Input,data);
			data.position = mul(UNITY_MATRIX_MVP, v.vertex);
			data.proj1 = ComputeScreenPos(data.position);
			COMPUTE_EYEDEPTH(data.proj1.z);
			#if UNITY_UV_STARTS_AT_TOP
				data.proj1.y = (data.position.w - data.position.y) * 0.5;
			#endif
		}

		void surf (Input IN, inout SurfaceOutputStandard o) {
			float var19 = fmod((IN.screenPos).x, _DX);
			float var20 = fmod((IN.screenPos).y, _DX);
			o.Albedo = (var19) >= (_Thinkness) ? (_Gridcolor.rgb * tex2Dproj(_GrabTexture, IN.proj1 + abs(_Grabpassnormal.rgb.r * _Grabpassnormal.rgb.g * _Grabpassnormal.rgb.b * 1.0f - 1.0f / 16 ) - 1.0f / 8 + 1.0f / 15)) : ((var20) >= (_Thinkness) ? (_Gridcolor.rgb * tex2Dproj(_GrabTexture, IN.proj1 + abs(_Grabpassnormal.rgb.r * _Grabpassnormal.rgb.g * _Grabpassnormal.rgb.b * 1.0f - 1.0f / 16 ) - 1.0f / 8 + 1.0f / 15)) : (float3(1.0f, 1.0f, 1.0f)));
			o.Alpha = (var19) <= (_Thinkness) ? (0) : ((var20) <= (_Thinkness) ? (0) : (1.0f));
			o.Emission = _Emission.rgb;
			if(o.Alpha < _Cutoff_) discard;
		}
		ENDCG

	}
	FallBack "Diffuse"
}
