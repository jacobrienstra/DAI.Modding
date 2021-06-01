using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ProcessorData : DataContainer
	{
		[FieldOffset(8, 24)]
		public EmittableField EvaluatorInput { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<Dummy> EvaluatorInputParam { get; set; }
	}
}
