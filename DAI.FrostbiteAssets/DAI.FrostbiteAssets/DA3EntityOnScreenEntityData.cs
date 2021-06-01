namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DA3EntityOnScreenEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public float Radius { get; set; }

		[FieldOffset(20, 100)]
		public bool RequiresLOS { get; set; }
	}
}
