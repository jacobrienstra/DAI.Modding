namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class InstanceInputNode : UINodeData
	{
		[FieldOffset(20, 64)]
		public ExternalObject<UINodePort> Out { get; set; }
	}
}
