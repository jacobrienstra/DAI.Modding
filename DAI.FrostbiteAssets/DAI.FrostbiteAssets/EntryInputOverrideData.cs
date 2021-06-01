namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EntryInputOverrideData : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<InputActionMappingsData> InputMapping { get; set; }
	}
}
