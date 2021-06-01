using System;
using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWCharacterMapPinState : LinkObject
	{
		[FieldOffset(0, 0)]
		public Vec3 InitialWorldPos { get; set; }

		[FieldOffset(16, 16)]
		public Guid PinID { get; set; }

		[FieldOffset(32, 32)]
		public int NameStringID { get; set; }

		[FieldOffset(36, 36)]
		public int PinCategory { get; set; }

		[FieldOffset(40, 40)]
		public List<PlotConditionReference> DisplayConditions { get; set; }

		[FieldOffset(44, 48)]
		public List<PlotActionReference> DiscoveryActions { get; set; }

		[FieldOffset(48, 56)]
		public List<ExternalObject<JournalTaskReference>> JournalTasks { get; set; }

		[FieldOffset(52, 64)]
		public int InitialFloor { get; set; }

		[FieldOffset(56, 68)]
		public bool UseTasksDisplayConditions { get; set; }

		[FieldOffset(57, 69)]
		public bool IgnoreDeath { get; set; }

		public BWCharacterMapPinState()
		{
			DisplayConditions = new List<PlotConditionReference>();
			DiscoveryActions = new List<PlotActionReference>();
			JournalTasks = new List<ExternalObject<JournalTaskReference>>();
		}
	}
}
