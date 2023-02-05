Shader "Hidden/FOWShader"
{
    Properties
    {
        _MainTex ("FOWTexture", 2D) = "white" {}
        _TransparencyTolerance ("FOWTexture", Float) = 0.9
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
            float _TransparencyTolerance;
            
            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                if (col.a < _TransparencyTolerance)
                {
                    col.r = 0;
                    col.g = 0;
                    col.b = 0;
                    col.a = 0;
                    return col;
                }
                col.r = 0;
                col.g = 0;
                col.b = 0;
                int minDist = 100;
                float count = 0.f;
                int rad = 3;
                
                for (int j = - rad; j <= rad; j++)
                {
                    for (int k = -rad; k <= rad; k++)
                    {
                        fixed4 neib = tex2D(_MainTex, i.uv + float2(j*0.0015, k*0.0015));
                        if(neib.a < _TransparencyTolerance)
                        {
                            count += 1.f;
                        }
                        if (neib.a < _TransparencyTolerance && abs(j) + abs(k) < minDist)
                        {
                            minDist = abs(j)+abs(k);
                        }
                    }
                }
                if (minDist <= 1)
                {
                    col.a = 0.f;
                } else if (minDist <= rad * 2 +1)
                {
                    col.a = ((2.f * rad + 1)*(2 * rad + 1) - count) / ( (2 * rad + 1)*(2 * rad + 1));
                }
                return col;
            }
            ENDCG
        }
    }
}
