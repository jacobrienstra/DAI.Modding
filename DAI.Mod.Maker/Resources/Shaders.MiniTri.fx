
Texture2D DiffuseTexture;
SamplerState DiffuseSampler;

Texture2D NormalTexture;
SamplerState NormalSampler;

struct DirectionalLight
{
	float4 Ambient;
	float4 Diffuse;
	float4 Specular;
	float3 Direction;
	float Padding;
};

struct Material
{
	float4 Ambient;
	float4 Diffuse;
	float4 Specular;
	float4 Reflect;
};

cbuffer cbPerFrame
{
	DirectionalLight DirLight;
	float3 EyePos;
};

cbuffer cbPerObject
{
	float4x4 WorldViewProj;
	float4x4 WorldInvTranspose;
	float4x4 World;
	Material ObjectMat;
	float4 TextureSlots;
}

struct VS_IN
{
	float3 pos : POSITION;
	float3 norm : NORMAL;
	float3 tan : TANGENT;
	float2 texcoord : TEXCOORD0;
};

struct PS_IN
{
	float4 pos : SV_POSITION;
	float3 norm : TEXCOORD0;
	float3 tan : TEXCOORD1;
	float2 texcoord : TEXCOORD2;
	float3 worldPos : TEXCOORD3;
};

PS_IN VS( VS_IN input )
{
	PS_IN output = (PS_IN) 0;

	output.pos = mul( float4( input.pos, 1.0f ), WorldViewProj );
	output.norm = mul( input.norm, ( float3x3 ) WorldInvTranspose );
	output.tan = mul( input.tan, ( float3x3 ) World );
	output.texcoord = input.texcoord;
	output.worldPos = mul( float4( input.pos, 1.0f ), World ).xyz;

	return output;
}

void ComputeDirectionalLight( Material Mat, DirectionalLight L, float3 Normal, float3 ToEye, out float4 Ambient, out float4 Diffuse, out float4 Spec )
{
	Ambient = float4( 0.0f, 0.0f, 0.0f, 0.0f );
	Diffuse = float4( 0.0f, 0.0f, 0.0f, 0.0f );
	Spec = float4( 0.0f, 0.0f, 0.0f, 0.0f );

	float3 LightVec = -L.Direction;
	Ambient = Mat.Ambient * L.Ambient;

	float DiffuseFactor = dot( LightVec, Normal );

	[flatten]
	if( DiffuseFactor > 0.0f )
	{
		float3 v = reflect( -LightVec, Normal );
		float SpecFactor = pow( max( dot( v, ToEye ), 0.0f ), Mat.Specular.w );

		Diffuse = DiffuseFactor * Mat.Diffuse * L.Diffuse;
		Spec = SpecFactor * Mat.Specular * L.Specular;
	}
}

float3 NormalSampleToWorldspace( float3 NormalSample, float3 Normal, float3 Tangent )
{
	float3 NormalT = normalize( 2.0f * NormalSample - 1.0f );
	NormalT.z = sqrt( 1.0f - ( NormalT.x * NormalT.x + NormalT.y * NormalT.y ) );

	float3 N = Normal;
	float3 T = normalize( Tangent - dot( Tangent, N ) * N );
	float3 B = cross( N, T );

	float3x3 TBN = float3x3( T, B, N );

	float3 OutNormal = mul( NormalT, TBN );
	return OutNormal;
}

float4 PS( PS_IN input ) : SV_Target
{
	input.norm = normalize( input.norm );
	
	float3 ToEye = normalize( EyePos - input.worldPos );

	float4 Ambient = float4( 0.0f, 0.0f, 0.0f, 0.0f );
	float4 Diffuse = float4( 0.0f, 0.0f, 0.0f, 0.0f );
	float4 Spec = float4( 0.0f, 0.0f, 0.0f, 0.0f );

	float3 NormalSample = NormalTexture.Sample( NormalSampler, input.texcoord ).rgb;
	NormalSample = NormalSampleToWorldspace( NormalSample, input.norm, input.tan );
	if( TextureSlots.y < 1.0f )
		NormalSample = input.norm;

	float4 A, D, S;
	ComputeDirectionalLight( ObjectMat, DirLight, NormalSample, ToEye, A, D, S );
	Ambient += A;
	Diffuse += D;
	Spec += S;

	float4 DiffuseTex = DiffuseTexture.Sample( DiffuseSampler, input.texcoord );
	Diffuse = lerp( Diffuse, Diffuse * DiffuseTex, TextureSlots.x );

	float4 LitColor = Ambient + Diffuse + Spec;
	LitColor.a = ObjectMat.Diffuse.a;

	return float4( LitColor.rgb, DiffuseTex.a );
}

float4 PSWireframe( PS_IN input ) : SV_Target
{
	return float4( 1.0f, 1.0f, 1.0f, 1.0f );
}

technique10 Render
{
	pass P0
	{
		SetGeometryShader( 0 );
		SetVertexShader( CompileShader( vs_5_0, VS( ) ) );
		SetPixelShader( CompileShader( ps_5_0, PS( ) ) );
	}
}