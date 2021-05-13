using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UpdateVolumeMaskData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public VolumeMaskType MaskType { get; set; }
	}
}
