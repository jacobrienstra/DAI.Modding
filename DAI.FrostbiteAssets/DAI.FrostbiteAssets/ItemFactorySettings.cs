namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ItemFactorySettings : BWGameplaySettings
	{
		[FieldOffset(12, 72)]
		public ExternalObject<BWStatList> StatList { get; set; }
	}
}
