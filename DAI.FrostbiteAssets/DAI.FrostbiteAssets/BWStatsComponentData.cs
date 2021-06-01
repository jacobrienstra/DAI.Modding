using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWStatsComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public ExternalObject<BWStatList> StatList { get; set; }

		[FieldOffset(100, 184)]
		public List<BWModifiableStatValuePair> StatModifiers { get; set; }

		[FieldOffset(104, 192)]
		public List<BWStatValuePair> BaseValueOverrides { get; set; }

		[FieldOffset(108, 200)]
		public List<BWStatValuePair> UpperLimitOverrides { get; set; }

		[FieldOffset(112, 208)]
		public ExternalObject<BWIntegralStat> creatureLevelStat { get; set; }

		[FieldOffset(116, 216)]
		public ExternalObject<BWStat> creatureLevelOffsetStat { get; set; }

		public BWStatsComponentData()
		{
			StatModifiers = new List<BWModifiableStatValuePair>();
			BaseValueOverrides = new List<BWStatValuePair>();
			UpperLimitOverrides = new List<BWStatValuePair>();
		}
	}
}
