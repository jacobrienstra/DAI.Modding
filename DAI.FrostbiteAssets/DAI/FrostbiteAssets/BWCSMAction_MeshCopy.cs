namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWCSMAction_MeshCopy : BWCSMAction
	{
		[FieldOffset(32, 80)]
		public MeshCopyOptions Options { get; set; }
	}
}
