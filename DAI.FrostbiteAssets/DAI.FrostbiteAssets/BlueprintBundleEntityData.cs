using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BlueprintBundleEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public StreamRealm StreamRealm { get; set; }

		[FieldOffset(20, 100)]
		public uint BlueprintBundleHash { get; set; }
	}
}
