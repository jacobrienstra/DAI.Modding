namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(1)]
	public class SamplerPlugins
	{
		[FieldOffset(0, 0)]
		public SoundGraphPluginRef SndPlayer { get; set; }

		[FieldOffset(3, 3)]
		public SoundGraphPluginRef Resample { get; set; }

		[FieldOffset(6, 6)]
		public SoundGraphPluginRef Pause { get; set; }

		[FieldOffset(9, 9)]
		public SoundGraphPluginRef Gain { get; set; }
	}
}
