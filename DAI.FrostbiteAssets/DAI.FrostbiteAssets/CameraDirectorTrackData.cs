using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CameraDirectorTrackData : CameraDirectorTrackBaseData
	{
		[FieldOffset(32, 152)]
		public List<ExternalObject<EntityData>> Keyframes { get; set; }

		public CameraDirectorTrackData()
		{
			Keyframes = new List<ExternalObject<EntityData>>();
		}
	}
}
