namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ClothStateSetupTransitionLookup
	{
		[FieldOffset(0, 0)]
		public uint FirstTransitionableLodIndex { get; set; }

		[FieldOffset(4, 4)]
		public uint TransitionableLodCount { get; set; }
	}
}
