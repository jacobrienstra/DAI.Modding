namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PropertyConnection : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<DataContainer> Source { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<DataContainer> Target { get; set; }

		[FieldOffset(8, 16)]
		public int SourceFieldId { get; set; }

		[FieldOffset(12, 20)]
		public int TargetFieldId { get; set; }

		[FieldOffset(16, 24)]
		public bool ShouldNetworkValue { get; set; }
	}
}
