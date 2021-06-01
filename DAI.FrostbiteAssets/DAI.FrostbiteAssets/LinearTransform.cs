namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public struct LinearTransform
	{
		[FieldOffset(0, 0)]
		public Vec3 right { get; set; }

		[FieldOffset(16, 16)]
		public Vec3 up { get; set; }

		[FieldOffset(32, 32)]
		public Vec3 forward { get; set; }

		[FieldOffset(48, 48)]
		public Vec3 trans { get; set; }
	}
}
