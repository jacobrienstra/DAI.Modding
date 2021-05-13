using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWGetStatValueEntityData : ActionIteratorEntityBaseData
	{
		[FieldOffset(20, 104)]
		public Realm Realm { get; set; }

		[FieldOffset(24, 112)]
		public ExternalObject<BWStat> Stat { get; set; }
	}
}
