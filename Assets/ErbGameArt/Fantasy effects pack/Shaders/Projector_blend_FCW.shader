Shader "ERB/Projector/Blend_FromCenterWave" {
	Properties {
		_Color ("Main Color", Color) = (1,1,1,1)
		_MainTex ("MainTex", 2D) = "" {}
		_MaskTex ("MaskTex", 2D) = "" {}
		_FalloffTex ("FallOff", 2D) = "" {}
		_Emission ("Emission", Float ) = 2
		_Opacity ("Opacity", Range(0, 1)) = 1
		_MoveCirle ("MoveCirle", Range(0, 4)) = 4
	}
	
	Subshader {
		Tags {"Queue"="Transparent"}
		Pass {
			ZWrite Off
			ColorMask RGB
			Blend SrcAlpha OneMinusSrcAlpha
			Offset -1, -1
	
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fog
			#include "UnityCG.cginc"
			
			struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
			
			struct v2f {
				float4 uvShadow : TEXCOORD0;
				float4 uvFalloff : TEXCOORD1;
				float4 uvMask : TEXCOORD2;
				float4 vertexColor : COLOR;
				UNITY_FOG_COORDS(3)
				float4 pos : SV_POSITION;
			};
			
			float4x4 unity_Projector;
			float4x4 unity_ProjectorClip;
			
			v2f vert (float4 vertex : POSITION, VertexInput v)
			{
				v2f o = (v2f)0;
				o.vertexColor = v.vertexColor;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uvShadow = mul (unity_Projector, v.vertex);
				o.uvMask = mul (unity_Projector, v.vertex);
				o.uvFalloff = mul (unity_ProjectorClip, v.vertex);
				UNITY_TRANSFER_FOG(o,o.pos);
				return o;
			}
			float _Emission;
			float _Opacity;
			float _MoveCirle;
			fixed4 _Color;
			sampler2D _MainTex;
			sampler2D _MaskTex;
			sampler2D _FalloffTex;
			
			fixed4 frag (v2f i) : COLOR
			{
				fixed4 texS = tex2Dproj (_MainTex, UNITY_PROJ_COORD(i.uvShadow));
				fixed4 texF = tex2Dproj (_FalloffTex, UNITY_PROJ_COORD(i.uvFalloff));
				fixed4 texM = tex2Dproj (_MaskTex, UNITY_PROJ_COORD(i.uvMask));

				float3 nnn = (1.0 - (texM.rgb-((_MoveCirle*0.55)*-1.0+1.0)));
                float3 uuu = saturate(texM.rgb-((_MoveCirle*0.25)*-1.0+1.0));				
				fixed4 MainTexvar = lerp(fixed4(1,1,1,0), texS, texF.a);
				float3 emissive = MainTexvar.rgb * _Color.rgb * i.vertexColor.rgb * _Emission * saturate(((texM.rgb*saturate(texM.rgb-(_MoveCirle*-1.0+1.0)))*(4*saturate(nnn)))+(uuu+uuu));
				fixed4 finalRGBA = fixed4(emissive,(MainTexvar.a*i.vertexColor.a*_Opacity));				
				UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
				return finalRGBA;
			}
			ENDCG
		}
	}
}
