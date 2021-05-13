using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PoseTrackData : ANTLayerData
	{
		[FieldOffset(28, 136)]
		public List<ExternalObject<EntityData>> Keyframes { get; set; }

		public PoseTrackData()
		{
			Keyframes = new List<ExternalObject<EntityData>>();
		}
	}
}
