using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class UIElementEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public UIElementTransform UIElementTransform { get; set; }

		[FieldOffset(64, 144)]
		public UIElementColor Color { get; set; }

		[FieldOffset(96, 176)]
		public Vec3 PositionOffset { get; set; }

		[FieldOffset(112, 192)]
		public Vec3 RotationOffset { get; set; }

		[FieldOffset(128, 208)]
		public string InstanceName { get; set; }

		[FieldOffset(132, 216)]
		public uint InstanceNameHash { get; set; }

		[FieldOffset(136, 220)]
		public UIElementSize Size { get; set; }

		[FieldOffset(144, 228)]
		public UILayoutMode LayoutMode { get; set; }

		[FieldOffset(148, 232)]
		public UIElementOffset Offset { get; set; }

		[FieldOffset(156, 240)]
		public UIElementAnchor Anchor { get; set; }

		[FieldOffset(164, 248)]
		public UIElementOffset Position { get; set; }

		[FieldOffset(172, 256)]
		public UIElementRectExpansion Expansion { get; set; }

		[FieldOffset(188, 272)]
		public bool Visible { get; set; }
	}
}
