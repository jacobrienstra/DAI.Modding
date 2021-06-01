namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class Vector3Provider_Constant : Vector3Provider
	{
		[FieldOffset(16, 32)]
		public Vec3 Constant { get; set; }
	}
}
