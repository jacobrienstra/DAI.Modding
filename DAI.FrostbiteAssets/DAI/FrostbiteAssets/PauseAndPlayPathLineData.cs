namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PauseAndPlayPathLineData : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<TransformProvider_Self> StartTransform { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<TransformProvider_Select> EndTransform { get; set; }

		[FieldOffset(8, 16)]
		public ExternalObject<EffectBlueprint> PathNodeVFX { get; set; }

		[FieldOffset(12, 24)]
		public ExternalObject<EffectBlueprint> PathStartNodeVFX { get; set; }

		[FieldOffset(16, 32)]
		public ExternalObject<EffectBlueprint> PathEndNodeVFX { get; set; }

		[FieldOffset(20, 40)]
		public bool ApplyToPlayerCharacter { get; set; }

		[FieldOffset(21, 41)]
		public bool ApplyToOtherPartyMembers { get; set; }

		[FieldOffset(22, 42)]
		public bool HideOnEngage { get; set; }

		[FieldOffset(23, 43)]
		public bool ComputeAsync { get; set; }
	}
}
