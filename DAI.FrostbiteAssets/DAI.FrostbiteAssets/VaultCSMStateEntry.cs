namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class VaultCSMStateEntry : LinkObject
	{
		[FieldOffset(0, 0)]
		public float MinHeight { get; set; }

		[FieldOffset(4, 4)]
		public float MaxHeight { get; set; }

		[FieldOffset(8, 8)]
		public ExternalObject<Dummy> StateReference { get; set; }
	}
}
