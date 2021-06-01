namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class EntityInteractionComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public float PickupRadius { get; set; }

		[FieldOffset(100, 180)]
		public float MaxAmmoPickupTimer { get; set; }

		[FieldOffset(104, 184)]
		public float MaxAmmoCrateTimer { get; set; }

		[FieldOffset(108, 188)]
		public float SoldierInteractRadius { get; set; }

		[FieldOffset(112, 192)]
		public float MaxLookAtAngle { get; set; }

		[FieldOffset(116, 196)]
		public int SoldierInteractInputAction { get; set; }

		[FieldOffset(120, 200)]
		public float DistanceToAngleWeighting { get; set; }

		[FieldOffset(124, 204)]
		public float DistancePower { get; set; }

		[FieldOffset(128, 208)]
		public float AnglePower { get; set; }

		[FieldOffset(132, 212)]
		public float Stickiness { get; set; }

		[FieldOffset(136, 216)]
		public ExternalObject<BWRange> MaximumRange { get; set; }

		[FieldOffset(140, 224)]
		public bool AllowInteractionWithSoldiers { get; set; }

		[FieldOffset(141, 225)]
		public bool OnlyAllowInteractionWithManDownSoldiers { get; set; }

		[FieldOffset(142, 226)]
		public InteractionTypesData InteractWithTypes { get; set; }

		[FieldOffset(148, 232)]
		public bool CanInteract { get; set; }
	}
}
