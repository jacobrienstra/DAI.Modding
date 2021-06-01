namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FacialEmotionWeight : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<FacialEmotionLayerDefinition> Emotion { get; set; }

		[FieldOffset(12, 32)]
		public float Weight { get; set; }
	}
}
