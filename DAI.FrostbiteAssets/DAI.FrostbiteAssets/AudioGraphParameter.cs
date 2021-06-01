namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AudioGraphParameter : DataContainer
	{
		[FieldOffset(8, 24)]
		public float DefaultValue { get; set; }

		[FieldOffset(12, 28)]
		public uint NameHash { get; set; }

		[FieldOffset(16, 32)]
		public short ValueIndex { get; set; }
	}
}
