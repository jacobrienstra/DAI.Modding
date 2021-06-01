namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class VoiceOverManagerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<StreamPoolMapping> StreamPoolMapping { get; set; }
	}
}
