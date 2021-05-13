namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EmitterPoint
	{
		[FieldOffset(0, 0)]
		public float X { get; set; }

		[FieldOffset(4, 4)]
		public float Y { get; set; }

		[FieldOffset(8, 8)]
		public float Z { get; set; }
	}
}
