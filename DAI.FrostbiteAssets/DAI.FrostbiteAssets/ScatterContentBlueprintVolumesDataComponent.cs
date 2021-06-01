using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ScatterContentBlueprintVolumesDataComponent : SubWorldDataComponent
	{
		[FieldOffset(8, 24)]
		public List<BlueprintStreamingVolume> Volumes { get; set; }

		public ScatterContentBlueprintVolumesDataComponent()
		{
			Volumes = new List<BlueprintStreamingVolume>();
		}
	}
}
