namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SyncedSequenceEntityData : SequenceEntityData
	{
		[FieldOffset(60, 168)]
		public bool InterpolateTime { get; set; }
	}
}
