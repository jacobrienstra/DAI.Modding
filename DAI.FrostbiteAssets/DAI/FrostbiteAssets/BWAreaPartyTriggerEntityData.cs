namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWAreaPartyTriggerEntityData : TriggerEntityData
	{
		[FieldOffset(96, 192)]
		public int MinimumActors { get; set; }
	}
}
