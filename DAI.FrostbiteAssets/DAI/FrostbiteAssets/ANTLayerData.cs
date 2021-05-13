using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ANTLayerData : TimelineTrackData
	{
		[FieldOffset(24, 128)]
		public ANTLayerBlendType BlendType { get; set; }
	}
}
