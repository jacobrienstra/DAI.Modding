namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PhysicsCapsuleShapeData : Asset
	{
		[FieldOffset(12, 72)]
		public float Radius { get; set; }

		[FieldOffset(16, 76)]
		public float Length { get; set; }
	}
}
