namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundWaveSubtitle : LinkObject
	{
		[FieldOffset(0, 0)]
		public float Time { get; set; }

		[FieldOffset(4, 4)]
		public short StringIndex { get; set; }
	}
}
