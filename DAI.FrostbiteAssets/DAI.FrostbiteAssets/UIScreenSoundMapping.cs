using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIScreenSoundMapping : UISoundMappingBase
	{
		[FieldOffset(12, 40)]
		public uint WidgetNameHash { get; set; }

		[FieldOffset(16, 48)]
		public string OutputName { get; set; }

		[FieldOffset(20, 56)]
		public UIWidgetEventID WidgetEvent { get; set; }

		[FieldOffset(24, 64)]
		public ExternalObject<Dummy> SoundAction { get; set; }
	}
}
