namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SpeechRecognitionUiCommandEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public float ConfidenceThreshold { get; set; }
	}
}
