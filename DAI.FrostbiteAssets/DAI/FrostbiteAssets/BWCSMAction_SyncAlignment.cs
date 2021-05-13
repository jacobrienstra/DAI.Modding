namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_SyncAlignment : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public int SourceBoneId { get; set; }

		[FieldOffset(32, 76)]
		public int TargetBoneId { get; set; }

		[FieldOffset(36, 80)]
		public float RelativeSliding { get; set; }

		[FieldOffset(40, 84)]
		public float RotationOffset { get; set; }
	}
}
