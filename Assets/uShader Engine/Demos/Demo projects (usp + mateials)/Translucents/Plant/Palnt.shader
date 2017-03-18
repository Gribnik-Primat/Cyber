// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

Shader "uSE/Plant" { 
	Properties { 
		_Cutoff_ ("Cutoff", Range(0,1)) = 1
		[Header (Textures and Bumpmaps)]_Main("Main", 2D) = "white" {}
		_Trans("Trans", 2D) = "white" {}
		[Header (Colors)]_Diffuse("Diffuse", Color) = (0.6911765,0.6911765,0.6911765,1)
		_Forward("Forward", Color) = (0.6323529,0.6323529,0.6323529,1)
		_Maintint("Main tint", Color) = (0.4896553,1,0,1)
		[Header (Variables)]_Power("Power", float) = 1.3
		_Sourcebrightnes("Source brightnes", float) = 0.79
		_Ambient("Ambient", float) = 0.74
		_Reflection("Reflection", float) = 0.47
		_Shading("Shading", float) = 0.506
		_Area("Area", float) = 44.1
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
		#pragma surface surf Standard vertex:vert 
		#pragma target 4.0
		#include "UnityCG.cginc"

		float _Cutoff_;
		sampler2D _Main;
		sampler2D _Trans;
		float4 _Diffuse;
		float4 _Forward;
		float4 _Maintint;
		float _Power;
		float _Sourcebrightnes;
		float _Ambient;
		float _Reflection;
		float _Shading;
		float _Area;

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
			float2 uv_Trans;
			float3 viewDir;
			float3 worldPos;
			float3 worldRefl;
			float3 worldNormal;
			float4 screenPos;
			float4 color : COLOR;
			float4 pos : SV_POSITION;
			float4 posWorld : TEXCOORD0;
			float3 normalDir : TEXCOORD1;

			INTERNAL_DATA
		};

		inline half3 Translucency (Input IN) {
			float3 normalDirection = normalize(IN.normalDir);
			float3 viewDirection = normalize(_WorldSpaceCameraPos - IN.posWorld.xyz);
			normalDirection = faceforward(normalDirection, -viewDirection, normalDirection);
			float3 lightDirection;
			float attenuation;
			if (0.0 == _WorldSpaceLightPos0.w) 
			{
				attenuation = 1.0; // no attenuation
				lightDirection = normalize(_WorldSpaceLightPos0.xyz);
			}
			else
			{
				float3 vertexToLightSource = _WorldSpaceLightPos0.xyz - IN.posWorld.xyz;
				float distance = length(vertexToLightSource);
				attenuation = 1.0 / distance;
				lightDirection = normalize(vertexToLightSource);
			}
			float3 diffuseReflection = attenuation * _LightColor0.rgb * max((_Shading), dot(normalDirection, lightDirection));
			float3 diffuseTranslucency = attenuation * _LightColor0.rgb * (_Diffuse.rgb) * max((_Shading), dot(lightDirection, -normalDirection));
			float3 forwardTranslucency;
			if (dot(normalDirection, lightDirection) > 0.0)
				forwardTranslucency = float3(0.0, 0.0, 0.0);
			else
				forwardTranslucency = attenuation * _LightColor0.rgb * (_Forward.rgb) * pow(max(0.0,dot(-lightDirection, viewDirection)), (_Area));
			float3 transLight = UNITY_LIGHTMODEL_AMBIENT.rgb + diffuseReflection * (_Reflection) + diffuseTranslucency * (_Ambient) + forwardTranslucency * (_Sourcebrightnes);
			transLight *= (tex2D(_Trans, IN.uv_Main).rgb);
			return transLight;
		}

		void vert (inout appdata v, out Input data){
			UNITY_INITIALIZE_OUTPUT(Input,data);
			data.posWorld = mul(unity_ObjectToWorld, v.vertex);
			data.normalDir = normalize(mul(float4(v.normal, 0.0), unity_WorldToObject).xyz);
			data.pos = mul(UNITY_MATRIX_MVP, v.vertex);
		}

		void surf (Input IN, inout SurfaceOutputStandard o) {
			o.Albedo = _Maintint.rgb * tex2D(_Main, IN.uv_Main).rgb;
			o.Alpha = tex2D(_Main, IN.uv_Main).a;
			o.Albedo = lerp(o.Albedo, Translucency(IN) * o.Albedo, (_Power));
			if(o.Alpha < _Cutoff_) discard;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
