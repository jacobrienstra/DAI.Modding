namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SpeechRecognitionCombatCommandEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public float ConfidenceThreshold { get; set; }

		[FieldOffset(20, 104)]
		public ExternalObject<BWActivatedAbility> SummonMountAbility { get; set; }
	}
}
