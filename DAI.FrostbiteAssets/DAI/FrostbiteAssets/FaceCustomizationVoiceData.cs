namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FaceCustomizationVoiceData
	{
		[FieldOffset(0, 0)]
		public uint UsageHash { get; set; }

		[FieldOffset(4, 4)]
		public byte Value { get; set; }
	}
}
