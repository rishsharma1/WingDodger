Shader "PhongShader" {


	Properties{

		_MainTint("Diffuse Tint", Color) = (1,1,1,1)
		_MainTex("Base (RGB)", 2D) = "white" {}
		_SpecularColor("Specular Color", Color) = (1,1,1,1)
		_Specular("Specular Power", Range(0,100)) = 1

		_ReflectionCoefficient("Reflection Coefficient", Range(0,1)) = 0.3
	}

	SubShader{

		CGPROGRAM
		#pragma surface surf BlinnPhong

		sampler2D _MainTex;
		float4 _MainTint;
		float4 _SpecularColor;
		float _Specular;


		//Shader referenced from unity's shaders
		half4 LightingBlinnPhong(SurfaceOutput a, half3 lightDir, half3 viewDir,
			half3 normal, half4 color,half atten) {

			lightDir = normalize(lightDir);
			viewDir = normalize(viewDir);

			half3 halfVector = normalize(lightDir + viewDir);

			//diffuse
			half d = dot(normal, lightDir);

			float nh = saturate(dot(halfVector, normal));
			//specular
			float s = pow(nh, _Specular) * color.a;

			half4 c;
			c.rgb = (color.rgb * _MainTint.rgb * d +
				_SpecularColor.rgb * s) * (atten * 2);

			c.a = _SpecularColor.a * s * atten;
			return c;
		}

		struct Input {
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutput o) {
			o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb * _MainTint;
			o.Specular = _Specular;
		}

		ENDCG
	}

	FallBack "Diffuse"
}