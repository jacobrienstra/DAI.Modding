using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CriteriaData : DataContainer
	{
		[FieldOffset(8, 24)]
		public float CompletionValue { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<Dummy> GateList { get; set; }

		[FieldOffset(16, 40)]
		public StatEvent Measuring { get; set; }

		[FieldOffset(20, 48)]
		public ExternalObject<StatsCategoryData> ParamX { get; set; }

		[FieldOffset(24, 56)]
		public ExternalObject<Dummy> ParamY { get; set; }

		[FieldOffset(28, 64)]
		public List<ExternalObject<Dummy>> OrParamsX { get; set; }

		[FieldOffset(32, 72)]
		public CriteriaType CriteriaType { get; set; }

		[FieldOffset(36, 80)]
		public LocalizedStringReference LocalizedDescription { get; set; }

		[FieldOffset(40, 104)]
		public float ScaleFactor { get; set; }

		[FieldOffset(44, 108)]
		public float Scale { get; set; }

		[FieldOffset(48, 112)]
		public bool ShouldSummarize { get; set; }

		[FieldOffset(49, 113)]
		public bool ShouldHide { get; set; }

		[FieldOffset(50, 114)]
		public bool CountEvents { get; set; }

		public CriteriaData()
		{
			OrParamsX = new List<ExternalObject<Dummy>>();
		}
	}
}
