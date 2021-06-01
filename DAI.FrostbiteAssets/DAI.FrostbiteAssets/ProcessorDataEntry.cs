namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ProcessorDataEntry : LinkObject
	{
		[FieldOffset(0, 0)]
		public uint ProcessorHash { get; set; }

		[FieldOffset(4, 4)]
		public uint ProcessorType { get; set; }

		[FieldOffset(8, 8)]
		public ExternalObject<ProcessorData> Processor { get; set; }

		[FieldOffset(12, 16)]
		public uint EvaluatorHash { get; set; }

		[FieldOffset(16, 20)]
		public uint EvaluatorType { get; set; }

		[FieldOffset(20, 24)]
		public ExternalObject<EvaluatorData> Evaluator { get; set; }
	}
}
