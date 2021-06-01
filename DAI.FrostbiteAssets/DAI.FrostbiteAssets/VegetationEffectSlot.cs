namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class VegetationEffectSlot : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<Dummy> Effect { get; set; }

		[FieldOffset(4, 8)]
		public float StrengthMin { get; set; }

		[FieldOffset(8, 12)]
		public float StrengthMax { get; set; }

		[FieldOffset(12, 16)]
		public float SizeMin { get; set; }

		[FieldOffset(16, 20)]
		public float SizeMax { get; set; }
	}
}
