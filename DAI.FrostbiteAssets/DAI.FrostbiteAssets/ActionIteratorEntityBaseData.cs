namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ActionIteratorEntityBaseData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<Dummy> InputList { get; set; }
	}
}
