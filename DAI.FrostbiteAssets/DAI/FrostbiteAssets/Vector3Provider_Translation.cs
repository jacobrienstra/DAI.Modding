namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Vector3Provider_Translation : Vector3Provider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<TransformProvider> Transform { get; set; }
	}
}
