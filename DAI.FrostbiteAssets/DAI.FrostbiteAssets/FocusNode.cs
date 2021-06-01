namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FocusNode : UINodeData
	{
		[FieldOffset(20, 64)]
		public ExternalObject<UINodePort> In { get; set; }

		[FieldOffset(24, 72)]
		public ExternalObject<UINodePort> Out { get; set; }

		[FieldOffset(28, 80)]
		public int FocusIndex { get; set; }

		[FieldOffset(32, 84)]
		public bool RemoveFocus { get; set; }
	}
}
