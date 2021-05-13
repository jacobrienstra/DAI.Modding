using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundEntityTrackLayerData : TimelineTrackData
	{
		[FieldOffset(24, 128)]
		public string LayerName { get; set; }

		[FieldOffset(28, 136)]
		public List<ExternalObject<EntityData>> Keyframes { get; set; }

		public SoundEntityTrackLayerData()
		{
			Keyframes = new List<ExternalObject<EntityData>>();
		}
	}
}
