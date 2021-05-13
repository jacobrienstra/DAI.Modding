namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class TransformProvider_Orientation : TransformProvider
	{
		[FieldOffset(16, 32)]
		public Vec3 Orientation { get; set; }
	}
}
