namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RecipeMaterialParamCopyInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public string ParameterName { get; set; }

		[FieldOffset(4, 8)]
		public bool ExtractXValue { get; set; }

		[FieldOffset(5, 9)]
		public bool ExtractYValue { get; set; }

		[FieldOffset(6, 10)]
		public bool ExtractZValue { get; set; }

		[FieldOffset(7, 11)]
		public bool ExtractWValue { get; set; }
	}
}
