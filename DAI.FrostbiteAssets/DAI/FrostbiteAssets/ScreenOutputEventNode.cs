namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ScreenOutputEventNode : UINodeData
	{
		[FieldOffset(20, 64)]
		public ExternalObject<UINodePort> Out { get; set; }
	}
}
