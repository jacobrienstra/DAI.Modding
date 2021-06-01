using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ReadAntGameStateEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<ExternalObject<BWRemoveTimelineEntityData>> AntGameStates { get; set; }

		[FieldOffset(20, 104)]
		public int NumProperties { get; set; }

		[FieldOffset(24, 108)]
		public int NumAntAssets { get; set; }

		[FieldOffset(28, 112)]
		public bool StartReadingContinouslyOnSpawn { get; set; }

		[FieldOffset(29, 113)]
		public bool ReadOnceOnSpawn { get; set; }

		public ReadAntGameStateEntityData()
		{
			AntGameStates = new List<ExternalObject<BWRemoveTimelineEntityData>>();
		}
	}
}
