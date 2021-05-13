using System;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlotFlagId
	{
		[FieldOffset(0, 0)]
		public Guid Guid { get; set; }
	}
}
