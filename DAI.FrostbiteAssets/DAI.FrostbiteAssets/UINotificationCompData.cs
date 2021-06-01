namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UINotificationCompData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public float ShelfWaitTime { get; set; }

		[FieldOffset(36, 140)]
		public float TextWaitTime { get; set; }

		[FieldOffset(40, 144)]
		public float UberWaitTime { get; set; }
	}
}
