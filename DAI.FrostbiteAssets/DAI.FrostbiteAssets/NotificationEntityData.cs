using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class NotificationEntityData : NotificationEntityBaseData
	{
		[FieldOffset(48, 160)]
		public Realm Realm { get; set; }

		[FieldOffset(52, 168)]
		public string ShelfDataID { get; set; }
	}
}
