namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AmbientLocationProxyEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public int Environment { get; set; }

		[FieldOffset(20, 100)]
		public int SpatialFeature { get; set; }

		[FieldOffset(24, 104)]
		public int MaxSimultaneous { get; set; }

		[FieldOffset(28, 108)]
		public float SetBackDistance { get; set; }

		[FieldOffset(32, 112)]
		public float AllowedStopDistance { get; set; }

		[FieldOffset(36, 116)]
		public int PartyMemberID { get; set; }

		[FieldOffset(40, 120)]
		public bool UseMainControlledCharacter { get; set; }

		[FieldOffset(41, 121)]
		public bool StartAtGeometricallyClosestWaypoint { get; set; }
	}
}
