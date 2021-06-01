namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class XboneAchievementSettings : LinkObject
	{
		[FieldOffset(0, 0)]
		public uint CompletionValue { get; set; }
	}
}
