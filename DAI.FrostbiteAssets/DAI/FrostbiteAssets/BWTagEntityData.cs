using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWTagEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public Realm Realm { get; set; }

		[FieldOffset(84, 184)]
		public string Tag { get; set; }
	}
}
