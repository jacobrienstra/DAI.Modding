namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SwimmingStateData : CharacterStateData
	{
		[FieldOffset(12, 32)]
		public float BodyUnderWater { get; set; }
	}
}
