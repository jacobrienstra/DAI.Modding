namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ScatterContentSpawnBlockerData : EntityData
	{
		[FieldOffset(16, 96)]
		public float CooldownDuration { get; set; }
	}
}
