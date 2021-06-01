namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UILevelStatData : LinkObject
	{
		[FieldOffset(0, 0)]
		public string StatEasy { get; set; }

		[FieldOffset(4, 8)]
		public string StatMedium { get; set; }

		[FieldOffset(8, 16)]
		public string StatHard { get; set; }

		[FieldOffset(12, 24)]
		public string StatHardcore { get; set; }
	}
}
