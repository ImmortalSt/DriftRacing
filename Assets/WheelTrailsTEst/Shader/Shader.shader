Shader "Custom/Shader"
{
    Properties
    {
        _BrushColor("Color", Color) = (1,1,1,1)
        _Tex("InputTex", 2D) = "white" {}
        _BrushCoodrinate("Brush", Vector) = (0, 0, 0, 0)
        _BrushSize("Brush Size", Range(0, 1)) = 0
        
    }

    SubShader
    {
       Lighting Off
       Blend One Zero

       Pass
       {
           CGPROGRAM
           #include "UnityCustomRenderTexture.cginc"
           #pragma vertex CustomRenderTextureVertexShader
           #pragma fragment frag
           #pragma target 3.0

           float4      _BrushColor;
           sampler2D   _Tex;
           float4      _BrushCoodrinate;
           half        _BrushSize;

           float4 frag(v2f_customrendertexture IN) : COLOR
           {
               if (distance(IN.localTexcoord.xy, _BrushCoodrinate) <= _BrushSize)
                   return _BrushColor;

               float4 lastColor = tex2D(_SelfTexture2D, IN.localTexcoord.xy);

               if (lastColor.r == _BrushColor.r)
                   return lastColor;

               return tex2D(_Tex, IN.localTexcoord.xy);
           }
           ENDCG
       }
    }
}
