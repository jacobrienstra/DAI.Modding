using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TacticsTargetTransform : CSMTransformProvider
	{
		[FieldOffset(8, 32)]
		public TacticsTarget Target { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<EntityProvider_Self> Entity { get; set; }
	}
}
