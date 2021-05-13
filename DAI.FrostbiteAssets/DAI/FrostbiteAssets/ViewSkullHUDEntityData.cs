namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ViewSkullHUDEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public LocalizedStringReference CountStringId { get; set; }

		[FieldOffset(20, 120)]
		public int Spotted { get; set; }

		[FieldOffset(24, 124)]
		public int Total { get; set; }
	}
}
