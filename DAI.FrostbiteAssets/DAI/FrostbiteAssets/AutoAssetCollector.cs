using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AutoAssetCollector : DataContainer
	{
		[FieldOffset(8, 24)]
		public List<ExternalObject<GamePhysicsEntityData>> Assets { get; set; }

		[FieldOffset(12, 32)]
		public float AutoCollectMinimumUsagePercentage { get; set; }

		public AutoAssetCollector()
		{
			Assets = new List<ExternalObject<GamePhysicsEntityData>>();
		}
	}
}
