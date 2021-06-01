using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class OpenURLEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public string Url { get; set; }

		[FieldOffset(20, 104)]
		public string IntegrationUrl { get; set; }

		[FieldOffset(24, 112)]
		public Realm Realm { get; set; }
	}
}
