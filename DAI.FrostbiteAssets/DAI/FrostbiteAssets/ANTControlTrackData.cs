using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ANTControlTrackData : LinkTrackData
	{
		[FieldOffset(32, 144)]
		public List<ExternalObject<GameObjectData>> LayerTracks { get; set; }

		[FieldOffset(36, 152)]
		public List<int> SkipToEndBones { get; set; }

		[FieldOffset(40, 160)]
		public List<LinearTransform> SkipToEndTransforms { get; set; }

		[FieldOffset(44, 168)]
		public bool HideWhenNoClip { get; set; }

		[FieldOffset(45, 169)]
		public bool ForceDisableAnimationLOD { get; set; }

		[FieldOffset(46, 170)]
		public bool AllowPreviousAnimationsToCarryForward { get; set; }

		public ANTControlTrackData()
		{
			LayerTracks = new List<ExternalObject<GameObjectData>>();
			SkipToEndBones = new List<int>();
			SkipToEndTransforms = new List<LinearTransform>();
		}
	}
}
