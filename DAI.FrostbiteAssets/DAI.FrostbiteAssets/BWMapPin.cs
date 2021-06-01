using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWMapPin : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public int ID { get; set; }

		[FieldOffset(16, 80)]
		public Vec3 WorldPos { get; set; }

		[FieldOffset(32, 96)]
		public int PinCategory { get; set; }

		[FieldOffset(36, 104)]
		public LocalizedStringReference TitleReference { get; set; }

		[FieldOffset(40, 128)]
		public List<PlotConditionReference> DisplayConditions { get; set; }

		[FieldOffset(44, 136)]
		public List<PlotConditionReference> EnabledConditions { get; set; }

		[FieldOffset(48, 144)]
		public List<PlotActionReference> DiscoveryActions { get; set; }

		[FieldOffset(52, 152)]
		public List<ExternalObject<BWMapPin>> JournalTasks { get; set; }

		[FieldOffset(56, 160)]
		public bool UseTasksDisplayConditions { get; set; }

		public BWMapPin()
		{
			DisplayConditions = new List<PlotConditionReference>();
			EnabledConditions = new List<PlotConditionReference>();
			DiscoveryActions = new List<PlotActionReference>();
			JournalTasks = new List<ExternalObject<BWMapPin>>();
		}
	}
}
