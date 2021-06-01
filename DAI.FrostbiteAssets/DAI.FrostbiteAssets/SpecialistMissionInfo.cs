using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SpecialistMissionInfo : DataContainer
	{
		[FieldOffset(8, 24)]
		public LocalizedStringReference OperationTextReference { get; set; }

		[FieldOffset(12, 48)]
		public PlotFlagReference SpecialistPlotFlag { get; set; }

		[FieldOffset(28, 88)]
		public List<ExternalObject<WarTableEntry>> Rewards { get; set; }

		[FieldOffset(32, 96)]
		public LocalizedStringReference OperationToUnlockName { get; set; }

		public SpecialistMissionInfo()
		{
			Rewards = new List<ExternalObject<WarTableEntry>>();
		}
	}
}
