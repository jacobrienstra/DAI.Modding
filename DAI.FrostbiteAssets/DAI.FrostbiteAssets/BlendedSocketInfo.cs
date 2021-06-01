namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BlendedSocketInfo : AppearanceSocketInfo
	{
		[FieldOffset(8, 24)]
		public ExternalObject<AppearanceSocketInfo> Socket1 { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<StandardSocketInfo> Socket2 { get; set; }

		[FieldOffset(16, 40)]
		public AntRef BlendFactorGamestate { get; set; }
	}
}
