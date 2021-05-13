using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RandomSelectTransform : CSMTransformProvider
	{
		[FieldOffset(8, 32)]
		public List<ExternalObject<DataContainer>> Transforms { get; set; }

		[FieldOffset(12, 40)]
		public int RandomSeed { get; set; }

		public RandomSelectTransform()
		{
			Transforms = new List<ExternalObject<DataContainer>>();
		}
	}
}
