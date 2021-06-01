using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class PrintDebugTextEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Vec3 TextColor { get; set; }

		[FieldOffset(32, 112)]
		public Realm Realm { get; set; }

		[FieldOffset(36, 120)]
		public string Text { get; set; }

		[FieldOffset(40, 128)]
		public Vec2 ScreenPosition { get; set; }

		[FieldOffset(48, 136)]
		public float TimeToShow { get; set; }

		[FieldOffset(52, 140)]
		public float TextScale { get; set; }

		[FieldOffset(56, 144)]
		public bool Enabled { get; set; }
	}
}
