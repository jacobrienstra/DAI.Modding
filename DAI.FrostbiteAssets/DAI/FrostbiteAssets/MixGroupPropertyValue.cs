namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MixGroupPropertyValue
	{
		[FieldOffset(0, 0)]
		public uint Property { get; set; }

		[FieldOffset(4, 4)]
		public float Value { get; set; }

		[FieldOffset(8, 8)]
		public bool Controlled { get; set; }
	}
}
