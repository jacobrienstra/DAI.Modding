namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class EmitterExclusionVolumeBoundingSphereSoA
	{
		[FieldOffset(0, 0)]
		public Vec4 PosX { get; set; }

		[FieldOffset(16, 16)]
		public Vec4 PosY { get; set; }

		[FieldOffset(32, 32)]
		public Vec4 PosZ { get; set; }

		[FieldOffset(48, 48)]
		public Vec4 RadiusSqr { get; set; }
	}
}
