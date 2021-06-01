namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWCollision : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public float RepeatTime { get; set; }

		[FieldOffset(32, 80)]
		public Vec3 EffectRotation { get; set; }

		[FieldOffset(48, 96)]
		public ExternalObject<TransformProvider> ImpactTransform { get; set; }

		[FieldOffset(52, 104)]
		public float Speed { get; set; }

		[FieldOffset(56, 108)]
		public int MaxActorsHit { get; set; }

		[FieldOffset(60, 112)]
		public int AttackerAttachmentPoint { get; set; }

		[FieldOffset(64, 116)]
		public bool HitFriendlies { get; set; }

		[FieldOffset(65, 117)]
		public bool HitEnemies { get; set; }

		[FieldOffset(66, 118)]
		public bool HitCharacters { get; set; }

		[FieldOffset(67, 119)]
		public bool HitNonCharacters { get; set; }

		[FieldOffset(68, 120)]
		public bool HitDeadCharacters { get; set; }

		[FieldOffset(69, 121)]
		public bool ExcludeCaster { get; set; }

		[FieldOffset(70, 122)]
		public bool MultiImpactsPerEntity { get; set; }
	}
}
