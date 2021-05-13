namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class UIElementColor : LinkObject
	{
		[FieldOffset(0, 0)]
		public Vec3 Rgb { get; set; }

		[FieldOffset(16, 16)]
		public float Alpha { get; set; }

		[FieldOffset(20, 24)]
		public string PropertyName { get; set; }
	}
}
