
Shader "Toon" {

	Properties{

		_Color("Diffuse Material Color", Color) = (1,1,1,1)
		_UnlitColor("Unlit Color", Color) = (0.5,0.5,0.5,1)
		_Outline("Outline Thickness", Range(0,1)) = 0.1

	}

    CGINCLUDE
    #include "UnityCG.cginc"
    #include "AutoLight.cginc"
    #include "Lighting.cginc"
    ENDCG

	SubShader{


		Pass{

            Lighting On

			Tags{ "LightMode" = "ForwardBase" }

			CGPROGRAM

			#pragma vertex vert 
				//tells the cg to use a vertex-shader called vert
			#pragma fragment frag
			#pragma multi_compile_fwdbase


			//toon-shader, user defined
			uniform float4 _Color;
			uniform float4 _UnlitColor;
			uniform float _Outline;
			uniform float4x4 _World2Receiver;



			struct vertIn {

				//TOON SHADING VAR
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 texcoord : TEXCOORD0;

			};

			struct vertOut {

				float4 pos : SV_POSITION;
				float3 normalDirection : TEXCOORD1;
				float4 lightDirection : TEXCOORD2;
				float3 viewDirection : TEXCOORD3;
				float2 uv : TEXCOORD0;
				LIGHTING_COORDS(4,6)
			};

			// This essentially decides how the light should behave witht the mesh,
			// in other words how it should respond to the world light.
			vertOut vert(vertIn v)
			{
				vertOut o;

				//the dirction of the normal
				o.normalDirection = normalize(mul(float4(v.normal, 0.0), _World2Object).xyz);

				//get the position in the world
				float4 posWorld = mul(_Object2World, v.vertex);

				//vector from the object to the camera, and normalise to get unit
				//vector
				o.viewDirection = normalize(_WorldSpaceCameraPos.xyz - posWorld.xyz);


				//fragmentInput output;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);

				//UV-Map
				o.uv = v.texcoord;

				TRANSFER_VERTEX_TO_FRAGMENT(o);

				return o;

			}


			//Here we can finally define the toon shading effects
			float4 frag(vertOut v) : COLOR
			{

				half atten = LIGHT_ATTENUATION(v);


				//times by 1000 ensures you get hard shadows
				float outlineStrength = saturate((dot(v.normalDirection, v.viewDirection) - _Outline) * 1000);


				// ambient component
				float3 ambientC = _Color.xyz * atten;


				float3 total = (ambientC + UNITY_LIGHTMODEL_AMBIENT.xyz) * outlineStrength;

				return float4(total, 1.0);


			}

			ENDCG

		}



	}

	Fallback "Diffuse"
}