using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TacticsTargetEntityProvider : CSMEntityProvider
	{
		[FieldOffset(8, 32)]
		public TacticsTarget Target { get; set; }
	}
}
