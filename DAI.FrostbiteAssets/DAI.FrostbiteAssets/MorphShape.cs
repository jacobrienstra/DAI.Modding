namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MorphShape : MorphBaseSlider
	{
		[FieldOffset(24, 40)]
		public float TargetMax { get; set; }
	}
}
