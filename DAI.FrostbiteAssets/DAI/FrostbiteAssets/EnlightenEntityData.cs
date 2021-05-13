using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EnlightenEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public int Priority { get; set; }

		[FieldOffset(20, 100)]
		public Realm Realm { get; set; }

		[FieldOffset(24, 104)]
		public bool Enable { get; set; }
	}
}
