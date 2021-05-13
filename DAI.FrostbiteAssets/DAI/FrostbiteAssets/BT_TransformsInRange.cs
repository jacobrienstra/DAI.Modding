namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_TransformsInRange : BTEvalFunc
	{
		[FieldOffset(16, 40)]
		public ExternalObject<TransformProvider_Self> SourceTransform { get; set; }

		[FieldOffset(20, 48)]
		public ExternalObject<FloatProvider_CharacterRadius> SourceRadius { get; set; }

		[FieldOffset(24, 56)]
		public ExternalObject<TetherLeashTransform> TargetTransform { get; set; }

		[FieldOffset(28, 64)]
		public ExternalObject<Dummy> TargetRadius { get; set; }

		[FieldOffset(32, 72)]
		public ExternalObject<Dummy> Range { get; set; }

		[FieldOffset(36, 80)]
		public ExternalObject<Dummy> MinRange { get; set; }

		[FieldOffset(40, 88)]
		public float OverrideRange { get; set; }

		[FieldOffset(44, 92)]
		public float ArcSize { get; set; }

		[FieldOffset(48, 96)]
		public float ArcOffset { get; set; }

		[FieldOffset(52, 100)]
		public bool Test2D { get; set; }
	}
}
