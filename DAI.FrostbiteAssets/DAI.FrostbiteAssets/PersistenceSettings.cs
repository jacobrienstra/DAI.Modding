namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PersistenceSettings : SystemSettings
	{
		[FieldOffset(16, 40)]
		public ExternalObject<Dummy> StatCategoryTreeCollection { get; set; }

		[FieldOffset(20, 48)]
		public ExternalObject<Dummy> MPProfile { get; set; }

		[FieldOffset(24, 56)]
		public ExternalObject<PlayerTypeProfile> SPProfile { get; set; }

		[FieldOffset(28, 64)]
		public ExternalObject<Dummy> CoopProfile { get; set; }

		[FieldOffset(32, 72)]
		public ExternalObject<Dummy> LicenseConfig { get; set; }
	}
}
