namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MaterialPropertyCharacterEffectsData : PhysicsMaterialRelationPropertyData
	{
		[FieldOffset(8, 40)]
		public BWTimelineReference TimelineRef { get; set; }
	}
}
