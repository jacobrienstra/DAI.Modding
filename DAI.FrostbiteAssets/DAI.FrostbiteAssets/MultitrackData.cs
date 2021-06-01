using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MultitrackData : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<Dummy> LayerControlParameter { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<Dummy> RangeFade { get; set; }

		[FieldOffset(16, 40)]
		public List<ExternalObject<Dummy>> Layers { get; set; }

		public MultitrackData()
		{
			Layers = new List<ExternalObject<Dummy>>();
		}
	}
}
