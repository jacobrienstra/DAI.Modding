using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StreamPoolAsset : Asset
	{
		[FieldOffset(12, 72)]
		public uint StreamPoolId { get; set; }

		[FieldOffset(16, 80)]
		public List<ExternalObject<StreamPoolSetup>> Setups { get; set; }

		public StreamPoolAsset()
		{
			Setups = new List<ExternalObject<StreamPoolSetup>>();
		}
	}
}
