using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MusicInterfaceAsset : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<MusicEventData>> Events { get; set; }

		[FieldOffset(16, 80)]
		public List<ExternalObject<MusicEventData>> Parameters { get; set; }

		public MusicInterfaceAsset()
		{
			Events = new List<ExternalObject<MusicEventData>>();
			Parameters = new List<ExternalObject<MusicEventData>>();
		}
	}
}
