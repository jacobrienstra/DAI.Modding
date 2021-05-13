using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class NotificationDataConfiguration : Asset
	{
		[FieldOffset(12, 72)]
		public List<ShelfNotificationConfigData> ShelfData { get; set; }

		[FieldOffset(16, 80)]
		public List<TextNotificationConfigData> TextData { get; set; }

		[FieldOffset(20, 88)]
		public List<UberNotificationConfigData> UberData { get; set; }

		public NotificationDataConfiguration()
		{
			ShelfData = new List<ShelfNotificationConfigData>();
			TextData = new List<TextNotificationConfigData>();
			UberData = new List<UberNotificationConfigData>();
		}
	}
}
