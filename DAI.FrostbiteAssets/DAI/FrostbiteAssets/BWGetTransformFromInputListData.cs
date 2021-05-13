namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWGetTransformFromInputListData : BWGetTransformBaseData
	{
		[FieldOffset(24, 104)]
		public ExternalObject<Dummy> InputList { get; set; }
	}
}
