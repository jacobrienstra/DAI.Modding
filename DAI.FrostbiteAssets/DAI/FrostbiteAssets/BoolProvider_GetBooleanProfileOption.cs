namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProvider_GetBooleanProfileOption : BoolProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<ProfileOptionDataBool> ProfileOption { get; set; }
	}
}
