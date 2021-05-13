using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PerEmotionGeneratorConfiguration : DataContainer
	{
		[FieldOffset(8, 24)]
		public string Name { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<Dummy> Parent { get; set; }

		[FieldOffset(16, 40)]
		public List<ExternalObject<Dummy>> PoseFrequencies { get; set; }

		[FieldOffset(20, 48)]
		public List<ExternalObject<PA2LookAtConfiguration>> PerPoseAnimationFrequencies { get; set; }

		public PerEmotionGeneratorConfiguration()
		{
			PoseFrequencies = new List<ExternalObject<Dummy>>();
			PerPoseAnimationFrequencies = new List<ExternalObject<PA2LookAtConfiguration>>();
		}
	}
}
