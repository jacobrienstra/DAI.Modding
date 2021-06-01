using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UberNotificationEntityData : SubTitledNotificationEntityData
	{
		[FieldOffset(80, 224)]
		public Realm Realm { get; set; }

		[FieldOffset(84, 232)]
		public string UberDataID { get; set; }

		[FieldOffset(88, 240)]
		public int ProgressValue { get; set; }

		[FieldOffset(92, 244)]
		public int ProgressTotal { get; set; }
	}
}
