using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DofTrackData : PropertyTrackBaseData
	{
		[FieldOffset(32, 144)]
		public List<ExternalObject<EntityData>> Keyframes { get; set; }

		public DofTrackData()
		{
			Keyframes = new List<ExternalObject<EntityData>>();
		}
	}
}
