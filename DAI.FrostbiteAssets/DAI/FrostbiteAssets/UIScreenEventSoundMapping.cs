namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIScreenEventSoundMapping : UISoundMappingBase
	{
		[FieldOffset(12, 40)]
		public string Event { get; set; }

		[FieldOffset(16, 48)]
		public ExternalObject<Dummy> SoundAction { get; set; }
	}
}
