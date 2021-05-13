namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SyncedFloatEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public float In { get; set; }
	}
}
