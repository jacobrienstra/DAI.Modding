namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AudioGraphValueParameterConfigData : AudioGraphParameterConfigData
	{
		[FieldOffset(12, 40)]
		public float Value { get; set; }
	}
}
