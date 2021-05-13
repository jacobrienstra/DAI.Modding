using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AttachmentPointTransform : CSMTransformProvider
	{
		[FieldOffset(8, 32)]
		public TransformProviderReference Character { get; set; }

		[FieldOffset(12, 36)]
		public int AttachmentPoint { get; set; }
	}
}
