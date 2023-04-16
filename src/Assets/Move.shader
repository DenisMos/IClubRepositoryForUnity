// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/SimpleWater"
{
    Properties
    {
      _NoiseWave("Wave Perlin Noise Texture", 2D) = "white" {}
      _Cubemap("Reflection Texrture", CUBE) = "" {}
      _WaterColor("Water Color", Color) = (1, 1, 1, 0)
      _WaterColorAmount("Water Color Amount", float) = 0.5
      _WaterSpeedX("Water Speed X", float) = 0.5
      _WaterSpeedY("Water Speed Y", float) = 0.5
      _WaveSpeed("Wave Speed", float) = 0.5
      _WaveScale("Wave Scale", Vector) = (1, 1, 1, 1)
    }

      SubShader
      {
        Tags { "RenderType" = "Opaque" }

        Pass
        {
          CGPROGRAM
          #include "UnityCG.cginc"
          #pragma vertex VS_MAIN
          #pragma fragment PS_MAIN

          sampler2D _NoiseWave;
          samplerCUBE _Cubemap;

          uniform float4 _WaterColor;
          uniform float _WaterSpeedX;
          uniform float _WaterSpeedY;
          uniform float _WaterColorAmount;
          uniform float4 _WaveScale;
          uniform float _WaveSpeed;

          struct VS_INPUT
          {
            float4 Pos          : POSITION;
            float3 Normal       : TEXCOORD0;
          };

          struct VS_OUTPUT
          {
            float4 Pos          : POSITION;
            float3 scaledPos    : TEXCOORD0;
            float3 Normal       : TEXCOORD1;
            float3 ViewVector   : TEXCOORD2;
          };

          struct PS_INPUT
          {
             float3 Pos: TEXCOORD0;
             float3 Normal: TEXCOORD1;
             float3 ViewVector: TEXCOORD2;
          };

          VS_OUTPUT VS_MAIN(VS_INPUT input)
          {
            VS_OUTPUT  output;
            output.Pos = UnityObjectToClipPos(input.Pos);
            output.scaledPos = output.Pos.xyz * _WaveScale; просто сжатие или растяжение волны
            output.ViewVector.xzy = output.Pos - _WorldSpaceCameraPos; // вектор направления взгляда из камеры
            output.Normal = input.Normal;

            return output;
          }

          float4 PS_MAIN(PS_INPUT input) : COLOR
          {
             input.Pos.x += _WaterSpeedX * unity_DeltaTime.y; // движение текстурных координат         
             input.Pos.y += _WaterSpeedY * unity_DeltaTime.y;

             float4 noiseValue = tex2D(_NoiseWave, input.Pos); // получаем пиксель из шумовой текстуры

             float3 noiseBumping = 2 * noiseValue - 1;
             noiseBumping.xy *= 0.15;
             noiseBumping.z = 0.8 * abs(noiseBumping.z) + 0.2;
             noiseBumping = normalize(input.Normal + noiseBumping);

             float3 reflectionVector = reflect(input.ViewVector, noiseBumping); // получаем вектор отражения исходя из направления взгляда, и расчитанного по сути положения поверхности волны (нормали поверхности всегда положительные).
             float4 reflectionColor = texCUBE(_Cubemap, reflectionVector.xyz); // получаем цвет отраженной текстуры из кубмапа.

             return lerp(_WaterColor, reflectionColor, _WaterColorAmount); // смешиваем цвет воды и цвет отраженной текстуры.
          }

          ENDCG
        }
      }

          FallBack "Diffuse"
}