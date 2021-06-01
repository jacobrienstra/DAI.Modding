using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlotFlagsDefaultValues : DataContainer
	{
		[FieldOffset(8, 24)]
		public List<byte> IntIndexes { get; set; }

		[FieldOffset(12, 32)]
		public List<PlotFlagId> IntFlagIds { get; set; }

		[FieldOffset(16, 40)]
		public List<Dummy> FloatIndexes { get; set; }

		[FieldOffset(20, 48)]
		public List<PlotFlagId> FloatFlagIds { get; set; }

		[FieldOffset(24, 56)]
		public List<ushort> DefaultIntValues { get; set; }

		[FieldOffset(28, 64)]
		public List<Dummy> DefaultFloatValuesCompressed { get; set; }

		public PlotFlagsDefaultValues()
		{
			IntIndexes = new List<byte>();
			IntFlagIds = new List<PlotFlagId>();
			FloatIndexes = new List<Dummy>();
			FloatFlagIds = new List<PlotFlagId>();
			DefaultIntValues = new List<ushort>();
			DefaultFloatValuesCompressed = new List<Dummy>();
		}
	}
}
