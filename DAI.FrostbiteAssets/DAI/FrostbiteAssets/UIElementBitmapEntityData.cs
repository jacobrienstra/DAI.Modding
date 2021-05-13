namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class UIElementBitmapEntityData : UIElementEntityData
	{
		[FieldOffset(192, 304)]
		public Vec4 UVRect { get; set; }

		[FieldOffset(208, 320)]
		public UIElementBitmapDistanceFieldParams DistanceFieldParams { get; set; }

		[FieldOffset(256, 368)]
		public ExternalObject<Dummy> Style { get; set; }

		[FieldOffset(260, 376)]
		public string TextureId { get; set; }

		[FieldOffset(264, 384)]
		public string TextureIdPropertyName { get; set; }

		[FieldOffset(268, 392)]
		public bool DistanceField { get; set; }
	}
}
