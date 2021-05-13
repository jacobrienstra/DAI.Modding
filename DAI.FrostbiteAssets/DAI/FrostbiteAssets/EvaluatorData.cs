namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EvaluatorData : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<EffectParameter> Parameter { get; set; }
	}
}
