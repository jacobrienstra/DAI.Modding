namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LineCooldownOverride : DataContainer
	{
		[FieldOffset(8, 24)]
		public string ConversationLine { get; set; }

		[FieldOffset(12, 32)]
		public float Cooldown { get; set; }
	}
}
