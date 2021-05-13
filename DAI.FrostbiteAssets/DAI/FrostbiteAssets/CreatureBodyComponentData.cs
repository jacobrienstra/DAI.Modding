namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class CreatureBodyComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public float SprintMultiplier { get; set; }

		[FieldOffset(100, 180)]
		public float OverrideGravityValue { get; set; }

		[FieldOffset(104, 184)]
		public float OverrideVelocityY { get; set; }

		[FieldOffset(108, 188)]
		public bool OverrideGravity { get; set; }

		[FieldOffset(109, 189)]
		public bool OverrideVelocity { get; set; }
	}
}
