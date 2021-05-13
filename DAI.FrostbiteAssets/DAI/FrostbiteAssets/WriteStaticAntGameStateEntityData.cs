using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class WriteStaticAntGameStateEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<ExternalObject<DataContainer>> AntGameStates { get; set; }

		[FieldOffset(20, 104)]
		public uint AntAssetCount { get; set; }

		[FieldOffset(24, 108)]
		public bool WriteOnceOnSpawn { get; set; }

		public WriteStaticAntGameStateEntityData()
		{
			AntGameStates = new List<ExternalObject<DataContainer>>();
		}
	}
}
