namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWBoundedIntegerVariableEntityData : BWBoundedVariableEntityData
	{
		[FieldOffset(24, 104)]
		public int DefaultValue { get; set; }

		[FieldOffset(28, 108)]
		public int IncDecValue { get; set; }

		[FieldOffset(32, 112)]
		public int MaxValue { get; set; }

		[FieldOffset(36, 116)]
		public int MinValue { get; set; }
	}
}
