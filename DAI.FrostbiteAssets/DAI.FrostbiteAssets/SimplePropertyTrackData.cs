using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SimplePropertyTrackData : PropertyTrackData
	{
		[FieldOffset(16, 48)]
		public InterpolationType InterpolationType { get; set; }
	}
}
