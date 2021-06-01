using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MixerInputInfo
	{
		[FieldOffset(0, 0)]
		public MixerValueAccumulateMode Mode { get; set; }

		[FieldOffset(4, 4)]
		public bool KeepValue { get; set; }
	}
}
