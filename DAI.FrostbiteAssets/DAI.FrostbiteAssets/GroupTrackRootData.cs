using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GroupTrackRootData : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<CinematicLightEntityTrackData>> Children { get; set; }

		public GroupTrackRootData()
		{
			Children = new List<ExternalObject<CinematicLightEntityTrackData>>();
		}
	}
}
