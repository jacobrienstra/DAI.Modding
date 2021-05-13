namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlatformNode : UINodeData
	{
		[FieldOffset(20, 64)]
		public ExternalObject<UINodePort> In { get; set; }

		[FieldOffset(24, 72)]
		public ExternalObject<UINodePort> Win32 { get; set; }

		[FieldOffset(28, 80)]
		public ExternalObject<UINodePort> Xenon { get; set; }

		[FieldOffset(32, 88)]
		public ExternalObject<UINodePort> Ps3 { get; set; }

		[FieldOffset(36, 96)]
		public ExternalObject<UINodePort> Gen4a { get; set; }

		[FieldOffset(40, 104)]
		public ExternalObject<UINodePort> Gen4b { get; set; }
	}
}
