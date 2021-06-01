using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BlueprintStreamingVolume : LinkObject
	{
		[FieldOffset(0, 0)]
		public uint BlueprintBundleHash { get; set; }

		[FieldOffset(4, 4)]
		public int Category { get; set; }

		[FieldOffset(8, 8)]
		public List<ScatterContentStreamingVolume> StreamingVolumes { get; set; }

		public BlueprintStreamingVolume()
		{
			StreamingVolumes = new List<ScatterContentStreamingVolume>();
		}
	}
}
