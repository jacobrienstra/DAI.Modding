namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MorphOneWaySlider : MorphBaseSlider
	{
		[FieldOffset(24, 40)]
		public float TargetMax { get; set; }
	}
}
