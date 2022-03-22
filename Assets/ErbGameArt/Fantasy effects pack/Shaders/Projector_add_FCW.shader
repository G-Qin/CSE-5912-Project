Shader "ERB/Projector/Add_FromCenterWave" {
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
			Blend One One
			Offset -1, -1
	
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fog
			#include "UnityCG.cginc"
			
			struct v2f {
				float4 uvShadow : TEXCOORD0;
				float4 uvFalloff : TEXCOORD1;
				float4 uvMask : TEXCOORD2;
				UNITY_FOG_COORDS(3)
				float4 pos : SV_POSITION;
			};
			
			float4x4 unity_Projector;
			float4x4 unity_ProjectorClip;
			
			v2f vert (float4 vertex : POSITION)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(vertex);
				o.uvShadow = mul (unity_Projector, vertex);
				o.uvFalloff = mul (unity_ProjectorClip, vertex);
				o.uvMask = mul (unity_Projector, vertex);
				UNITY_TRANSFER_FOG(o,o.pos);
				return o;
			}
			float _Emission;
			float _MoveCirle;
			float _Opacity;
			fixed4 _Color;
			sampler2D _MainTex;
			sampler2D _MaskTex;
			sampler2D _FalloffTex;
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 texS = tex2Dproj (_MainTex, UNITY_PROJ_COORD(i.uvShadow));
				fixed4 texM = tex2Dproj (_MaskTex, UNITY_PROJ_COORD(i.uvMask));

				float3 nnn = (1.0 - (texM.rgb-((_MoveCirle*0.55)*-1.0+1.0)));
                float3 uuu = saturate(texM.rgb-((_MoveCirle*0.25)*-1.0+1.0));
				texS.rgb *= _Color.rgb * _Emission * _Opacity * saturate(((texM.rgb*saturate(texM.rgb-(_MoveCirle*-1.0+1.0)))*(4*saturate(nnn)))+(uuu+uuu));
				texS.a = 1.0-texS.a;
	
				fixed4 texF = tex2Dproj (_FalloffTex, UNITY_PROJ_COORD(i.uvFalloff));
				fixed4 res = texS * texF.a;

				UNITY_APPLY_FOG_COLOR(i.fogCoord, res, fixed4(0,0,0,0));
				return res;
			}
			ENDCG
		}
	}
}
