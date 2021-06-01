namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TacticalBrainComponentSpawnData : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<BehaviorTreeData> CombatTactics { get; set; }
	}
}
