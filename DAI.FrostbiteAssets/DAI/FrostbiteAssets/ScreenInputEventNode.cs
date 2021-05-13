namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ScreenInputEventNode : UINodeData
	{
		[FieldOffset(20, 64)]
		public ExternalObject<UINodePort> In { get; set; }
	}
}
