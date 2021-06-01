namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_DA3ApplyTimeline : BWCSMAction_ApplyTimeline
	{
		[FieldOffset(44, 104)]
		public bool AOECasting { get; set; }
	}
}
