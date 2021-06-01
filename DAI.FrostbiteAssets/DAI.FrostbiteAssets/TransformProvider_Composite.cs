namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TransformProvider_Composite : TransformProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<TransformProvider> LeftTransform { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<TransformProvider> RightTransform { get; set; }

		[FieldOffset(16, 48)]
		public bool AddTranslations { get; set; }
	}
}
