using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SpeechRecognitionCertCommandEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public InputDeviceMessageEvent ShowMenu { get; set; }

		[FieldOffset(20, 100)]
		public InputDeviceMessageEvent ChangeView { get; set; }

		[FieldOffset(24, 104)]
		public InputDeviceMessageEvent Pause { get; set; }

		[FieldOffset(28, 108)]
		public InputDeviceMessageEvent Play { get; set; }

		[FieldOffset(32, 112)]
		public InputDeviceMessageEvent Back { get; set; }
	}
}
