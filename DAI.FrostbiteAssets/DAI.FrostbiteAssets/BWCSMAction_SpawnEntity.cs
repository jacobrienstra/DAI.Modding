using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWCSMAction_SpawnEntity : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<Blueprint> Blueprint { get; set; }

		[FieldOffset(32, 80)]
		public Vec3 Offset { get; set; }

		[FieldOffset(48, 96)]
		public SpawnEntityReference PositionReference { get; set; }

		[FieldOffset(52, 100)]
		public int AttachPoint { get; set; }

		[FieldOffset(56, 104)]
		public SpawnEntityReference OrientationReference { get; set; }

		[FieldOffset(60, 108)]
		public float OrientationOffset { get; set; }

		[FieldOffset(64, 112)]
		public ExternalObject<TransformProvider> SpawnLocation { get; set; }

		[FieldOffset(68, 120)]
		public BWCSMActionTarget SpawnEventEntity { get; set; }

		[FieldOffset(72, 124)]
		public bool DestroyOnEnd { get; set; }
	}
}
