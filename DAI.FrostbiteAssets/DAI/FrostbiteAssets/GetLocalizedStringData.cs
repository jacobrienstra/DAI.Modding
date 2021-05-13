namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GetLocalizedStringData : EntityData
	{
		[FieldOffset(16, 96)]
		public LocalizedStringReference Text { get; set; }

		[FieldOffset(20, 120)]
		public int StringIDOverride { get; set; }
	}
}
