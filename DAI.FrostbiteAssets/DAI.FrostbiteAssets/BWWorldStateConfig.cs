using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWWorldStateConfig : SystemSettings
	{
		[FieldOffset(16, 40)]
		public List<ExternalObject<SystemSettings>> Sets { get; set; }

		[FieldOffset(20, 48)]
		public PlotFlagReference StateInitializedFlag { get; set; }

		public BWWorldStateConfig()
		{
			Sets = new List<ExternalObject<SystemSettings>>();
		}
	}
}
