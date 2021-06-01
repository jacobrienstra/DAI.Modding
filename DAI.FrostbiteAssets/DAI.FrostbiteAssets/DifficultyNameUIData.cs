namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DifficultyNameUIData : LinkObject
	{
		[FieldOffset(0, 0)]
		public int DifficultyID { get; set; }

		[FieldOffset(4, 8)]
		public LocalizedStringReference DifficultyName { get; set; }
	}
}
