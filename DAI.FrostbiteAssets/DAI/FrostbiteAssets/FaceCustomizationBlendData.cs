using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FaceCustomizationBlendData : LinkObject
	{
		[FieldOffset(0, 0)]
		public uint UsageHash { get; set; }

		[FieldOffset(4, 4)]
		public Vec2 AnalogValue { get; set; }

		[FieldOffset(12, 16)]
		public List<FaceCustomizationUniversalShapeData> UniversalShapeData { get; set; }

		public FaceCustomizationBlendData()
		{
			UniversalShapeData = new List<FaceCustomizationUniversalShapeData>();
		}
	}
}
