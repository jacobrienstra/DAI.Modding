using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AmbientAIComponentSpawnData : ExtraSpawnData
	{
		[FieldOffset(8, 24)]
		public float AmbientAIProximityWeightingExponent { get; set; }

		[FieldOffset(12, 32)]
		public List<ExternalObject<DataContainer>> SpatialActions { get; set; }

		[FieldOffset(16, 40)]
		public bool LimitToEnvironments { get; set; }

		public AmbientAIComponentSpawnData()
		{
			SpatialActions = new List<ExternalObject<DataContainer>>();
		}
	}
}
