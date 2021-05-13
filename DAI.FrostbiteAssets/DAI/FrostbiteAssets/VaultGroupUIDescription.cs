using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class VaultGroupUIDescription : DataContainer
	{
		[FieldOffset(8, 24)]
		public PlotFlagReference PlotFlag { get; set; }

		[FieldOffset(24, 64)]
		public List<uint> TriggerValues { get; set; }

		[FieldOffset(28, 72)]
		public string DisplayString { get; set; }

		[FieldOffset(32, 80)]
		public List<PlotFlagReference> Arguments { get; set; }

		[FieldOffset(36, 88)]
		public List<ExternalObject<Dummy>> SubDescriptions { get; set; }

		public VaultGroupUIDescription()
		{
			TriggerValues = new List<uint>();
			Arguments = new List<PlotFlagReference>();
			SubDescriptions = new List<ExternalObject<Dummy>>();
		}
	}
}
