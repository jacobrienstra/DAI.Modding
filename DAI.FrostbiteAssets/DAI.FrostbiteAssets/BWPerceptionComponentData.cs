using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWPerceptionComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public ExternalObject<BWRange> CombatPerceptionRange { get; set; }

		[FieldOffset(100, 184)]
		public ExternalObject<BWRange> PatrollingPerceptionRange { get; set; }

		[FieldOffset(104, 192)]
		public ExternalObject<BWRange> ObliviousPerceptionRange { get; set; }

		[FieldOffset(108, 200)]
		public ExternalObject<BWRange> CombatPerceptionRangeAural { get; set; }

		[FieldOffset(112, 208)]
		public ExternalObject<BWRange> PatrollingPerceptionRangeAural { get; set; }

		[FieldOffset(116, 216)]
		public ExternalObject<BWRange> ObliviousPerceptionRangeAural { get; set; }

		[FieldOffset(120, 224)]
		public PerceptionState DefaultPerceptionState { get; set; }

		[FieldOffset(124, 228)]
		public bool HasOwnUpdate { get; set; }

		[FieldOffset(125, 229)]
		public bool AllyVisualPerceptionLimited { get; set; }
	}
}
