namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWBoundedFloatVariableEntityData : BWBoundedVariableEntityData
	{
		[FieldOffset(24, 104)]
		public float DefaultValue { get; set; }

		[FieldOffset(28, 108)]
		public float IncDecValue { get; set; }

		[FieldOffset(32, 112)]
		public float MaxValue { get; set; }

		[FieldOffset(36, 116)]
		public float MinValue { get; set; }
	}
}
