namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MasterUnitSettings : DataContainer
	{
		[FieldOffset(8, 24)]
		public string Name { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<EqualizerSettings> Equalizer { get; set; }

		[FieldOffset(16, 40)]
		public ExternalObject<CompressorSettings> Compressor { get; set; }

		[FieldOffset(20, 48)]
		public float MasterVolume { get; set; }

		[FieldOffset(24, 52)]
		public float MasterLfeGain { get; set; }

		[FieldOffset(28, 56)]
		public float MasterDialogGain { get; set; }

		[FieldOffset(32, 60)]
		public float ReverbVolume { get; set; }

		[FieldOffset(36, 64)]
		public float SfxGain { get; set; }

		[FieldOffset(40, 68)]
		public float DistortionClipLevel { get; set; }

		[FieldOffset(44, 72)]
		public float ParallelDistortionGain { get; set; }

		[FieldOffset(48, 76)]
		public float ParallelCompressionGain { get; set; }

		[FieldOffset(52, 80)]
		public float CleanSignalGain { get; set; }
	}
}
