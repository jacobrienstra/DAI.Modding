namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AudioGraphParameterConfigData : DataContainer
	{
		[FieldOffset(8, 24)]
		public uint NameHash { get; set; }
	}
}
