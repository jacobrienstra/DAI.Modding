namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(1)]
	public class WaterEntityClipInfo
	{
		[FieldOffset(0, 0)]
		public bool Enable { get; set; }

		[FieldOffset(1, 1)]
		public bool ClipFaceNorth { get; set; }

		[FieldOffset(2, 2)]
		public bool ClipFaceSouth { get; set; }

		[FieldOffset(3, 3)]
		public bool ClipFaceEast { get; set; }

		[FieldOffset(4, 4)]
		public bool ClipFaceWest { get; set; }
	}
}
