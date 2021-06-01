using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class AmbientAIComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public float AmbientAIRange { get; set; }

		[FieldOffset(100, 180)]
		public float AmbientAIProximityWeightingExponent { get; set; }

		[FieldOffset(104, 184)]
		public int PreyHierarchy { get; set; }

		[FieldOffset(108, 192)]
		public List<int> Environments { get; set; }

		[FieldOffset(112, 200)]
		public List<ExternalObject<DataContainer>> SpatialActions { get; set; }

		[FieldOffset(116, 208)]
		public ExternalObject<SpatialAmbientAction> FallbackAction { get; set; }

		[FieldOffset(120, 216)]
		public bool Enabled { get; set; }

		[FieldOffset(121, 217)]
		public bool AmbientAutoSearchEnabled { get; set; }

		[FieldOffset(122, 218)]
		public bool AnchorToSpawnLocation { get; set; }

		[FieldOffset(123, 219)]
		public bool AmbientUseTetherLeash { get; set; }

		[FieldOffset(124, 220)]
		public bool LimitToEnvironments { get; set; }

		public AmbientAIComponentData()
		{
			Environments = new List<int>();
			SpatialActions = new List<ExternalObject<DataContainer>>();
		}
	}
}
