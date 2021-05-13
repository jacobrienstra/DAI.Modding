using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EmitterTagList : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<Dummy>> Tags { get; set; }

		public EmitterTagList()
		{
			Tags = new List<ExternalObject<Dummy>>();
		}
	}
}
