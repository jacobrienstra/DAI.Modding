namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MorphTwoWaySlider : MorphBaseSlider
	{
		[FieldOffset(24, 40)]
		public float LeftMax { get; set; }

		[FieldOffset(28, 44)]
		public float RightMax { get; set; }
	}
}
