namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ItemPartType : Asset
	{
		[FieldOffset(12, 72)]
		public LocalizedStringReference DisplayName { get; set; }

		[FieldOffset(16, 96)]
		public bool IsPrimaryPart { get; set; }
	}
}
