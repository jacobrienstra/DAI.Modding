namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TextNotificationConfigData : LinkObject
	{
		[FieldOffset(0, 0)]
		public string IDName { get; set; }

		[FieldOffset(4, 8)]
		public int SoundID { get; set; }
	}
}
