using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlotFlagUpdateTelemetryManagerData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<PlotFlagReference> RomancePlotFlags { get; set; }

		[FieldOffset(20, 104)]
		public List<PlotFlagReference> PotionUnlockPlotFlags { get; set; }

		[FieldOffset(24, 112)]
		public List<PlotFlagReference> TutorialPlotFlags { get; set; }

		[FieldOffset(28, 120)]
		public List<PlotFlagReference> PrologueProgressPlotFlags { get; set; }

		[FieldOffset(32, 128)]
		public List<PlotFlagReference> MainStoryProgressPlotFlags { get; set; }

		[FieldOffset(36, 136)]
		public List<PlotFlagReference> SpecializationPlotFlags { get; set; }

		[FieldOffset(40, 144)]
		public List<PlotFlagReference> KeepPlotFlags { get; set; }

		[FieldOffset(44, 152)]
		public List<PlotFlagReference> BaseCustomizationPlotFlags { get; set; }

		[FieldOffset(48, 160)]
		public List<PlotFlagReference> DLCBluePlotFlags { get; set; }

		public PlotFlagUpdateTelemetryManagerData()
		{
			RomancePlotFlags = new List<PlotFlagReference>();
			PotionUnlockPlotFlags = new List<PlotFlagReference>();
			TutorialPlotFlags = new List<PlotFlagReference>();
			PrologueProgressPlotFlags = new List<PlotFlagReference>();
			MainStoryProgressPlotFlags = new List<PlotFlagReference>();
			SpecializationPlotFlags = new List<PlotFlagReference>();
			KeepPlotFlags = new List<PlotFlagReference>();
			BaseCustomizationPlotFlags = new List<PlotFlagReference>();
			DLCBluePlotFlags = new List<PlotFlagReference>();
		}
	}
}
