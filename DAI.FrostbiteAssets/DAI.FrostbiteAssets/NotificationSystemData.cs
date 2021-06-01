namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class NotificationSystemData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<NotificationDataConfiguration> DataConfiguration { get; set; }
	}
}
