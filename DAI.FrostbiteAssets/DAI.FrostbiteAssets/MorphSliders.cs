using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MorphSliders : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<MorphTwoWaySlider>> TwoWaySliders { get; set; }

		[FieldOffset(16, 80)]
		public List<ExternalObject<MorphTwoWaySlider>> OneWaySliders { get; set; }

		public MorphSliders()
		{
			TwoWaySliders = new List<ExternalObject<MorphTwoWaySlider>>();
			OneWaySliders = new List<ExternalObject<MorphTwoWaySlider>>();
		}
	}
}
