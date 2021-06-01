using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class LocatorEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public Realm Realm { get; set; }
	}
}
