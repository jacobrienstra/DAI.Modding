using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class PauseAndPlayInspectorEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public FreeMoveInputData Input { get; set; }

		[FieldOffset(116, 212)]
		public float SelectionRadius { get; set; }

		[FieldOffset(120, 216)]
		public float SelectionQueryRadius { get; set; }

		[FieldOffset(124, 224)]
		public List<EnumEnemyType> CycleTargetIgnoreEnemyTypes { get; set; }

		public PauseAndPlayInspectorEntityData()
		{
			CycleTargetIgnoreEnemyTypes = new List<EnumEnemyType>();
		}
	}
}
