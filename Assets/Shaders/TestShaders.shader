Shader "Unlit/TestShaders"
{
    Properties
    {
        _ColorFront ("Color", Color) = (1,0.7,0.7,1)
        _pos_fixed4 ("position", Color) = (0,0,0,0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma enable_d3d11_debug_symbols

            #include "UnityCG.cginc"

 
            fixed4 _ColorFront;
            fixed4 _pos_fixed4;

            fixed4 vert (float4 vertex : POSITION): SV_POSITION
            {
                //_pos_fixed4 = UnityObjectToClipPos(vertex);
                return UnityObjectToClipPos(vertex);
            }

            fixed4 frag () : SV_Target
            {
                return _ColorFront;
            }
            ENDCG
        }
    }
}
