// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "TinkerGame/TestUV"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1, 1, 1, 1)
        _Glossiness ("Smoothness", Range (0, 1)) = 0.5
        [Gamma] _Metallic ("Metallic", Range (0, 1)) = 0
    }
    SubShader
    {
        Tags 
        { 
            "RenderType"="Opaque"
        }

        LOD 100

        Pass
        {
			Tags
			{
            	"LightMode"="ForwardBase"
			}

            CGPROGRAM

            #pragma target 3.0

            #pragma vertex vert
            #pragma fragment frag

            #pragma multi_compile _ SHADOWS_SCREEN

			#include "AutoLight.cginc"
			#include "UnityPBSLighting.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uvXY : TEXCOORD0;
                float2 uvYZ : TEXCOORD1;
                float2 uvZX : TEXCOORD2;
                float3 normal : TEXCOORD3;
                float3 normal2 : TEXCOORD6;
				float3 posWorld : TEXCOORD4;
				SHADOW_COORDS(5)
            };

            float4 _MainTex_ST;

            sampler2D _MainTex;
            float4 _Color;
            float _Glossiness;
            float _Metallic;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
				TRANSFER_SHADOW(o);
				// o.shadowCoordinates = ComputeScreenPos(o.vertex);
				o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.normal = UnityObjectToWorldNormal(v.normal);
                o.normal2 = v.normal;
                o.uvXY = TRANSFORM_TEX(0.5 * v.vertex.xy, _MainTex);
                o.uvYZ = TRANSFORM_TEX(0.5 * v.vertex.yz, _MainTex);
                o.uvZX = TRANSFORM_TEX(0.5 * v.vertex.zx, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
				i.normal = normalize(i.normal);

                float3 absN = abs(i.normal);
                float3 nr;
                nr.x = absN.x > absN.y && absN.x > absN.z;
                nr.y = absN.y >= absN.x && absN.y > absN.z;
                nr.z = absN.z >= absN.x && absN.z >= absN.y;

				float3 lightDir = _WorldSpaceLightPos0.xyz;
				float3 viewDir = normalize(_WorldSpaceCameraPos - i.posWorld);

				float3 lightColor = _LightColor0.rgb;
				float3 albedo = (nr.z * tex2D(_MainTex, i.uvXY) + nr.x * tex2D(_MainTex, i.uvYZ) + nr.y * tex2D(_MainTex, i.uvZX)).rgb * _Color.rgb;

				float3 specularTint;
				float oneMinusReflectivity;
				albedo = DiffuseAndSpecularFromMetallic(albedo, _Metallic, specularTint, oneMinusReflectivity);
				
				UnityLight light;
				light.color = lightColor;
				light.dir = lightDir;
				light.ndotl = DotClamped(i.normal, lightDir);
	
				UNITY_LIGHT_ATTENUATION(attenuation, i, i.posWorld.xyz); 

                UnityIndirect indirectLight;
                indirectLight.diffuse = UNITY_LIGHTMODEL_AMBIENT;
                indirectLight.diffuse += max(0, ShadeSH9(float4(i.normal, 1)));
                indirectLight.specular = 0;

				float4 col = UNITY_BRDF_PBS(
					albedo, specularTint,
					oneMinusReflectivity, _Glossiness,
					i.normal, viewDir,
					light, indirectLight
				);

				return col;
            }
            ENDCG
        }

		Pass {
			Tags {
				"LightMode" = "ShadowCaster"
			}

			CGPROGRAM

			#pragma target 3.0

			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			float4 vert (appdata v) : SV_POSITION {
				float4 position = UnityClipSpaceShadowCasterPos(v.vertex.xyz, v.normal);
				return UnityApplyLinearShadowBias(position);
			}

			half4 frag () : SV_TARGET {
				return 0;
			}

			ENDCG
		}
    }
}
