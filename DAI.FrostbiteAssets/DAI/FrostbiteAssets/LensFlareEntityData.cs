using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class LensFlareEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public float Dimmer { get; set; }

		[FieldOffset(84, 180)]
		public float OccluderSize { get; set; }

		[FieldOffset(88, 184)]
		public float DepthBias { get; set; }

		[FieldOffset(92, 192)]
		public List<LensFlareElement> Elements { get; set; }

		[FieldOffset(96, 200)]
		public bool Visible { get; set; }

		[FieldOffset(97, 201)]
		public bool DebugDrawOccluder { get; set; }

		[FieldOffset(98, 202)]
		public bool HalfRes { get; set; }

		public LensFlareEntityData()
		{
			Elements = new List<LensFlareElement>();
		}
	}
}
