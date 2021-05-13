namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Vector3Provider_Left : Vector3Provider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<AmbientLocationTransform> Transform { get; set; }
	}
}
