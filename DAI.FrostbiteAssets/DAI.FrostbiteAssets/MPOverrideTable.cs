using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MPOverrideTable : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<Dummy>> Entries { get; set; }

		public MPOverrideTable()
		{
			Entries = new List<ExternalObject<Dummy>>();
		}
	}
}
