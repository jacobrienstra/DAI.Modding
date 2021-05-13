namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EditableActionMap : LinkObject
	{
		[FieldOffset(0, 0)]
		public string Id { get; set; }

		[FieldOffset(4, 8)]
		public string NameId { get; set; }

		[FieldOffset(8, 16)]
		public ExternalObject<EntryInputActionMapsData> ActionMap { get; set; }

		[FieldOffset(12, 24)]
		public EditableActions ConfigurationLayout { get; set; }
	}
}
