namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class InstanceOutputNode : UINodeData
	{
		[FieldOffset(20, 64)]
		public ExternalObject<UINodePort> In { get; set; }

		[FieldOffset(24, 72)]
		public new int Id { get; set; }

		[FieldOffset(28, 76)]
		public bool DestroyGraph { get; set; }
	}
}
