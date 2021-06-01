namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ChildStaticModelNetworkInfo
	{
		[FieldOffset(0, 0)]
		public IndexRange NetworkRange { get; set; }

		[FieldOffset(8, 8)]
		public uint ParentPartComponentIndex { get; set; }

		[FieldOffset(12, 12)]
		public uint ParentHealthStateIndex { get; set; }

		[FieldOffset(16, 16)]
		public uint InstanceIndex { get; set; }
	}
}
