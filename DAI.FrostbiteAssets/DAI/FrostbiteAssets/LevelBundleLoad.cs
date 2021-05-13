namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LevelBundleLoad : LinkObject
	{
		[FieldOffset(0, 0)]
		public string Name { get; set; }

		[FieldOffset(4, 8)]
		public bool TryKeepBetweenLevels { get; set; }
	}
}
