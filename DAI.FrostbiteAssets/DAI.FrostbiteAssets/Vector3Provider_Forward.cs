namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Vector3Provider_Forward : Vector3Provider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<TransformProvider> Transform { get; set; }
	}
}
