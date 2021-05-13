namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SpawnRotationData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public float Rotation { get; set; }
	}
}
