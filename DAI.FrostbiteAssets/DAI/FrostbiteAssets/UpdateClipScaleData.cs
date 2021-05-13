using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UpdateClipScaleData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public List<ushort> Lookup { get; set; }

		public UpdateClipScaleData()
		{
			Lookup = new List<ushort>();
		}
	}
}
