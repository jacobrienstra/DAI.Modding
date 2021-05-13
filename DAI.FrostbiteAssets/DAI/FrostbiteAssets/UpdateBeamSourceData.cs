using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UpdateBeamSourceData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public LocationSelection Source { get; set; }
	}
}
