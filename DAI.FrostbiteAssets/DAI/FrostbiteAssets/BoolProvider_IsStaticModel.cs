namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProvider_IsStaticModel : BoolProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<CSMEntityProvider> Entity { get; set; }

		[FieldOffset(12, 40)]
		public bool ReturnIfInvalid { get; set; }

		[FieldOffset(13, 41)]
		public bool IncludeUnspawnedStaticModels { get; set; }
	}
}
