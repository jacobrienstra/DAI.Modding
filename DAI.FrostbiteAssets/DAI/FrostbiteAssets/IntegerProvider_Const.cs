namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class IntegerProvider_Const : IntegerProvider
	{
		[FieldOffset(8, 32)]
		public int ConstValue { get; set; }
	}
}
