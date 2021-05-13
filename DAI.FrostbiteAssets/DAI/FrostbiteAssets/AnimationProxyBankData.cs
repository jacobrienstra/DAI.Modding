using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AnimationProxyBankData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 104)]
		public AntRef ProxyBank { get; set; }

		[FieldOffset(40, 152)]
		public AntRef ProxyBankPointer { get; set; }
	}
}
