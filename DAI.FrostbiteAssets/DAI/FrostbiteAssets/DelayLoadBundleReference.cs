namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DelayLoadBundleReference : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<BWActionListContainer> AssetReference { get; set; }

		[FieldOffset(4, 8)]
		public uint PartitionBundleReference { get; set; }
	}
}
