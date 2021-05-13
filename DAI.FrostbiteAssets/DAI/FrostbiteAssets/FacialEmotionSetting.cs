using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FacialEmotionSetting : DataContainer
	{
		[FieldOffset(8, 24)]
		public float OverallWeight { get; set; }

		[FieldOffset(12, 32)]
		public List<ExternalObject<DataContainer>> Weights { get; set; }

		public FacialEmotionSetting()
		{
			Weights = new List<ExternalObject<DataContainer>>();
		}
	}
}
