namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWAIDoTacticCommandEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public LinearTransform Transform { get; set; }

		[FieldOffset(80, 160)]
		public ExternalObject<TacticsCommandUseAbilityData> TacticCommand { get; set; }

		[FieldOffset(84, 168)]
		public short RetryInterval { get; set; }

		[FieldOffset(86, 170)]
		public bool QueueIfBlocked { get; set; }

		[FieldOffset(87, 171)]
		public bool RetryOnFailed { get; set; }

		[FieldOffset(88, 172)]
		public bool RetryOnAborted { get; set; }
	}
}
