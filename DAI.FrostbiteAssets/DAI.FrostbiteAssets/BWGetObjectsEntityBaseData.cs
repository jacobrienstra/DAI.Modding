namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWGetObjectsEntityBaseData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<Dummy> InputObjects { get; set; }
	}
}
