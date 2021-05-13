namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GameTipEntry : LinkObject
	{
		[FieldOffset(0, 0)]
		public string TextureId { get; set; }

		[FieldOffset(4, 8)]
		public int TextStringId { get; set; }
	}
}
