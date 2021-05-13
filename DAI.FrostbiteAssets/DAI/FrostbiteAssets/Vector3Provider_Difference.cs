namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Vector3Provider_Difference : Vector3Provider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<Vector3Provider_Translation> A { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<Vector3Provider_Translation> B { get; set; }
	}
}
