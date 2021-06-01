namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWCSMAction_AttachJoint : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<EntityProvider_Self> SourceEntity { get; set; }

		[FieldOffset(32, 80)]
		public LinearTransform AttachmentOffset { get; set; }

		[FieldOffset(96, 144)]
		public int SourceAnimatable { get; set; }

		[FieldOffset(100, 152)]
		public ExternalObject<IntegerProvider> SourceBoneIndex { get; set; }

		[FieldOffset(104, 160)]
		public ExternalObject<EntityProvider> TargetEntity { get; set; }

		[FieldOffset(108, 168)]
		public int TargetAnimatable { get; set; }

		[FieldOffset(112, 176)]
		public ExternalObject<IntegerProvider_SocketBoneIndex> TargetBoneIndex { get; set; }

		[FieldOffset(116, 184)]
		public AntRef WeightGamestate { get; set; }

		[FieldOffset(136, 232)]
		public AntRef AttachmentPointer { get; set; }
	}
}
