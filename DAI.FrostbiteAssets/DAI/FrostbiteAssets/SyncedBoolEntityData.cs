namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SyncedBoolEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public bool In { get; set; }
	}
}
