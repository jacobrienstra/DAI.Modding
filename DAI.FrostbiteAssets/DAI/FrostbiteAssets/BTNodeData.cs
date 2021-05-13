namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BTNodeData : DataContainer
	{
		[FieldOffset(8, 24)]
		public string Name { get; set; }

		[FieldOffset(12, 32)]
		public bool Enabled { get; set; }

		[FieldOffset(13, 33)]
		public bool DisabledResult { get; set; }
	}
}
