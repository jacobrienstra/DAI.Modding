namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWVariableEntityBaseData : EntityData
	{
		[FieldOffset(16, 96)]
		public bool TriggerOnPropertyChange { get; set; }
	}
}
