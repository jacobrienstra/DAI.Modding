namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ClothStateSetupTransition
	{
		[FieldOffset(0, 0)]
		public uint TransitionLodIndex { get; set; }

		[FieldOffset(4, 4)]
		public uint TransitionLodStateIndex { get; set; }
	}
}
