using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class VoiceOverSpeakerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public LinearTransform Transform { get; set; }

		[FieldOffset(80, 160)]
		public List<string> Parameters { get; set; }

		[FieldOffset(84, 168)]
		public float OcclusionValue { get; set; }

		public VoiceOverSpeakerEntityData()
		{
			Parameters = new List<string>();
		}
	}
}
