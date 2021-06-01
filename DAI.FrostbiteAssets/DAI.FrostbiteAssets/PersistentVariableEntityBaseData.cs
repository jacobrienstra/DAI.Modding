namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PersistentVariableEntityBaseData : EntityData
	{
		[FieldOffset(16, 96)]
		public bool TriggerOnPropertyChange { get; set; }
	}
}
