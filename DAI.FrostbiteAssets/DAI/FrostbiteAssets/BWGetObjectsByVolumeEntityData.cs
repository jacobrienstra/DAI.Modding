using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWGetObjectsByVolumeEntityData : BWGetObjectsEntityBaseData
	{
		[FieldOffset(20, 104)]
		public VolumeObjectFilterType ObjectsFilter { get; set; }
	}
}
