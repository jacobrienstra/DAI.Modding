using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class WriteStaticAntGameStateEntitySpawnData : DataContainer
	{
		[FieldOffset(8, 24)]
		public List<ExternalObject<Asset>> AntGameStates { get; set; }

		[FieldOffset(12, 32)]
		public uint AntAssetCount { get; set; }

		[FieldOffset(16, 36)]
		public bool WriteOnceOnSpawn { get; set; }

		public WriteStaticAntGameStateEntitySpawnData()
		{
			AntGameStates = new List<ExternalObject<Asset>>();
		}
	}
}
