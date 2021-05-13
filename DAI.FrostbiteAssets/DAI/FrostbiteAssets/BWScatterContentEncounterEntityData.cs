namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWScatterContentEncounterEntityData : BWEncounterEntityData
	{
		[FieldOffset(36, 120)]
		public ScatterContentSettings ScatterContentSettings { get; set; }
	}
}
