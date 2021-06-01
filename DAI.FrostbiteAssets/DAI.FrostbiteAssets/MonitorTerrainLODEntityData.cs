namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class MonitorTerrainLODEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public LinearTransform MonitorTransform { get; set; }

		[FieldOffset(80, 160)]
		public float RayCastVerticalOffsetBegin { get; set; }

		[FieldOffset(84, 164)]
		public float RayCastVerticalOffsetEnd { get; set; }

		[FieldOffset(88, 168)]
		public float TranslationToleranceThreshold { get; set; }

		[FieldOffset(92, 172)]
		public float AdditionalVerticaloffset { get; set; }

		[FieldOffset(96, 176)]
		public uint UpdateInterval { get; set; }

		[FieldOffset(100, 180)]
		public bool EndMonitoringOnBestLODReached { get; set; }

		[FieldOffset(101, 181)]
		public bool AutoStartMonitoring { get; set; }

		[FieldOffset(102, 182)]
		public bool IgnoreWater { get; set; }

		[FieldOffset(103, 183)]
		public bool IgnoreRagdolls { get; set; }

		[FieldOffset(104, 184)]
		public bool IgnoreCharacters { get; set; }

		[FieldOffset(105, 185)]
		public bool IgnoreSimpleShapes { get; set; }

		[FieldOffset(106, 186)]
		public bool Enabled { get; set; }

		[FieldOffset(107, 187)]
		public bool Align { get; set; }
	}
}
