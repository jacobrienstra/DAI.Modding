namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AntProjectAsset : Asset
	{
		[FieldOffset(12, 72)]
		public string AntNativeProjectName { get; set; }

		[FieldOffset(16, 80)]
		public AntRef SceneOp { get; set; }

		[FieldOffset(36, 128)]
		public int ProjectId { get; set; }
	}
}
