namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FbProxyControllerEntityBinding : LinkObject
	{
		[FieldOffset(0, 0)]
		public AntRef Trigger { get; set; }

		[FieldOffset(20, 48)]
		public AntRef Stop { get; set; }

		[FieldOffset(40, 96)]
		public AntRef BlendInTime { get; set; }

		[FieldOffset(60, 144)]
		public AntRef BlendOutTime { get; set; }
	}
}
