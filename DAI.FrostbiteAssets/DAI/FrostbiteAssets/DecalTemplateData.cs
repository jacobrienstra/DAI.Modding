namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DecalTemplateData : Asset
	{
		[FieldOffset(12, 72)]
		public float Size { get; set; }

		[FieldOffset(16, 76)]
		public float RandomSize { get; set; }

		[FieldOffset(20, 80)]
		public float Rotation { get; set; }

		[FieldOffset(24, 84)]
		public float RandomRotation { get; set; }

		[FieldOffset(28, 88)]
		public float SpawnRadiusMultiplier { get; set; }

		[FieldOffset(32, 92)]
		public float ClipAngle { get; set; }

		[FieldOffset(36, 96)]
		public float ProximityRadiusFactor { get; set; }

		[FieldOffset(40, 100)]
		public float NormalOffset { get; set; }

		[FieldOffset(44, 104)]
		public DecalAtlasTile AtlasTile { get; set; }

		[FieldOffset(64, 128)]
		public SurfaceShaderInstanceDataStruct Shader { get; set; }

		[FieldOffset(84, 168)]
		public int MeshUVIndex { get; set; }

		[FieldOffset(88, 172)]
		public byte SortingPriority { get; set; }

		[FieldOffset(89, 173)]
		public bool Projected { get; set; }

		[FieldOffset(90, 174)]
		public bool ProjectMultiple { get; set; }
	}
}
