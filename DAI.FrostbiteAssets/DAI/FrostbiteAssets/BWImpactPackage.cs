namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWImpactPackage : BWTimeline
	{
		[FieldOffset(36, 128)]
		public MaterialDecl MaterialPair { get; set; }

		[FieldOffset(40, 144)]
		public MaterialDecl CriticalHitMaterialPair { get; set; }

		[FieldOffset(44, 160)]
		public bool TriggerHitEnemyEvents { get; set; }
	}
}
