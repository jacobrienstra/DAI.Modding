using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlotConfigurationSettings : SystemSettings
	{
		[FieldOffset(16, 40)]
		public List<ExternalObject<GameSettings>> Configurations { get; set; }

		public PlotConfigurationSettings()
		{
			Configurations = new List<ExternalObject<GameSettings>>();
		}
	}
}
