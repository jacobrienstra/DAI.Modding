namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ProfileOptionDataEnumItem : LinkObject
	{
		[FieldOffset(0, 0)]
		public string DisplayName { get; set; }

		[FieldOffset(4, 8)]
		public bool Default { get; set; }
	}
}
