using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LinkChannel : LinkObject
	{
		[FieldOffset(0, 0)]
		public Realm Realm { get; set; }

		[FieldOffset(4, 4)]
		public int Id { get; set; }

		[FieldOffset(8, 8)]
		public int LinkTypeHash { get; set; }
	}
}
