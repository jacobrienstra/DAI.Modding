namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_PlayBodyFallSound : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public int SourceBoneId { get; set; }

		[FieldOffset(32, 80)]
		public MaterialDecl OverrideMaterial { get; set; }
	}
}
