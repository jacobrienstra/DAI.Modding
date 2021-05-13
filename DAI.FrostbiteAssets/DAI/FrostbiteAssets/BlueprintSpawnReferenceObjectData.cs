using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BlueprintSpawnReferenceObjectData : ReferenceObjectData
	{
		[FieldOffset(112, 240)]
		public List<ExternalObject<GameObjectData>> ExtraSpawnData { get; set; }

		[FieldOffset(116, 248)]
		public float InitialSpawnDelay { get; set; }

		[FieldOffset(120, 252)]
		public float SpawnDelay { get; set; }

		[FieldOffset(124, 256)]
		public int MaxCount { get; set; }

		[FieldOffset(128, 260)]
		public int MaxCountSimultaneously { get; set; }

		[FieldOffset(132, 264)]
		public TimeDeltaType TimeDeltaType { get; set; }

		[FieldOffset(136, 268)]
		public bool SaveState { get; set; }

		[FieldOffset(137, 269)]
		public bool CacheLinkArray { get; set; }

		[FieldOffset(138, 270)]
		public bool InitialAutoSpawn { get; set; }

		[FieldOffset(139, 271)]
		public bool AutoSpawn { get; set; }

		[FieldOffset(140, 272)]
		public bool QueueSpawnEvent { get; set; }

		[FieldOffset(141, 273)]
		public bool UseAsSpawnPoint { get; set; }

		[FieldOffset(142, 274)]
		public bool SpawnsOccupyLocations { get; set; }

		public BlueprintSpawnReferenceObjectData()
		{
			ExtraSpawnData = new List<ExternalObject<GameObjectData>>();
		}
	}
}
