using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotModeTrackData : CameraTrackBaseData
	{
		[FieldOffset(24, 128)]
		public ExternalObject<CinebotModeData> ModeData { get; set; }

		[FieldOffset(28, 136)]
		public List<ExternalObject<BWAreaTriggerEntityData>> Children { get; set; }

		[FieldOffset(32, 144)]
		public ExternalObject<DofTrackData> DofTrack { get; set; }

		public CinebotModeTrackData()
		{
			Children = new List<ExternalObject<BWAreaTriggerEntityData>>();
		}
	}
}
