using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Vec4HubEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public int InputCount { get; set; }

		[FieldOffset(24, 104)]
		public int InputSelect { get; set; }
	}
}
