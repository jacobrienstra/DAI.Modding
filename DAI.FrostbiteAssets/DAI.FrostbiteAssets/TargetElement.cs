namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class TargetElement : BaseTargetElement
	{
		[FieldOffset(64, 96)]
		public Vec3 HealthFloatyOffset { get; set; }

		[FieldOffset(80, 112)]
		public Vec3 DamageFloatyNormalOffset { get; set; }

		[FieldOffset(96, 128)]
		public Vec3 DamageFloatyCriticalOffset { get; set; }

		[FieldOffset(112, 144)]
		public Vec3 StatusEffectFloatyOffset { get; set; }

		[FieldOffset(128, 160)]
		public Vec3 PauseInfoFloatyOffset { get; set; }

		[FieldOffset(144, 176)]
		public Vec3 AbilityTargetOffset { get; set; }

		[FieldOffset(160, 192)]
		public int MaxTargetTickets { get; set; }

		[FieldOffset(164, 196)]
		public int MaxAttackTickets { get; set; }

		[FieldOffset(168, 200)]
		public int MaxInteractionTickets { get; set; }

		[FieldOffset(172, 204)]
		public int MaxSpecialAttackTickets { get; set; }

		[FieldOffset(176, 208)]
		public int MaxCustomTickets4 { get; set; }

		[FieldOffset(180, 212)]
		public int MaxCustomTickets5 { get; set; }

		[FieldOffset(184, 216)]
		public int MaxCustomTickets6 { get; set; }

		[FieldOffset(188, 220)]
		public int FloatyBoneId { get; set; }

		[FieldOffset(192, 224)]
		public float CameraWeight { get; set; }

		[FieldOffset(196, 232)]
		public ExternalObject<BWModifiableStat> CameraWeightModifierStat { get; set; }

		[FieldOffset(200, 240)]
		public MaterialDecl BarrierMaterialPair { get; set; }

		[FieldOffset(204, 256)]
		public MaterialDecl ArmoredMaterialPair { get; set; }

		[FieldOffset(208, 272)]
		public MaterialDecl HealthMaterialPair { get; set; }

		[FieldOffset(212, 288)]
		public ExternalObject<BWDepletableStat> SuperHealthStat { get; set; }

		[FieldOffset(216, 296)]
		public ExternalObject<BWDepletableStat> ArmourStat { get; set; }

		[FieldOffset(220, 304)]
		public ExternalObject<BWDepletableStat> TargetHealthStat { get; set; }

		[FieldOffset(224, 312)]
		public ExternalObject<BWDepletableStat> BarrierStat { get; set; }

		[FieldOffset(228, 320)]
		public ExternalObject<BWStat> BarrierType { get; set; }

		[FieldOffset(232, 328)]
		public ExternalObject<CSMArmourStateChangedCallback> ArmourCallback { get; set; }

		[FieldOffset(236, 336)]
		public ExternalObject<CSMSuperHealthDepletedCallback> SuperHealthCallback { get; set; }

		[FieldOffset(240, 344)]
		public int DeferredReticle { get; set; }

		[FieldOffset(244, 348)]
		public bool UseOwningCreatureRotation { get; set; }

		[FieldOffset(245, 349)]
		public bool AcceptsDamage { get; set; }

		[FieldOffset(246, 350)]
		public bool NoReticle { get; set; }

		[FieldOffset(247, 351)]
		public bool IsShieldCollision { get; set; }

		[FieldOffset(248, 352)]
		public bool ShowHealthFloaty { get; set; }

		[FieldOffset(249, 353)]
		public bool UseCreatureHealthForFloaty { get; set; }

		[FieldOffset(250, 354)]
		public bool ShowTextFloaties { get; set; }
	}
}
