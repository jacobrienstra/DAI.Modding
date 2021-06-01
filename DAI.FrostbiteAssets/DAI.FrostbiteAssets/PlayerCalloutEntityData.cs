namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlayerCalloutEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public int Callout0Input { get; set; }

		[FieldOffset(20, 100)]
		public int Callout1Input { get; set; }

		[FieldOffset(24, 104)]
		public int Callout2Input { get; set; }

		[FieldOffset(28, 108)]
		public int Callout3Input { get; set; }

		[FieldOffset(32, 112)]
		public float CalloutDuration { get; set; }

		[FieldOffset(36, 116)]
		public int UsePoolMax { get; set; }

		[FieldOffset(40, 120)]
		public float UseRegenerationTime { get; set; }

		[FieldOffset(44, 124)]
		public float UseExhaustionTime { get; set; }
	}
}
