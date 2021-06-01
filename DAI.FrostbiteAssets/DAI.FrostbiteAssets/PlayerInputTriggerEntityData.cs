using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlayerInputTriggerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public int EntryInputActions { get; set; }

		[FieldOffset(24, 104)]
		public float ValueModifier { get; set; }

		[FieldOffset(28, 108)]
		public float ValueModifierForMouse { get; set; }

		[FieldOffset(32, 112)]
		public float HoldDownTime { get; set; }

		[FieldOffset(36, 116)]
		public float AccumulatedValueAtStart { get; set; }

		[FieldOffset(40, 120)]
		public float TrailingValueAtStart { get; set; }

		[FieldOffset(44, 124)]
		public bool ClampValueAfterMouseModifier { get; set; }

		[FieldOffset(45, 125)]
		public bool EnabledFromStart { get; set; }

		[FieldOffset(46, 126)]
		public bool SendTriggerEvents { get; set; }
	}
}
