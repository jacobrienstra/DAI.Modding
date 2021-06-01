namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class OncePerMatchRandomIntEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public int Start { get; set; }

		[FieldOffset(20, 100)]
		public int Count { get; set; }

		[FieldOffset(24, 104)]
		public bool TrueRandom { get; set; }

		[FieldOffset(25, 105)]
		public bool HasInitialValue { get; set; }
	}
}
