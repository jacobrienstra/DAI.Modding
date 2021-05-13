namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class VegetationTreeEntityData : VegetationBaseEntityData
	{
		[FieldOffset(160, 304)]
		public Vec3 InertiaModifier { get; set; }

		[FieldOffset(176, 320)]
		public Vec3 TranslucencyVolumeCenter { get; set; }

		[FieldOffset(192, 336)]
		public float Stiffness { get; set; }

		[FieldOffset(196, 340)]
		public float Damping { get; set; }

		[FieldOffset(200, 344)]
		public float StemMass { get; set; }

		[FieldOffset(204, 348)]
		public float StiffnessSpread { get; set; }

		[FieldOffset(208, 352)]
		public float DampingSpread { get; set; }

		[FieldOffset(212, 356)]
		public float MassSpread { get; set; }

		[FieldOffset(216, 360)]
		public float StemLockedUpTo { get; set; }

		[FieldOffset(220, 364)]
		public int StemBoneCount { get; set; }

		[FieldOffset(224, 368)]
		public float BreakableJointThreshold { get; set; }

		[FieldOffset(228, 372)]
		public float BoundingBoxScaleFactor { get; set; }

		[FieldOffset(232, 376)]
		public float PartsTimeToLive { get; set; }

		[FieldOffset(236, 380)]
		public float LinearVelocityDamping { get; set; }

		[FieldOffset(240, 384)]
		public float AngularVelocityDamping { get; set; }

		[FieldOffset(244, 388)]
		public float Friction { get; set; }

		[FieldOffset(248, 392)]
		public float Restitution { get; set; }

		[FieldOffset(252, 396)]
		public float StemPhysicsWidth { get; set; }

		[FieldOffset(256, 400)]
		public float StemPhysicsHeightScale { get; set; }

		[FieldOffset(260, 404)]
		public float BranchPhysicsWidth { get; set; }

		[FieldOffset(264, 408)]
		public float BranchPhysicsHeightScale { get; set; }

		[FieldOffset(268, 412)]
		public float DestructionMassScale { get; set; }

		[FieldOffset(272, 416)]
		public float CenterOfMassVerticalScale { get; set; }

		[FieldOffset(276, 424)]
		public VegetationEffectSlot StemBreakEffect { get; set; }

		[FieldOffset(296, 448)]
		public VegetationEffectSlot BranchBreakEffect { get; set; }

		[FieldOffset(316, 472)]
		public VegetationEffectSlot ImpactEffect { get; set; }

		[FieldOffset(336, 496)]
		public ExternalObject<Dummy> WindEffect { get; set; }

		[FieldOffset(340, 504)]
		public float MinRespawnTime { get; set; }

		[FieldOffset(344, 508)]
		public uint StemEffectNodeThreshold { get; set; }

		[FieldOffset(348, 512)]
		public uint ShadowLODOffset { get; set; }

		[FieldOffset(352, 516)]
		public bool ConstantFalloff { get; set; }

		[FieldOffset(353, 517)]
		public bool Indestructable { get; set; }

		[FieldOffset(354, 518)]
		public bool TranslucencyEnabled { get; set; }
	}
}
