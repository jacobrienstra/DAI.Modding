namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FreeLookCollisionData
	{
		[FieldOffset(0, 0)]
		public float Buffer { get; set; }

		[FieldOffset(4, 4)]
		public float BufferSpring { get; set; }

		[FieldOffset(8, 8)]
		public float BufferDamper { get; set; }

		[FieldOffset(12, 12)]
		public bool Enabled { get; set; }
	}
}
