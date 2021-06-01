namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIItemDamageTypeLocalizationData : LinkObject
	{
		[FieldOffset(0, 0)]
		public int DamageType { get; set; }

		[FieldOffset(4, 8)]
		public LocalizedStringReference DamageTypeLabel { get; set; }
	}
}
