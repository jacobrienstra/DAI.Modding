using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MixGroup : DataContainer
	{
		[FieldOffset(8, 24)]
		public string Name { get; set; }

		[FieldOffset(12, 32)]
		public List<MixGroupPropertyParameters> Parameters { get; set; }

		[FieldOffset(16, 40)]
		public short GroupIndex { get; set; }

		[FieldOffset(18, 42)]
		public short ParentGroupIndex { get; set; }

		public MixGroup()
		{
			Parameters = new List<MixGroupPropertyParameters>();
		}
	}
}
