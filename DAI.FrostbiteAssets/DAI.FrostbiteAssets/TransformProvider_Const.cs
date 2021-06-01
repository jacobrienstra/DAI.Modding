namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class TransformProvider_Const : TransformProvider
	{
		[FieldOffset(16, 32)]
		public LinearTransform Transform { get; set; }
	}
}
