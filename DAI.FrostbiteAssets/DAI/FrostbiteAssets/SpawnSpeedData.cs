namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SpawnSpeedData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public float Speed { get; set; }
	}
}
