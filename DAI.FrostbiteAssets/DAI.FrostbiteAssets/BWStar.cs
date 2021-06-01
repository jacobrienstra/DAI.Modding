namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWStar : Asset
	{
		[FieldOffset(12, 72)]
		public int ID { get; set; }

		[FieldOffset(16, 76)]
		public Vec2 WorldPos { get; set; }
	}
}
