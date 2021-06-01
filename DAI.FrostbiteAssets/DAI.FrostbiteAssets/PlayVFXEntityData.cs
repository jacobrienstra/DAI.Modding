namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class PlayVFXEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public VFXLocationControl EffectLocation { get; set; }

		[FieldOffset(96, 176)]
		public VFXLocationControl LocationA { get; set; }

		[FieldOffset(176, 256)]
		public VFXLocationControl LocationB { get; set; }

		[FieldOffset(256, 336)]
		public VFXLocationControl LocationC { get; set; }

		[FieldOffset(336, 416)]
		public LinearTransform RawTransformEffectLocation { get; set; }

		[FieldOffset(400, 480)]
		public LinearTransform RawTransformLocationA { get; set; }

		[FieldOffset(464, 544)]
		public LinearTransform RawTransformLocationB { get; set; }

		[FieldOffset(528, 608)]
		public LinearTransform RawTransformLocationC { get; set; }

		[FieldOffset(592, 672)]
		public ExternalObject<EffectBlueprint> VisualEffect { get; set; }
	}
}
