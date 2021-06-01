using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CameraDirectorTrackBaseData : TimelineTrackData
	{
		[FieldOffset(24, 128)]
		public List<ExternalObject<GameObjectData>> Children { get; set; }

		[FieldOffset(28, 136)]
		public ExternalObject<CameraTrackData> PostTimelineCamera { get; set; }

		public CameraDirectorTrackBaseData()
		{
			Children = new List<ExternalObject<GameObjectData>>();
		}
	}
}
