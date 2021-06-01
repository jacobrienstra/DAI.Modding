using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EmitterSystemComponent : SubWorldDataComponent
	{
		[FieldOffset(8, 24)]
		public uint ExclusionVolumesCount { get; set; }

		[FieldOffset(12, 32)]
		public List<EmitterExclusionVolume> ExclusionVolumes { get; set; }

		[FieldOffset(16, 40)]
		public List<EmitterExclusionVolumeBoundingSphereSoA> ExclusionVolumeBoundingSpheres { get; set; }

		public EmitterSystemComponent()
		{
			ExclusionVolumes = new List<EmitterExclusionVolume>();
			ExclusionVolumeBoundingSpheres = new List<EmitterExclusionVolumeBoundingSphereSoA>();
		}
	}
}
