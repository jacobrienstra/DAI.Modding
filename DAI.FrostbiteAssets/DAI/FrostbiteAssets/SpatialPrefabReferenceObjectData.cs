using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SpatialPrefabReferenceObjectData : SpatialReferenceObjectData
	{
		[FieldOffset(112, 256)]
		public BlueprintPersistenceSetting PersistenceSetting { get; set; }
	}
}
