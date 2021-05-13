namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CustomDeathScreen : LinkObject
	{
		[FieldOffset(0, 0)]
		public string ImageTexturePath { get; set; }

		[FieldOffset(4, 8)]
		public int CustomDeathTitleID { get; set; }

		[FieldOffset(8, 12)]
		public int CustomDeathMessageID { get; set; }
	}
}
