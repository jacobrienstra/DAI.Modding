namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MovieNavigationNode : UINodeData
	{
		[FieldOffset(20, 64)]
		public ExternalObject<UINodePort> In { get; set; }

		[FieldOffset(24, 72)]
		public ExternalObject<UINodePort> Out { get; set; }

		[FieldOffset(28, 80)]
		public string MovieClipPath { get; set; }

		[FieldOffset(32, 88)]
		public string FrameLabel { get; set; }

		[FieldOffset(36, 96)]
		public uint Frame { get; set; }

		[FieldOffset(40, 100)]
		public bool UseLabel { get; set; }

		[FieldOffset(41, 101)]
		public bool Play { get; set; }
	}
}
