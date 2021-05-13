namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class IntegerProvider_ProfileOption : IntegerProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<ProfileOptionDataEnum> ProfileOption { get; set; }

		[FieldOffset(12, 40)]
		public int NullValue { get; set; }

		[FieldOffset(16, 44)]
		public bool ReturnDefaultValue { get; set; }
	}
}
