
Texture2D SourceTexture;
SamplerState SourceSampler;

cbuffer cbTextureParameters
{
	float4 ChannelMaskRed;
	float4 ChannelMaskGreen;
	float4 ChannelMaskBlue;
	float4 ChannelMaskAlpha;
	float  AlphaEnabled;
	float  IsNormalMap;
	float  IsSharedExponent;
	float  Padding;
};


struct VS_IN
{
	float3 pos : POSITION;
	float2 texcoord : TEXCOORD0;
};

struct PS_IN
{
	float4 pos : SV_POSITION;
	float2 texcoord : TEXCOORD0;
};

PS_IN VS( VS_IN input )
{
	PS_IN output = (PS_IN) 0;

	output.pos = float4( input.pos, 1.0f );
	output.texcoord = input.texcoord;

	return output;
}

float4 PS( PS_IN input ) : SV_Target
{
	float4 Color = SourceTexture.Sample( SourceSampler, input.texcoord );
	if( IsNormalMap > 0.0f )
	{
		Color = 2.0f * Color - 1.0f;
		Color = normalize( Color );
		Color.b = sqrt( 1.0f - ( Color.r * Color.r + Color.g * Color.g ) );
		Color = (Color + 1.0f) * 0.5f;
	}
	if( IsSharedExponent > 0.0f )
	{
		Color.rgb = Color.rgb * pow( 2, Color.a );
		Color.a = 1.0f;
	}

	float4 Red = Color.rrrr * ChannelMaskRed;
	float4 Green = Color.gggg * ChannelMaskGreen;
	float4 Blue = Color.bbbb * ChannelMaskBlue;
	float4 Alpha = Color.aaaa * ChannelMaskAlpha;
	float4 TotalColor = ( Red + Green + Blue + Alpha );
	TotalColor.a = ( AlphaEnabled < 1.0f ) ? 1.0f : TotalColor.a;
	return TotalColor;
}

