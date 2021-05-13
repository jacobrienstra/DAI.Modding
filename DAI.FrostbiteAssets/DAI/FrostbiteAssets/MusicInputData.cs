namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MusicInputData : DataContainer
	{
		[FieldOffset(8, 24)]
		public string Name { get; set; }

		[FieldOffset(12, 32)]
		public uint NameHash { get; set; }
	}
}
