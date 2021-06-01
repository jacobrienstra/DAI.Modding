namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SetPlaceholderArmorEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public int PlaceholderArmorIndex { get; set; }

		[FieldOffset(20, 100)]
		public bool TriggerOnPropertyChange { get; set; }
	}
}
