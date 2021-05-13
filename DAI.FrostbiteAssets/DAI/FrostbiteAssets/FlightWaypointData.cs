namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FlightWaypointData : WaypointData
	{
		[FieldOffset(20, 48)]
		public float FlightSpeed { get; set; }

		[FieldOffset(24, 52)]
		public float FlightAcceleration { get; set; }

		[FieldOffset(28, 56)]
		public float TurnSpeed { get; set; }

		[FieldOffset(32, 64)]
		public ExternalObject<CSMStateReference> CSMStateRef { get; set; }

		[FieldOffset(36, 72)]
		public ExternalObject<BWActivatedAbility> Ability { get; set; }

		[FieldOffset(40, 80)]
		public BWAbilityTagRef AbilityTag { get; set; }

		[FieldOffset(44, 96)]
		public bool FireStartAbilityEvent { get; set; }

		[FieldOffset(45, 97)]
		public bool FireStopAbilityEvent { get; set; }

		[FieldOffset(46, 98)]
		public bool FireCustomWaypointEvent { get; set; }
	}
}
