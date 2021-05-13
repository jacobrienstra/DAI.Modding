using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StatEventTriggerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public StatEvent StatEvent { get; set; }

		[FieldOffset(20, 104)]
		public string MiscParamX { get; set; }

		[FieldOffset(24, 112)]
		public string MiscParamY { get; set; }

		[FieldOffset(28, 120)]
		public bool SendToAll { get; set; }
	}
}
