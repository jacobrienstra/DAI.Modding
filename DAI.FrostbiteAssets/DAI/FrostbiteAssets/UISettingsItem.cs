using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UISettingsItem : LinkObject
	{
		[FieldOffset(0, 0)]
		public string NameSid { get; set; }

		[FieldOffset(4, 8)]
		public UISettingSymbols StartEndSymbols { get; set; }

		[FieldOffset(8, 16)]
		public ExternalObject<Dummy> Setting { get; set; }
	}
}
