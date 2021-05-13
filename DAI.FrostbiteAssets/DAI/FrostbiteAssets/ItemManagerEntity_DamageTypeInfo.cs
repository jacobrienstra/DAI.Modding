namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ItemManagerEntity_DamageTypeInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public int Id { get; set; }

		[FieldOffset(4, 8)]
		public string IconFrameLabel { get; set; }

		[FieldOffset(8, 16)]
		public LocalizedStringReference Name { get; set; }

		[FieldOffset(12, 40)]
		public LocalizedStringReference DamageString { get; set; }

		[FieldOffset(16, 64)]
		public LocalizedStringReference AOEDamageString { get; set; }
	}
}
