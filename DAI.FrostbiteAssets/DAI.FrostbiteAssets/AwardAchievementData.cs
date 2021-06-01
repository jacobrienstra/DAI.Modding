namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AwardAchievementData : AwardData
	{
		[FieldOffset(100, 296)]
		public XboneAchievementSettings XboneSpecific { get; set; }
	}
}
