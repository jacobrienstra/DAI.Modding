using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CountDownEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public int StartValue { get; set; }

		[FieldOffset(20, 100)]
		public Realm Realm { get; set; }

		[FieldOffset(24, 104)]
		public bool RunOnce { get; set; }
	}
}
