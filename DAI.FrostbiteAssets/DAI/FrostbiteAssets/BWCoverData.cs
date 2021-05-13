namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWCoverData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public float HalfAngle { get; set; }

		[FieldOffset(84, 180)]
		public bool Enabled { get; set; }
	}
}
