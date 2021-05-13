namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIWidgetSoundMapping : UISoundMappingBase
	{
		[FieldOffset(12, 40)]
		public WidgetEventQueryPair WidgetEvent { get; set; }

		[FieldOffset(28, 72)]
		public ExternalObject<Dummy> SoundEvent { get; set; }

		[FieldOffset(32, 80)]
		public ExternalObject<SoundPatchConfigurationAsset> SoundAction { get; set; }
	}
}
