using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CreatureBoneTrackingData : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<MovementTrackedBoneData>> Bones { get; set; }

		public CreatureBoneTrackingData()
		{
			Bones = new List<ExternalObject<MovementTrackedBoneData>>();
		}
	}
}
