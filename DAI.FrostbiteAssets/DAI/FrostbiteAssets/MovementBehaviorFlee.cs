namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MovementBehaviorFlee : MovementBehavior
	{
		[FieldOffset(24, 40)]
		public float Range { get; set; }

		[FieldOffset(28, 44)]
		public float SqueezeRange { get; set; }

		[FieldOffset(32, 48)]
		public float PredatorClusterDistance { get; set; }

		[FieldOffset(36, 52)]
		public float UpdatePeriod { get; set; }

		[FieldOffset(40, 56)]
		public MoverTuneId EnemyCloseTuneId { get; set; }

		[FieldOffset(44, 60)]
		public MoverTuneId EnemyFarTuneId { get; set; }

		[FieldOffset(48, 64)]
		public float TimeOut { get; set; }
	}
}
