namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EntryInputOverrideEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public EntryInputOverrideData InputOverrideData { get; set; }
	}
}
