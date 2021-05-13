namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AudioGraphNodePort
	{
		[FieldOffset(0, 0)]
		public float UnconnectedValue { get; set; }

		[FieldOffset(4, 4)]
		public short ValueIndex { get; set; }

		[FieldOffset(6, 6)]
		public bool IsConnected { get; set; }
	}
}
