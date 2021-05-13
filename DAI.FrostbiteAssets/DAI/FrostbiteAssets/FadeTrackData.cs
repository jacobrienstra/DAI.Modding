using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FadeTrackData : TimelineTrackData
	{
		[FieldOffset(24, 128)]
		public List<ExternalObject<GameObjectData>> Keyframes { get; set; }

		[FieldOffset(28, 136)]
		public bool FadeScreen { get; set; }

		[FieldOffset(29, 137)]
		public bool FadeUI { get; set; }

		[FieldOffset(30, 138)]
		public bool FadeAudio { get; set; }

		[FieldOffset(31, 139)]
		public bool FadeMovie { get; set; }

		[FieldOffset(32, 140)]
		public bool FadeRumble { get; set; }

		[FieldOffset(33, 141)]
		public bool BlockInput { get; set; }

		public FadeTrackData()
		{
			Keyframes = new List<ExternalObject<GameObjectData>>();
		}
	}
}
