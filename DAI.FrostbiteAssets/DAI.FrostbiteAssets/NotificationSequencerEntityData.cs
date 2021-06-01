namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class NotificationSequencerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public string PowerUberDataID { get; set; }

		[FieldOffset(20, 104)]
		public string LevelUpUberDataID { get; set; }
	}
}
