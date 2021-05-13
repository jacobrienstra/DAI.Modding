using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class WarTableEntry : CodexEntry
	{
		[FieldOffset(48, 184)]
		public OperationType OperationType { get; set; }

		[FieldOffset(52, 188)]
		public int DurationInRealWorldMinutes { get; set; }

		[FieldOffset(56, 192)]
		public WarTableEntryType PreferredSpecialist { get; set; }

		[FieldOffset(60, 196)]
		public int Cost { get; set; }

		[FieldOffset(64, 200)]
		public string LevelToLoadName { get; set; }

		[FieldOffset(68, 208)]
		public int StartPointID { get; set; }

		[FieldOffset(72, 216)]
		public LocalizedStringReference LevelNameLocalizedString { get; set; }

		[FieldOffset(76, 240)]
		public PlotFlagReference CompletedPlotFlag { get; set; }

		[FieldOffset(92, 280)]
		public PlotFlagReference NewStatePlotFlag { get; set; }

		[FieldOffset(108, 320)]
		public List<PlotActionReference> CompletionActions { get; set; }

		[FieldOffset(112, 328)]
		public List<PlotActionReference> AfterActionReportActions { get; set; }

		[FieldOffset(116, 336)]
		public List<ExternalObject<WarTableEntry>> Specialists { get; set; }

		[FieldOffset(120, 344)]
		public string InstallGroup { get; set; }

		[FieldOffset(124, 352)]
		public bool CritPathDependent { get; set; }

		[FieldOffset(125, 353)]
		public bool IsAvailableInTrial { get; set; }

		public WarTableEntry()
		{
			CompletionActions = new List<PlotActionReference>();
			AfterActionReportActions = new List<PlotActionReference>();
			Specialists = new List<ExternalObject<WarTableEntry>>();
		}
	}
}
