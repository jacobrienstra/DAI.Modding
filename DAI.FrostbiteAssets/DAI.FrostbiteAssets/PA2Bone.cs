namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PA2Bone : DataContainer
	{
		[FieldOffset(8, 24)]
		public uint Bone { get; set; }
	}
}
