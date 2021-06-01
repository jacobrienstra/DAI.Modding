using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SubLevelStreamingTriggerState : LinkObject
	{
		[FieldOffset(0, 0)]
		public string StateName { get; set; }

		[FieldOffset(4, 8)]
		public uint SubLevelLinkPinHash { get; set; }

		[FieldOffset(8, 12)]
		public uint ActivatingEventPinHash { get; set; }

		[FieldOffset(12, 16)]
		public uint DeactivatingEventPinHash { get; set; }

		[FieldOffset(16, 20)]
		public uint ActivePropertyPinHash { get; set; }

		[FieldOffset(20, 24)]
		public uint PlotActivePropertyPinHash { get; set; }

		[FieldOffset(24, 28)]
		public SubLevelStreamingNonSpatialRequestType NonSpatialRequestType { get; set; }

		[FieldOffset(28, 32)]
		public List<PlotConditionReference> Conditions { get; set; }

		public SubLevelStreamingTriggerState()
		{
			Conditions = new List<PlotConditionReference>();
		}
	}
}
