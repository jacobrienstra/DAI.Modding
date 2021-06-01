using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class PropertyDebugEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Vec3 TextColor { get; set; }

		[FieldOffset(32, 112)]
		public Vec3 WorldPosition { get; set; }

		[FieldOffset(48, 128)]
		public LinearTransform TransformValue { get; set; }

		[FieldOffset(112, 192)]
		public Vec3 Vec3Value { get; set; }

		[FieldOffset(128, 208)]
		public Vec4 Vec4Value { get; set; }

		[FieldOffset(144, 224)]
		public Realm Realm { get; set; }

		[FieldOffset(148, 228)]
		public Vec2 ScreenPosition { get; set; }

		[FieldOffset(156, 240)]
		public string ValuePrefix { get; set; }

		[FieldOffset(160, 248)]
		public float TextScale { get; set; }

		[FieldOffset(164, 252)]
		public float FloatValue { get; set; }

		[FieldOffset(168, 256)]
		public int IntValue { get; set; }

		[FieldOffset(172, 260)]
		public Vec2 Vec2Value { get; set; }

		[FieldOffset(180, 272)]
		public string StringValue { get; set; }

		[FieldOffset(184, 280)]
		public bool Multiline { get; set; }

		[FieldOffset(185, 281)]
		public bool ShowTransformInWorld { get; set; }

		[FieldOffset(186, 282)]
		public bool ShowTransformCoordinates { get; set; }

		[FieldOffset(187, 283)]
		public bool DefaultVisible { get; set; }

		[FieldOffset(188, 284)]
		public bool BoolValue { get; set; }
	}
}
