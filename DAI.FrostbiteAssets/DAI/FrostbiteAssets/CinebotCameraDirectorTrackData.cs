using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotCameraDirectorTrackData : CameraDirectorTrackBaseData
	{
		[FieldOffset(32, 152)]
		public List<ExternalObject<GameObjectData>> Keyframes { get; set; }

		public CinebotCameraDirectorTrackData()
		{
			Keyframes = new List<ExternalObject<GameObjectData>>();
		}
	}
}
