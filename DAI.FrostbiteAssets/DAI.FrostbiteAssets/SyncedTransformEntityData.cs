namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SyncedTransformEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public LinearTransform In { get; set; }

		[FieldOffset(80, 160)]
		public bool Interpolate { get; set; }
	}
}
