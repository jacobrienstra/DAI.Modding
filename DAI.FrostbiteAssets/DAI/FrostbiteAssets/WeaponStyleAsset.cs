namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class WeaponStyleAsset : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public int WeaponStyle { get; set; }

		[FieldOffset(16, 80)]
		public BWTimelineReference TimelineRef { get; set; }
	}
}
