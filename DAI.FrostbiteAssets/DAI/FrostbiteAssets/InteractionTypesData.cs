namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(1)]
	public class InteractionTypesData
	{
		[FieldOffset(0, 0)]
		public bool InteractionEntity { get; set; }

		[FieldOffset(1, 1)]
		public bool PickupEntity { get; set; }

		[FieldOffset(2, 2)]
		public bool AmmoCrateEntity { get; set; }

		[FieldOffset(3, 3)]
		public bool VehicleEntity { get; set; }

		[FieldOffset(4, 4)]
		public bool ExplosionPackEntity { get; set; }

		[FieldOffset(5, 5)]
		public bool SoldierEntity { get; set; }
	}
}
