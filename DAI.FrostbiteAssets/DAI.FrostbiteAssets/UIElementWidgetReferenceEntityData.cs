using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class UIElementWidgetReferenceEntityData : LogicReferenceObjectData
	{
		[FieldOffset(128, 256)]
		public UIElementTransform UIElementTransform { get; set; }

		[FieldOffset(176, 304)]
		public UIElementColor Color { get; set; }

		[FieldOffset(208, 336)]
		public Vec3 PositionOffset { get; set; }

		[FieldOffset(224, 352)]
		public Vec3 RotationOffset { get; set; }

		[FieldOffset(240, 368)]
		public string InstanceName { get; set; }

		[FieldOffset(244, 376)]
		public uint InstanceNameHash { get; set; }

		[FieldOffset(248, 384)]
		public UIElementInclusionSettings InclusionSettings { get; set; }

		[FieldOffset(256, 408)]
		public UIElementSize Size { get; set; }

		[FieldOffset(264, 416)]
		public UILayoutMode LayoutMode { get; set; }

		[FieldOffset(268, 420)]
		public UIElementOffset Offset { get; set; }

		[FieldOffset(276, 428)]
		public UIElementAnchor Anchor { get; set; }

		[FieldOffset(284, 436)]
		public UIElementOffset Position { get; set; }

		[FieldOffset(292, 444)]
		public UIElementRectExpansion Expansion { get; set; }

		[FieldOffset(308, 464)]
		public string CodeAccessIdentifier { get; set; }

		[FieldOffset(312, 472)]
		public bool UseElementSize { get; set; }
	}
}
