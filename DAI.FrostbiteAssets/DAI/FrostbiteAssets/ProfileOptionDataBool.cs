namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ProfileOptionDataBool : ProfileOptionData
	{
		[FieldOffset(20, 88)]
		public bool Value { get; set; }
	}
}
