namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class OperationWarTableLocatorData : SpecializingInteractableLocatorData
	{
		[FieldOffset(80, 176)]
		public ExternalObject<Dummy> Operation { get; set; }
	}
}
