namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CharacterSprintData : DataContainer
	{
		[FieldOffset(8, 24)]
		public float SprintPowerDecreasePerSecond { get; set; }

		[FieldOffset(12, 28)]
		public float SprintPowerIncreasePerSecond { get; set; }

		[FieldOffset(16, 32)]
		public float SprintMinimumPower { get; set; }

		[FieldOffset(20, 36)]
		public bool AllowContinousSprinting { get; set; }
	}
}
