using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PauseAndPlayManagerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public float DefaultTransitionTime { get; set; }

		[FieldOffset(20, 104)]
		public ExternalObject<PauseAndPlayInspectorEntityData> InspectorData { get; set; }

		[FieldOffset(24, 112)]
		public ExternalObject<EffectBlueprint> TargetingVFX { get; set; }

		[FieldOffset(28, 120)]
		public float EngageTransitionTime { get; set; }

		[FieldOffset(32, 128)]
		public List<PauseAndPlayPathLineData> PathLineData { get; set; }

		[FieldOffset(36, 136)]
		public EntryInputOverrideData InputOverride { get; set; }

		public PauseAndPlayManagerEntityData()
		{
			PathLineData = new List<PauseAndPlayPathLineData>();
		}
	}
}
