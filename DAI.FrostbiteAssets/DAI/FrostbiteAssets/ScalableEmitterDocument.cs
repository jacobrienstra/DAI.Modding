namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ScalableEmitterDocument : EmitterDocument
	{
		[FieldOffset(12, 104)]
		public ExternalObject<EmitterTemplateData> TemplateDataLow { get; set; }

		[FieldOffset(16, 112)]
		public ExternalObject<EmitterTemplateData> TemplateDataMedium { get; set; }

		[FieldOffset(20, 120)]
		public ExternalObject<EmitterTemplateData> TemplateDataHigh { get; set; }

		[FieldOffset(24, 128)]
		public ExternalObject<EmitterTemplateData> TemplateDataUltra { get; set; }
	}
}
