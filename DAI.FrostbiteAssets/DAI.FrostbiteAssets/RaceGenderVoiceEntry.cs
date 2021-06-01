using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RaceGenderVoiceEntry : DataContainer
	{
		[FieldOffset(8, 24)]
		public int GenderId { get; set; }

		[FieldOffset(12, 28)]
		public int RaceId { get; set; }

		[FieldOffset(16, 32)]
		public List<VoiceIdEntry> VoiceIds { get; set; }

		public RaceGenderVoiceEntry()
		{
			VoiceIds = new List<VoiceIdEntry>();
		}
	}
}
