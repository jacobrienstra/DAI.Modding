using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TransformLayerData : TimelineTrackData
	{
		[FieldOffset(24, 128)]
		public ExternalObject<FloatTrackData> Weight { get; set; }

		[FieldOffset(28, 136)]
		public LayeredTransform_BlendType Blendtype { get; set; }
	}
}
