namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundGraphLinkedPluginAttribute
	{
		[FieldOffset(0, 0)]
		public float UnconnectedValue { get; set; }

		[FieldOffset(4, 4)]
		public short ValueIndex { get; set; }

		[FieldOffset(6, 6)]
		public short NodeIndexAndFlags { get; set; }

		[FieldOffset(8, 8)]
		public byte VoiceIndex { get; set; }

		[FieldOffset(9, 9)]
		public byte PluginIndex { get; set; }

		[FieldOffset(10, 10)]
		public byte AttributeIndex { get; set; }
	}
}
