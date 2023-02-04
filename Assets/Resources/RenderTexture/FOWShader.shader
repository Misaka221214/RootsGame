Shader "Hidden/FOWShader"
{
    Properties
    {
        _MainTex ("FOWTexture", 2D) = "white" {}
    }
    SubShader
    {
        Tags{
            "Queue" = "Transparent+1"
        }

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                if (col.a == 0)
                {
                    return col;
                }
                col.r = 0;
                col.g = 0;
                col.b = 0;
                int minDist = 100;
                int count = 0;
                for (int j = -2; j <= 2; j++)
                {
                    for (int k = -2; k <= 2; k++)
                    {
                        fixed4 neib = tex2D(_MainTex, i.uv + float2(j*0.003, k*0.003));
                        if(neib.a ==0)
                        {
                            count ++;
                        }
                        if (neib.a == 0 && abs(j) + abs(k) < minDist)
                        {
                            minDist = abs(j)+abs(k);
                        }
                    }
                }
                if (minDist <= 4)
                {
                    col.a = (25 - count) / 25.f;
                }
                return col;
            }
            ENDCG
        }
    }
}
