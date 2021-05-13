
cbuffer cbPerObject
{
	float4x4 WorldViewProj;
}

struct VS_IN
{
	float3 pos : POSITION;
};

struct PS_IN
{
	float4 pos : SV_POSITION;
};

PS_IN VS( VS_IN input )
{
	PS_IN output = (PS_IN) 0;

	output.pos = mul( float4( input.pos, 1.0f ), WorldViewProj );
	return output;
}

float4 PS( PS_IN input ) : SV_Target
{
	return float4( 1, 1, 1, 1 );
}

technique11 Render
{
	pass P0
	{
		SetGeometryShader( 0 );
		SetVertexShader( CompileShader( vs_5_0, VS( ) ) );
		SetPixelShader( CompileShader( ps_5_0, PS( ) ) );
	}
}