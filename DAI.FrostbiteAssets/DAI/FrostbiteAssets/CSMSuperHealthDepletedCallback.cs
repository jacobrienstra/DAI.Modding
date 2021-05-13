namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMSuperHealthDepletedCallback : SuperHealthDepletedCallback
	{
		[FieldOffset(8, 24)]
		public BWTimelineReference SuperHealthDown { get; set; }
	}
}
