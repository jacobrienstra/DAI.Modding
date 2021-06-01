namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWFilterObjectsSubtractData : BWGetObjectsEntityBaseData
	{
		[FieldOffset(20, 104)]
		public ExternalObject<Dummy> SubtractList { get; set; }
	}
}
