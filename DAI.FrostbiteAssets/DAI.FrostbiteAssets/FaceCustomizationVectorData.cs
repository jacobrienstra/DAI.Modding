using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FaceCustomizationVectorData : LinkObject
	{
		[FieldOffset(0, 0)]
		public uint UsageHash { get; set; }

		[FieldOffset(4, 4)]
		public uint VectorParameterHandle { get; set; }

		[FieldOffset(8, 8)]
		public SliderParameterAffectVectorComponent AffectedComponent { get; set; }

		[FieldOffset(12, 12)]
		public float Min { get; set; }

		[FieldOffset(16, 16)]
		public float Max { get; set; }

		[FieldOffset(20, 20)]
		public float Step { get; set; }

		[FieldOffset(24, 24)]
		public List<float> Value { get; set; }

		public FaceCustomizationVectorData()
		{
			Value = new List<float>();
		}
	}
}
