namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RuntimeStyleShape
	{
		[FieldOffset(0, 0)]
		public uint ShapeId { get; set; }

		[FieldOffset(4, 4)]
		public float Value { get; set; }
	}
}
