using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CharacterStateData : DataContainer
	{
		[FieldOffset(8, 24)]
		public List<ExternalObject<CharacterPoseData>> PoseInfo { get; set; }

		public CharacterStateData()
		{
			PoseInfo = new List<ExternalObject<CharacterPoseData>>();
		}
	}
}
