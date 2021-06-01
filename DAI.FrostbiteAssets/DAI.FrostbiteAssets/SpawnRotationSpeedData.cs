namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SpawnRotationSpeedData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public float RotationSpeed { get; set; }
	}
}
