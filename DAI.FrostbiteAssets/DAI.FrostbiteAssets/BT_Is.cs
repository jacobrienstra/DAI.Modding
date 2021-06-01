namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_Is : BTEvalFunc
	{
		[FieldOffset(16, 40)]
		public bool Result { get; set; }
	}
}
