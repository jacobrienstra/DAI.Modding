using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class DebugTextEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public Vec3 TextColor { get; set; }

		[FieldOffset(96, 192)]
		public string DebugText { get; set; }

		[FieldOffset(100, 200)]
		public Realm Realm { get; set; }

		[FieldOffset(104, 204)]
		public float Scale { get; set; }

		[FieldOffset(108, 208)]
		public bool Centered { get; set; }

		[FieldOffset(109, 209)]
		public bool Visible { get; set; }

		[FieldOffset(110, 210)]
		public bool DepthTest { get; set; }

		[FieldOffset(111, 211)]
		public bool ScaleWithDistance { get; set; }
	}
}
