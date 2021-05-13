namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FloatProvider_Const : FloatProvider
	{
		[FieldOffset(8, 32)]
		public float ConstValue { get; set; }
	}
}
