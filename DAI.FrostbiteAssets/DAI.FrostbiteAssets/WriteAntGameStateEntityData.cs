using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class WriteAntGameStateEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<ExternalObject<EntityData>> AntGameStates { get; set; }

		[FieldOffset(20, 104)]
		public int NumProperties { get; set; }

		[FieldOffset(24, 108)]
		public int NumAntAssets { get; set; }

		[FieldOffset(28, 112)]
		public bool StartWritingContinouslyOnSpawn { get; set; }

		[FieldOffset(29, 113)]
		public bool WriteOnceOnSpawn { get; set; }

		public WriteAntGameStateEntityData()
		{
			AntGameStates = new List<ExternalObject<EntityData>>();
		}
	}
}
