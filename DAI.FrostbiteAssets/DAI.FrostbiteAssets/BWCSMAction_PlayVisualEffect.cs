using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_PlayVisualEffect : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<EffectBlueprint> VisualEffectData { get; set; }

		[FieldOffset(32, 80)]
		public ExternalObject<TransformProvider> Location { get; set; }

		[FieldOffset(36, 88)]
		public ExternalObject<TransformProvider> LocationA { get; set; }

		[FieldOffset(40, 96)]
		public ExternalObject<TransformProvider> LocationB { get; set; }

		[FieldOffset(44, 104)]
		public ExternalObject<TransformProvider> LocationC { get; set; }

		[FieldOffset(48, 112)]
		public List<ExternalObject<Dummy>> EffectParameters { get; set; }

		[FieldOffset(52, 120)]
		public float Scale { get; set; }

		[FieldOffset(56, 124)]
		public bool SupportCrustEffect { get; set; }

		[FieldOffset(57, 125)]
		public bool StayAttached { get; set; }

		[FieldOffset(58, 126)]
		public bool TerminateWithAction { get; set; }

		[FieldOffset(59, 127)]
		public bool ClearVFXOnTerminate { get; set; }

		public BWCSMAction_PlayVisualEffect()
		{
			EffectParameters = new List<ExternalObject<Dummy>>();
		}
	}
}
