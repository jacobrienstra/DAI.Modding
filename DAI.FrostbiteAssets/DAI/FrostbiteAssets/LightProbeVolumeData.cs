namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class LightProbeVolumeData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public uint Xres { get; set; }

		[FieldOffset(84, 180)]
		public uint Yres { get; set; }

		[FieldOffset(88, 184)]
		public uint Zres { get; set; }

		[FieldOffset(92, 188)]
		public float BlendDistance { get; set; }

		[FieldOffset(96, 192)]
		public int Priority { get; set; }
	}
}
