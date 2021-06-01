namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UpdateRibbonFadeData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public int FadeInParticleCount { get; set; }

		[FieldOffset(20, 68)]
		public int FadeOutParticleCount { get; set; }
	}
}
