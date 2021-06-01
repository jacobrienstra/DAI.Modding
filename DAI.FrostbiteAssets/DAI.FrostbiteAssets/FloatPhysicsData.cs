namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FloatPhysicsData : DataContainer
	{
		[FieldOffset(8, 24)]
		public float Density { get; set; }

		[FieldOffset(12, 28)]
		public float FilledDensity { get; set; }
	}
}
