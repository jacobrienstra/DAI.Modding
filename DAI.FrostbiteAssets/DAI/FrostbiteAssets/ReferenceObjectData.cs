using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ReferenceObjectData : GameObjectData
	{
		[FieldOffset(16, 96)]
		public LinearTransform BlueprintTransform { get; set; }

		[FieldOffset(80, 160)]
		public ExternalObject<Blueprint> Blueprint { get; set; }

		[FieldOffset(84, 168)]
		public ExternalObject<ObjectVariation> ObjectVariation { get; set; }

		[FieldOffset(88, 176)]
		public ExternalObject<ShaderParametersInstance> ShaderParameters { get; set; }

		[FieldOffset(92, 184)]
		public StreamRealm StreamRealm { get; set; }

		[FieldOffset(96, 188)]
		public RadiosityTypeOverride RadiosityTypeOverride { get; set; }

		[FieldOffset(100, 192)]
		public uint LightmapResolutionScale { get; set; }

		[FieldOffset(104, 196)]
		public bool ScaleUVsWithInstanceSize { get; set; }

		[FieldOffset(105, 197)]
		public bool IsOccluder { get; set; }

		[FieldOffset(106, 198)]
		public bool CastSunShadowEnable { get; set; }

		[FieldOffset(107, 199)]
		public bool CastReflectionEnable { get; set; }

		[FieldOffset(108, 200)]
		public bool Excluded { get; set; }
	}
}
