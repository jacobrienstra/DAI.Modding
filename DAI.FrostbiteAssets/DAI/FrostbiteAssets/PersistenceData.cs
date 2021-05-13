using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PersistenceData : AbstractPersistenceData
	{
		[FieldOffset(12, 72)]
		public string PersistenceName { get; set; }

		[FieldOffset(16, 80)]
		public string ClubPersistenceName { get; set; }

		[FieldOffset(20, 88)]
		public List<PersistentValueTemplateData> Values { get; set; }

		[FieldOffset(24, 96)]
		public ExternalObject<Dummy> ServerDefaultGroup { get; set; }

		[FieldOffset(28, 104)]
		public ExternalObject<Dummy> ClientDefaultGroup { get; set; }

		[FieldOffset(32, 112)]
		public ExternalObject<Dummy> RetentionPolicy { get; set; }

		[FieldOffset(36, 120)]
		public List<PersistenceConsumableMapping> ConsumableMappings { get; set; }

		[FieldOffset(40, 128)]
		public bool DeltaGameReports { get; set; }

		[FieldOffset(41, 129)]
		public bool HistoryDaily { get; set; }

		[FieldOffset(42, 130)]
		public bool HistoryWeekly { get; set; }

		[FieldOffset(43, 131)]
		public bool HistoryMonthly { get; set; }

		[FieldOffset(44, 132)]
		public bool OutputProperties { get; set; }

		public PersistenceData()
		{
			Values = new List<PersistentValueTemplateData>();
			ConsumableMappings = new List<PersistenceConsumableMapping>();
		}
	}
}
