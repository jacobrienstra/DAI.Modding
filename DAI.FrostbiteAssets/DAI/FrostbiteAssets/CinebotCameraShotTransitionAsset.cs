using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotCameraShotTransitionAsset : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public string TransitionName { get; set; }

		[FieldOffset(16, 80)]
		public ExternalObject<CinebotBlendData> BlendData { get; set; }

		[FieldOffset(20, 88)]
		public CinebotBlendType BlendType { get; set; }

		[FieldOffset(24, 92)]
		public CinebotTransitionType TransitionType { get; set; }
	}
}
