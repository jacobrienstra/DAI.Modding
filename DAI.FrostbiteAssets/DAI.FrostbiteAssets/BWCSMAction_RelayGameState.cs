using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_RelayGameState : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public RelayGameStateType GameStateType { get; set; }

		[FieldOffset(32, 80)]
		public ExternalObject<EntityProvider_Self> SourceEntity { get; set; }

		[FieldOffset(36, 88)]
		public int SourceAnimatable { get; set; }

		[FieldOffset(40, 96)]
		public AntRef SourceGameStateBool { get; set; }

		[FieldOffset(60, 144)]
		public AntRef SourceGameStateFloat { get; set; }

		[FieldOffset(80, 192)]
		public ExternalObject<MountEntity> TargetEntity { get; set; }

		[FieldOffset(84, 200)]
		public int TargetAnimatable { get; set; }

		[FieldOffset(88, 208)]
		public AntRef TargetGameStateBool { get; set; }

		[FieldOffset(108, 256)]
		public AntRef TargetGameStateFloat { get; set; }

		[FieldOffset(128, 304)]
		public AntRef AttachmentPointer { get; set; }
	}
}
