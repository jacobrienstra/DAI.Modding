namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SyncedIntEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public int In { get; set; }
	}
}
