namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundGraphPluginInfo
	{
		[FieldOffset(0, 0)]
		public uint Id { get; set; }

		[FieldOffset(4, 4)]
		public uint EnableAttributeReadMask { get; set; }

		[FieldOffset(8, 8)]
		public byte ConnectionIndex { get; set; }

		[FieldOffset(9, 9)]
		public byte OutputChannelCount { get; set; }

		[FieldOffset(10, 10)]
		public byte ConstructParamsIndex { get; set; }

		[FieldOffset(11, 11)]
		public byte ConstructParamCount { get; set; }
	}
}
