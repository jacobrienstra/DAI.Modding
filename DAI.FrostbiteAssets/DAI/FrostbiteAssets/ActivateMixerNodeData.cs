using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ActivateMixerNodeData : VuMeterNodeData
	{
		[FieldOffset(84, 320)]
		public ExternalObject<MixerAsset> Mixer { get; set; }

		[FieldOffset(88, 328)]
		public ActivateMixerCondition Condition { get; set; }

		[FieldOffset(92, 332)]
		public float ActivationThreshold { get; set; }
	}
}
