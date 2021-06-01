using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TacticsCommandTransform : CSMTransformProvider
	{
		[FieldOffset(8, 32)]
		public TacticsCommandType CommandType { get; set; }
	}
}
