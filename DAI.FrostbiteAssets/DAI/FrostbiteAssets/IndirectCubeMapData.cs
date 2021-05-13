namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class IndirectCubeMapData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public uint Resolution { get; set; }

		[FieldOffset(84, 180)]
		public float Scale { get; set; }

		[FieldOffset(88, 184)]
		public float FadeDistance { get; set; }

		[FieldOffset(92, 188)]
		public bool Enable { get; set; }
	}
}
