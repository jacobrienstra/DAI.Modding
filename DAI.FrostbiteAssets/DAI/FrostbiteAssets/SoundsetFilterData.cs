namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundsetFilterData : DataContainer
	{
		[FieldOffset(8, 24)]
		public uint Priority { get; set; }
	}
}
