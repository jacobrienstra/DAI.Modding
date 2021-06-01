using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWSpawnWaveEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public int DeathThreshold { get; set; }

		[FieldOffset(20, 100)]
		public float Rate { get; set; }

		[FieldOffset(24, 104)]
		public float SpawnTryRate { get; set; }

		[FieldOffset(28, 108)]
		public int MaxAliveEnemiesCount { get; set; }

		[FieldOffset(32, 112)]
		public int MinSpawnAmount { get; set; }

		[FieldOffset(36, 116)]
		public int MaxSpawnAmount { get; set; }

		[FieldOffset(40, 120)]
		public float ClusterSpawnRadius { get; set; }

		[FieldOffset(44, 124)]
		public float AmbientActionProximity { get; set; }

		[FieldOffset(48, 128)]
		public UpdatePass UpdatePass { get; set; }

		[FieldOffset(52, 132)]
		public bool MoveToPartyOnSpawn { get; set; }

		[FieldOffset(53, 133)]
		public bool SpawnSelectionRandomized { get; set; }

		[FieldOffset(54, 134)]
		public bool ContinuousSpawning { get; set; }

		[FieldOffset(55, 135)]
		public bool SaveState { get; set; }
	}
}
