using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UpdateBeamTargetData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public LocationSelection Target { get; set; }
	}
}
