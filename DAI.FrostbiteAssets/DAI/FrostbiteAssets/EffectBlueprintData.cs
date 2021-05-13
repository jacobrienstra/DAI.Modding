using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EffectBlueprintData : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<EffectBlueprint> ImpactEffect { get; set; }

		[FieldOffset(4, 8)]
		public GameProjAreaOfEffectVFXOrientation ImpactEffectOrientation { get; set; }
	}
}
