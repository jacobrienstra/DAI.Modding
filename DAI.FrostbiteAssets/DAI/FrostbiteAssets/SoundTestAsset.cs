using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundTestAsset : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<Dummy>> TaskSpecs { get; set; }

		[FieldOffset(16, 80)]
		public List<ExternalObject<Dummy>> TestSpecs { get; set; }

		[FieldOffset(20, 88)]
		public List<ExternalObject<Dummy>> Suites { get; set; }

		public SoundTestAsset()
		{
			TaskSpecs = new List<ExternalObject<Dummy>>();
			TestSpecs = new List<ExternalObject<Dummy>>();
			Suites = new List<ExternalObject<Dummy>>();
		}
	}
}
