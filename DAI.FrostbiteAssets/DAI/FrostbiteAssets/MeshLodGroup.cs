namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MeshLodGroup : Asset
	{
		[FieldOffset(12, 72)]
		public float Lod1Distance { get; set; }

		[FieldOffset(16, 76)]
		public float Lod2Distance { get; set; }

		[FieldOffset(20, 80)]
		public float Lod3Distance { get; set; }

		[FieldOffset(24, 84)]
		public float Lod4Distance { get; set; }

		[FieldOffset(28, 88)]
		public float Lod5Distance { get; set; }

		[FieldOffset(32, 92)]
		public float Lod6Distance { get; set; }

		[FieldOffset(36, 96)]
		public float ShadowDistance { get; set; }

		[FieldOffset(40, 100)]
		public float CullScreenArea { get; set; }

		[FieldOffset(44, 104)]
		public string RuntimeShortName { get; set; }
	}
}
